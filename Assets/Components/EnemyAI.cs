using UnityEngine;

public class EnemyAI : MonoBehaviour {

	public FieldOfView fov;

	float alert = 0;

	public float alertSpeed = 1;
	public float relaxSpeed = 1;

	public Color normalColor;
	public Color alertColor;
	public Color hostileColor;

	float direction;

	public FloorSensor leftSensor;
	public FloorSensor rightSensor;

	SpriteRenderer sprite;
	Rigidbody2D phys;
	
	void Start () {
		sprite = GetComponent<SpriteRenderer>();
		phys = GetComponent<Rigidbody2D>();
		direction = transform.lossyScale.x;
	}

	void Update() {
		if (fov.SeesTarget) OnSeePlayer();
		else OnNotSeePlayer();

		if (alert == 0) sprite.color = normalColor;
		if (alert > 0) sprite.color = alertColor;
		if (alert == 1) sprite.color = hostileColor;

		if (!rightSensor.touchingFloor) {
			direction = -1;
		}

		if (!leftSensor.touchingFloor) {
			direction = 1;
		}

		SetEyePosition(direction);

		Vector2 vel = phys.velocity;
		vel.x -= (vel.x - direction)*200*Time.deltaTime;
		phys.velocity = vel;

	}

	void SetEyePosition(float direction) {
		fov.GetComponent<FollowObject>().offset = new Vector3(0.24f*direction, 0.3f, 0);
		fov.direction = new Vector2(direction, 0);
	}

	void OnSeePlayer() {
		GetComponent<SpriteRenderer>().color = Color.red;
		alert += alertSpeed*Time.deltaTime;
		if (alert > 1) alert = 1;
	}

	void OnNotSeePlayer() {
		GetComponent<SpriteRenderer>().color = Color.blue;
		alert -= relaxSpeed*Time.deltaTime;
		if (alert < 0) alert = 0;
	}
}
