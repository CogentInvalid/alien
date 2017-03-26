using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	public Scene currentScene;

	void Start() {
		SceneManager.sceneLoaded += LevelLoaded;
	}

	public void LoadLevel(string mapName) {
		SceneManager.LoadScene(mapName, LoadSceneMode.Additive);
	}

	void LevelLoaded(Scene newScene, LoadSceneMode loadMode) {
		SceneManager.UnloadScene(currentScene.name);
		currentScene = newScene;
		SceneManager.SetActiveScene(newScene);
	}
}
