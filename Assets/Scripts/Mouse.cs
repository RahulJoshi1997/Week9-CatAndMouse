using UnityEngine;
using System.Collections;

public class Mouse : MonoBehaviour {

	Cat catScript;
	public Transform cat;
	AudioSource mouseSounds;

	void Start () {
		catScript = GameObject.Find ("Cat").GetComponent<Cat> ();

		mouseSounds = this.GetComponent<AudioSource> ();
	}

	void Update () {
		//Make the invisible puddle of blood follow the mouse around
		Vector3 bloodPos = this.transform.position;
		//The blood, to look good, has it's own y position that isn't the same as the yPos of the mouse
		bloodPos.y = -0.03f;
		catScript.blood.transform.position = bloodPos;
	}

	void FixedUpdate () {
		Vector3 directionToCat = new Vector3 ();
		directionToCat = cat.position - this.transform.position;

		//Within the mouse's 130 degree field of view, check if the mouse can see the cat
		//within a 100 meters by casting a ray. If that ray hits the cat, then make the mouse run away
		//in the exact opposite direction
		if (Vector3.Angle (this.transform.forward, directionToCat) <= 130f) {
			Ray mouseRay = new Ray (this.transform.position, directionToCat);
			RaycastHit mouseRayHitInfo;

			if (Physics.Raycast (mouseRay, out mouseRayHitInfo, 100f) == true) {
				if (mouseRayHitInfo.collider.tag == "Cat" && mouseRayHitInfo.distance < 15f) {
					this.GetComponent<Rigidbody> ().AddForce (-directionToCat.normalized * 10000f);

					if (mouseSounds.isPlaying == false) {
						mouseSounds.Play ();
					}
				}
			}
		}
	}
}
