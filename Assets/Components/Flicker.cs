using UnityEngine;

public class Flicker : MonoBehaviour {

	public Color color1;
	public Color color2;
	public float speed;

	SpriteRenderer sprite;

	float timer = 0;
	
	void Start () {
		sprite = GetComponent<SpriteRenderer>();
	}
	
	void Update () {
		timer += Time.deltaTime*speed;

		Color c = Color.Lerp(color1, color2, Mathf.Sin(timer));
		sprite.color = c;

	}
}
