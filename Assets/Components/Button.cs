using UnityEngine;
using UnityEngine.Events;

public class Button : MonoBehaviour {

	GameObject player;
	SpriteRenderer sprite;

	public float useDistance = 5;

	public Color normalColor;
	public Color activeColor;

	public bool active {
		get {
			Vector2 pos = transform.position;
			Vector2 playerPos = player.transform.position;
			return Vector2.Distance(pos, playerPos) <= useDistance;
		}
	}

	public UnityEvent onPressed;
	
	void Start () {
		player = GameObject.Find("Player");
		sprite = GetComponent<SpriteRenderer>();
	}
	
	void Update () {

		Vector2 pos = transform.position;
		Vector2 playerPos = player.transform.position;

		if (active) sprite.color = activeColor;
		else sprite.color = normalColor;

		if (Input.GetKeyDown(KeyCode.X) && active) {
			Debug.Log("yup");
			onPressed.Invoke();
		}

	}
}
