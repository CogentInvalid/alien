using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float maxSpeed = 3;
	public float friction = 6;
	public bool airControl = true;

	public float lowGrav = 8;
	public float highGrav = 20;
	public float jumpForce = 1;

	public Rigidbody2D phys;

	public bool onGround;
	
	void Start () {
		phys = GetComponent<Rigidbody2D>();
	}
	
	void Update () {

		float accel = 20;
		if (!onGround) accel = 12;

		float maxSpeed = this.maxSpeed;

		Vector2 vel = phys.velocity;

		//x-movement
		if (Input.GetAxis("Horizontal")<0 && vel.x > -maxSpeed)
			vel.x -= accel*Time.deltaTime;
		if (Input.GetAxis("Horizontal")>0 && vel.x < maxSpeed)
			vel.x += accel*Time.deltaTime;

		//friction
		if (onGround) {
			if (vel.x > 0) vel.x -= (friction*Time.deltaTime);
			else if (vel.x < 0) vel.x += (friction*Time.deltaTime);
			if (vel.x > -(friction*Time.deltaTime) && vel.x < (friction*Time.deltaTime)) vel.x = 0;
		}

		//jumping
		if (Input.GetButtonDown("Jump")) {
			Debug.Log("jump " + onGround);
			if (onGround) {
				vel.y = jumpForce;
				onGround = false;
			}
		}

		onGround = false;

		//jump holding/falling
		if (vel.y < 0) {
			phys.gravityScale = lowGrav;
		} else {
			if (Input.GetButton("Jump")) phys.gravityScale = lowGrav;
				else phys.gravityScale = highGrav;
			if (!airControl) phys.gravityScale = lowGrav;
		}

		phys.velocity = vel;

	}

	void OnCollisionEnter2D(Collision2D col) {
		if (col.contacts[0].normal.y > 0) {
			Debug.Log("yes");
			onGround = true;
		}
	}

	void OnCollisionStay2D(Collision2D col) {
		if (col.contacts[0].normal.y > 0) {
			Debug.Log("yes2");
			onGround = true;
		}
	}

}
