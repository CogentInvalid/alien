using UnityEngine;
using System.Collections;

public class KeycardHolder : MonoBehaviour {

	ArrayList cards = new ArrayList();

	private void OnTriggerEnter2D(Collider2D collision) {
		if (collision.tag == "Keycard") {
			Destroy(collision.gameObject);
			cards.Add(collision.GetComponent<Keycard>().id);
		}

		if (collision.tag == "KeycardSlot") {
			if (cards.Contains(collision.GetComponent<KeycardSlot>().id)) {
				collision.GetComponent<KeycardSlot>().Activate();
			}
		}
	}
}
