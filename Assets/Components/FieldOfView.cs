using UnityEngine;

public class FieldOfView : MonoBehaviour {

	public GameObject target;

	public float distance = 10;
	public Vector2 direction;
	public float angle = 80f;

	private void Start() {
		direction = new Vector2(1, 0);
	}

	public bool SeesTarget {
		get {
			Vector2 playerDir = target.transform.position-transform.position;

			if (Vector2.Angle(direction, playerDir) < angle) {
				RaycastHit2D hit = Physics2D.Raycast(transform.position, playerDir, distance);
				if (hit) return hit.transform.name == "Player";
			}
			
			return false;
		}
	}
}
