using UnityEngine;

public class EnemyAI : MonoBehaviour {

	public bool patrol = true;

	public FieldOfView fov;

	float alert = 0;
	public float alertSpeed = 1;
	public float relaxSpeed = 1;

	public Color normalColor;
	public Color alertColor;
	public Color hostileColor;

	public float direction;

	public FloorSensor leftSensor;
	public FloorSensor rightSensor;

	SpriteRenderer sprite;
	Rigidbody2D phys;
	PlatformerController controller;

	public GameObject bullet;

	public float shootTime = 0.4f;
	float shootTimer = 0f;

	void Start() {
		sprite = GetComponent<SpriteRenderer>();
		phys = GetComponent<Rigidbody2D>();
		controller = GetComponent<PlatformerController>();
		direction = transform.lossyScale.x;
	}

	void Update() {

		if (!controller.controlled) {
			if (fov.SeesTarget) OnSeePlayer();
			else OnNotSeePlayer();

			if (patrol) {
				if (controller.onGround) {
					if (!leftSensor.touchingFloor) direction = 1;
					if (!rightSensor.touchingFloor) direction = -1;
				}

				Walk(direction);
			}
			
		} else {
			OnNotSeePlayer();
		}

		if (alert == 0) sprite.color = normalColor;
		if (alert > 0) sprite.color = alertColor;
		if (alert == 1) sprite.color = hostileColor;

		if (alert == 1) {
			ShootPlayer();
		}

		SetEyePosition(controller.vel.x);

	}

	void Walk(float direction) {
		/*Vector2 vel = phys.velocity;
		vel.x -= (vel.x - direction*moveSpeed)*3*Time.deltaTime;
		if (vel.x > 4) vel.x = 4;
		if (vel.x < -4) vel.x = -4;
		phys.velocity = vel;*/

		controller.moveDir = new Vector2(direction, 0);
	}

	void ShootPlayer() {
		shootTimer -= Time.deltaTime;
		if (shootTimer <= 0) {
			shootTimer = shootTime;
			GameObject bulletInstance = Instantiate<GameObject>(bullet, fov.transform.position, new Quaternion());
			bulletInstance.GetComponent<Bullet>().velocity = (fov.target.transform.position-fov.transform.position).normalized*12;
		}
	}

	void SetEyePosition(float direction) {
		if (direction == 0) direction = this.direction;
		direction = Mathf.Sign(direction);
		fov.GetComponent<FollowObject>().offset = new Vector3(0.24f*direction, 0.3f, 0);
		fov.direction = new Vector2(direction, 0);
	}

	void OnSeePlayer() {
		alert += alertSpeed*Time.deltaTime;
		if (alert > 1) alert = 1;
	}

	void OnNotSeePlayer() {
		alert -= relaxSpeed*Time.deltaTime;
		if (alert < 0) alert = 0;
	}

	private void OnCollisionEnter2D(Collision2D collision) {
		if (!controller.controlled && patrol) {
			if (collision.contacts[0].normal.x > 0.75f) direction = 1;
			if (collision.contacts[0].normal.x < -0.75f) direction = -1;
		}
	}

}