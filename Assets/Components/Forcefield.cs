using UnityEngine;

public class Forcefield : MonoBehaviour {

	public void Toggle() {
		gameObject.SetActive(!gameObject.activeSelf);
	}


}
