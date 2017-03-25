using UnityEngine;
using UnityEngine.Events;

public class Button : MonoBehaviour {

	GameObject player;
	SpriteRenderer sprite;

	public float useDistance = 5;

	public bool hovered { get; set; }

	public Color normalColor;
	public Color activeColor;

	public bool active {
		get {
			Vector2 pos = transform.position;
			GameObject.FindGameObjectsWithTag("Enemy");
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

		/*Vector2 pos = transform.position;
		Vector2 playerPos = player.transform.position;

		if (active) sprite.color = activeColor;
		else sprite.color = normalColor;*/

		if (hovered) sprite.color = activeColor;
		else sprite.color = normalColor;

		hovered = false;

		//if (Input.GetKeyDown(KeyCode.X) && active) {
		//	Press();
		//}

	}

	public void Press() {
		onPressed.Invoke();
	}

}
