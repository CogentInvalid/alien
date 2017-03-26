using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour {
	
	
	public void OnPlayerDeath() {
		GameObject.Find("death").GetComponent<AudioSource>().Play();
		Invoke("Restart", 1.6f);
	}

	void Restart() {
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	private void Update() {
		if (Input.GetKeyDown(KeyCode.Escape)) {
			Application.Quit();
		}
	}

}
