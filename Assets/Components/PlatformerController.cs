using UnityEngine;

public class PlatformerController : MonoBehaviour {

	private Rigidbody2D phys;

	public float speed = 5;
	public float accel = 5;
	public float friction = 8;

	public float jumpForce = 5;

	public float lowGravScale = 5;
	public float highGravScale = 5;
	bool highGravity = false;

	private bool onGround;
	private float groundTime = 0.1f;
	private float groundTimer;

	Vector2 vel;
	
	void Start () {
		phys = GetComponent<Rigidbody2D>();
		groundTimer = groundTime;
	}
	
	void Update () {

		groundTimer -= Time.deltaTime;
		if (groundTimer <= 0) onGround = false;

		Vector2 moveDir = new Vector2(0, 0);
		if (Input.GetButton("Up")) moveDir.y++;
		if (Input.GetButton("Down")) moveDir.y--;
		if (Input.GetButton("Left")) moveDir.x--;
		if (Input.GetButton("Right")) moveDir.x++;

		//movement
		float xMove = 0; float yMove = 0;
		if (moveDir.x != 0) xMove = -(vel.x - speed*moveDir.x) * accel*Time.deltaTime;
		//if (moveDir.y != 0) yMove = -(vel.y - speed*moveDir.y) * accel*Time.deltaTime;
		vel.x += xMove; vel.y += yMove;

		//friction
		Vector2 fric = new Vector2();
		if (xMove == 0) vel.x -= vel.x*friction*Time.deltaTime;

		//jumping
		if (Input.GetButtonDown("Jump") && onGround) {
			vel.y = jumpForce;
			onGround = false;
			highGravity = false;
		}

		if (Input.GetButtonUp("Jump")) highGravity = true;

		if (vel.y < 0) highGravity = false;

		//gravity
		if (highGravity)
			vel.y -= highGravScale * Time.deltaTime;
		else
			vel.y -= lowGravScale * Time.deltaTime;

		phys.velocity = vel;
	}

	private void OnCollisionEnter2D(Collision2D collision) {
		CheckHitGround(collision);
	}

	private void OnCollisionStay2D(Collision2D collision) {
		CheckHitGround(collision);
	}

	void CheckHitGround(Collision2D collision) {
		if (collision.contacts[0].normal.y > 0.5f) {
			if (onGround) vel.y = -0.1f;
			onGround = true;
			groundTimer = groundTime;
		}
	}

}
