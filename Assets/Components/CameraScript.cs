using UnityEngine;

public class CameraScript : MonoBehaviour {

	public GameObject player;

	public float speed = 3;
	public Vector2 offset;
	
	void Start () {
		
	}
	
	void Update () {
		Vector3 pos = transform.position;
		Vector2 playerPos = player.transform.position;

		pos.x -= (pos.x - playerPos.x + offset.x)*speed*Time.deltaTime;
		pos.y -= (pos.y - playerPos.y + offset.y)*speed*Time.deltaTime;

		transform.position = pos;
	}
}
