using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour {
	
	
	public void OnPlayerDeath() {
		Invoke("Restart", 1.6f);
	}

	void Restart() {
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

}
