using UnityEngine;

public class Deathifier : MonoBehaviour {


	private void OnCollisionEnter2D(Collision2D collision) {
		Destroy(collision.collider.gameObject);
		if (collision.collider.tag == "Player") {
			GameObject.Find("Game").GetComponent<Game>().OnPlayerDeath();
		}
	}

}
