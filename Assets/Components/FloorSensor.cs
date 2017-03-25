using System.Collections.Generic;
using UnityEngine;

public class FloorSensor : MonoBehaviour {

	private List<GameObject> collisions;
	public bool touchingFloor {
		get { return collisions.Count > 0; }
	}

	void Start() {
		collisions = new List<GameObject>();
	}

	private void Update() {
		//Debug.Log(collisions.Count);
	}

	private void OnTriggerStay2D(Collider2D collision) {
		if (collision.tag == "Wall") {
			if (!collisions.Contains(collision.gameObject))
				collisions.Add(collision.gameObject);
		}
	}

	private void OnTriggerExit2D(Collider2D collision) {
		if (collision.tag == "Wall") {
			collisions.Remove(collision.gameObject);
		}
	}

}
