using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLoader : MonoBehaviour {

	void Awake () {
		if (!SceneManager.GetSceneByName("game").isLoaded) {
			SceneManager.LoadScene("game", LoadSceneMode.Additive);
		}
	}

}
