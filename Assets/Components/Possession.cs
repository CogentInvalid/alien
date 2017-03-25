using UnityEngine;

public class Possession : MonoBehaviour {

	public float dist = 2;

	GameObject currentControl;

	void Start () {
		currentControl = gameObject;
	}
	
	void Update () {

		GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
		float minDist = 9999;
		GameObject closestEnemy = null;
		foreach(GameObject enemy in enemies) {
			float d = Vector2.Distance(gameObject.transform.position, enemy.transform.position);
			if (d < minDist && d <= dist) {
				minDist = d;
				closestEnemy = enemy;
			}
		}

		if (Input.GetKeyDown(KeyCode.C)) {
			if (currentControl != gameObject) {
				currentControl.GetComponent<PlatformerController>().controlled = false;
				gameObject.GetComponent<PlatformerController>().controlled = true;
				currentControl = gameObject;
			} else if (closestEnemy != null) {
				currentControl.GetComponent<PlatformerController>().controlled = false;
				closestEnemy.GetComponent<PlatformerController>().controlled = true;
				currentControl = closestEnemy;
			}
		}


	}

}
