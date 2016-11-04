using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

	public float speed;

	void FixedUpdate () {
		this.GetComponent<Rigidbody> ().velocity = transform.forward * speed + Physics.gravity;
		Ray moveRay = new Ray (this.transform.position, transform.forward);

		if (Physics.SphereCast (moveRay, 1f, 3f) == true) {
			float rand = Random.value;
			if (rand < 0.5f) {
				this.transform.Rotate (0f, 90f, 0f);
			} else {
				this.transform.Rotate (0f, -90f, 0f);
			}
		}
	}
}
