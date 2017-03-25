using UnityEngine;

public class SecurityCamera : MonoBehaviour {

	public GameObject cameraObject;
	public GameObject bullet;

	private float shootTime = 0.4f;
	private float shootTimer = 0;

	private void OnTriggerStay2D(Collider2D collision) {
		if (collision.tag == "Player") {
			ShootPlayer(collision.gameObject);
		}
	}

	void ShootPlayer(GameObject target) {
		shootTimer -= Time.deltaTime;
		if (shootTimer <= 0) {
			shootTimer = shootTime;
			GameObject bulletInstance = Instantiate<GameObject>(bullet, cameraObject.transform.position, new Quaternion());
			Vector2 dir = target.transform.position-cameraObject.transform.position;
			bulletInstance.GetComponent<Bullet>().velocity = dir.normalized*16;
		}
	}
}
