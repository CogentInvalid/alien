using UnityEngine;

public class KeycardSlot : MonoBehaviour {

	public int id;
	public GameObject door;
	public Sprite greenSprite;

	public void Activate() {
		door.SetActive(false);
		GetComponent<SpriteRenderer>().sprite = greenSprite;
	}

}
