using UnityEngine;
using System.Collections;

public class Mouse : MonoBehaviour {

	public Transform cat;

	void FixedUpdate () {
		Vector3 directionToCat = new Vector3 ();
		directionToCat = cat.position - this.transform.position;

		//If the mouse isn't moving exactly away from the cat, check if the mouse can see the cat
		//within a 100 meters by casting a ray. If that ray hits the cat, then make the mouse run away
		//in the exact opposite direction
		if (Vector3.Angle (this.transform.forward, directionToCat) <= 130f) {
			Ray mouseRay = new Ray (this.transform.position, directionToCat);
			RaycastHit mouseRayHitInfo;

			if (Physics.Raycast (mouseRay, out mouseRayHitInfo, 100f) == true) {
				if (mouseRayHitInfo.collider.tag == "Cat" && mouseRayHitInfo.distance < 10f) {
					this.GetComponent<Rigidbody> ().AddForce (-directionToCat.normalized * 10000f);
				}
			}
		}
	}
}
