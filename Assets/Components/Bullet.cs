using UnityEngine;

public class Bullet : MonoBehaviour {

	public Vector2 velocity;

	private void Update() {
		Vector2 pos = transform.position;
		pos += velocity*Time.deltaTime;
		transform.position = pos;
	}

	private void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Wall") Destroy(gameObject);

		if (other.tag == "Player") {
			Destroy(other.gameObject);
			GameObject.FindObjectOfType<Game>().OnPlayerDeath();
		}

	}

}
