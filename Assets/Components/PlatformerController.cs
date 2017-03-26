using UnityEngine;

public class PlatformerController : MonoBehaviour {

	private Rigidbody2D phys;

	public bool controlled = false;

	public bool buttonPermissions = true;

	public float speed = 5;
	public float accel = 5;
	public float friction = 8;

	public float jumpForce = 5;

	public float lowGravScale = 5;
	public float highGravScale = 5;
	bool highGravity = false;

	public bool onGround;
	private float groundTime = 0.1f;
	private float groundTimer;

	private bool onLadder;
	private float ladderTimer = 0.1f;

	public Vector2 vel;
	public Vector2 moveDir;
	
	void Start () {
		phys = GetComponent<Rigidbody2D>();
		groundTimer = groundTime;
		moveDir = new Vector2();
	}
	
	void Update () {

		groundTimer -= Time.deltaTime;
		if (groundTimer <= 0) onGround = false;

		//buttons
		HoverButton();

		bool applyGravity = true;

		if (controlled) {
			if (Input.GetButton("Up")) moveDir.y++;
			if (Input.GetButton("Down")) moveDir.y--;
			if (Input.GetButton("Left")) moveDir.x--;
			if (Input.GetButton("Right")) moveDir.x++;

			if (GetComponent<EnemyAI>() != null && moveDir.x != 0) {
				GetComponent<EnemyAI>().direction = moveDir.x;
			}

			if (Input.GetKeyDown(KeyCode.X)) PressButton();

			//ladder
			if (onLadder) {
				if (Input.GetKey(KeyCode.UpArrow)) {
					applyGravity = false;
					vel.y -= (vel.y - 6) * 6*Time.deltaTime;
				}
			}

			ladderTimer -= Time.deltaTime;
			if (ladderTimer < 0) {
				onLadder = false;
			}
		}

		//movement
		Move(moveDir);

		moveDir = new Vector2(0, 0);

		//jumping
		if (Input.GetButtonDown("Jump") && onGround && controlled) {
			Jump(jumpForce);
		}

		if (Input.GetButtonUp("Jump")) highGravity = true;
		if (vel.y < 0) highGravity = false;

		//gravity
		if (applyGravity) {
			if (highGravity)
				vel.y -= highGravScale * Time.deltaTime;
			else
				vel.y -= lowGravScale * Time.deltaTime;
		}

		phys.velocity = vel;

	}

	public Button GetClosestButton() {
		Button[] buttons = GameObject.FindObjectsOfType<Button>();

		//find closest button
		float minDist = 9999;
		Button closestButton = null;
		foreach (Button button in buttons) {
			float dist = Vector2.Distance(transform.position, button.transform.position);
			if (dist < 2 && dist < minDist) {
				minDist = dist;
				closestButton = button;
			}
		}

		return closestButton;
	}

	public void HoverButton() {
		Button button = GetClosestButton();
		if (button != null && buttonPermissions) button.hovered = true;
	}

	public void PressButton() {
		Button button = GetClosestButton();
		if (button != null && buttonPermissions) button.Press();
	}

	public void Move(Vector2 moveDir) {
		//movement
		if (moveDir.x != 0) vel.x -= (vel.x - speed*moveDir.x) * accel*Time.deltaTime;

		//friction
		if (moveDir.x == 0) vel.x -= vel.x*friction*Time.deltaTime;
	}

	public void Jump(float force) {
		vel.y = force;
		onGround = false;
		highGravity = false;
	}

	//private void OnCollisionEnter2D(Collision2D collision) {
	//	CheckHitGround(collision);
	//}

	private void OnTriggerStay2D(Collider2D collision) {
		if (collision.tag == "Ladder") {
			onLadder = true;
			ladderTimer = 0.1f;
		}
	}

	private void OnCollisionEnter2D(Collision2D collision) {
		if (collision.collider.tag == "Wall") {
			if (collision.contacts[0].normal.x < -0.8f) vel.x = 0.01f;
			if (collision.contacts[0].normal.x > 0.8f) vel.x = -0.01f;
			if (collision.contacts[0].normal.y < -0.8f) vel.y = -0.01f;
		}
	}

	private void OnCollisionStay2D(Collision2D collision) {
		CheckHitGround(collision);
	}

	void CheckHitGround(Collision2D collision) {
		if (collision.contacts[0].normal.y > 0.5f) {
			if (onGround && vel.y < 0) vel.y = -0.1f;
			onGround = true;
			groundTimer = groundTime;
		}
	}

}
