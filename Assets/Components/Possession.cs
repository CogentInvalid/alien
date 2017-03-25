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
				SetControlledObject(gameObject);
			} else if (closestEnemy != null) {
				SetControlledObject(closestEnemy);
			}

		}

	}

	void SetControlledObject(GameObject obj) {
		currentControl.GetComponent<PlatformerController>().controlled = false;
		obj.GetComponent<PlatformerController>().controlled = true;
		currentControl = obj;

		Camera.main.GetComponent<CameraScript>().target = obj;
	}

}
