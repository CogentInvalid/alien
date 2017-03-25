using UnityEngine;

public class FollowObject : MonoBehaviour {

	public GameObject followObject;
	public Vector3 offset;

	void Start() {
		Follow();
	}

	void Update() {
		Follow();
	}

	private void Follow() {
		if (followObject != null) {
			Vector3 pos = followObject.transform.position;
			transform.position = pos + offset;
		}
	}
}
