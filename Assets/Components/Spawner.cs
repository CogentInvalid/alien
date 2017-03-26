using UnityEngine;

public class Spawner : MonoBehaviour {

	public GameObject spawnObject;
	public float spawnRate;
	float timer;
	
	void Start () {
		timer = spawnRate;
	}
	
	void Update () {
		timer -= Time.deltaTime;
		if (timer <= 0) {
			timer = spawnRate;
			Instantiate(spawnObject, transform.position, new Quaternion());
		}
	}
}
