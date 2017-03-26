using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitDoor : MonoBehaviour {

	private void OnTriggerEnter2D(Collider2D collision) {
		if (collision.tag == "Player") {
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
		}
	}


}
