using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitDoor : MonoBehaviour {

	private void OnTriggerEnter2D(Collider2D collision) {
		if (collision.tag == "Player") {
			NextMap();
			//GameObject.Find("Levels").GetComponent<LevelManager>().LoadLevel(SceneManager.GetSceneByBuildIndex(SceneManager.GetActiveScene().buildIndex+1).name); //cursed line. do not execute on a full moon
		}
	}

	public void NextMap() {
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
	}


}
