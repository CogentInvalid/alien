using UnityEngine;

public class CameraScript : MonoBehaviour {

	public GameObject target;

	public float speed = 3;
	public Vector2 offset;
	
	void Start () {
		
	}
	
	void Update () {
		if (target != null) {
			Vector3 pos = transform.position;
			Vector2 targetPos = target.transform.position;

			pos.x -= (pos.x - targetPos.x + offset.x)*speed*Time.deltaTime;
			pos.y -= (pos.y - targetPos.y + offset.y)*speed*Time.deltaTime;

			transform.position = pos;
		}
	}
}
