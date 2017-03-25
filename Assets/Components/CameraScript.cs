using UnityEngine;

public class CameraScript : MonoBehaviour {

	public GameObject target;

	public float speed = 3;
	public Vector2 offset;

	public Vector3 pos;
	
	void Start () {
		pos = transform.position;
	}
	
	void Update () {
		if (target != null) {
			Vector2 targetPos = target.transform.position;

			pos.x -= (pos.x - targetPos.x + offset.x)*speed*Time.deltaTime;
			pos.y -= (pos.y - targetPos.y + offset.y)*speed*Time.deltaTime;

			transform.position = new Vector3(Mathf.Round(pos.x*32)/32, Mathf.Round(pos.y*32)/32, pos.z);
		}
	}
}
