using UnityEngine;

public class Spawner : MonoBehaviour {

	public GameObject spawnObject;
	public float spawnRate;
	float timer;
	
	void Start () {
		timer = Random.Range(0, spawnRate);
	}
	
	void Update () {
		timer -= Time.deltaTime;
		if (timer <= 0) {
			timer = spawnRate;
			GameObject s = Instantiate(spawnObject, transform.position, new Quaternion());
		}
	}
}
