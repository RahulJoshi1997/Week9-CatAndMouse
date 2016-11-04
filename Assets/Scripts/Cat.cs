using UnityEngine;
using System.Collections;

public class Cat : MonoBehaviour {

	public Transform mouse;
	public GameObject blood;

	AudioSource catSounds;
	public AudioClip eat;

	void Start () {
		catSounds = this.GetComponent<AudioSource> ();
	}

	void FixedUpdate () {
		if (mouse == null) {
			return;
		}

		Vector3 directionToMouse = new Vector3 ();
		directionToMouse = mouse.position - this.transform.position;

		//Within the cat's 30 degree field of view, check if the cat can see the mouse
		//within a 100 meters by casting a ray. If that ray hits the mouse, then make the cat run
		//straight towards the mouse.
		if (Vector3.Angle (this.transform.forward, directionToMouse) < 30f) {
			Ray catRay = new Ray (this.transform.position, directionToMouse);
			RaycastHit catRayHitInfo;

			if (Physics.Raycast (catRay, out catRayHitInfo, 100f) == true) {
				if (catRayHitInfo.collider.tag == "Mouse" && catRayHitInfo.distance < 20f) {
					if (catRayHitInfo.distance <= 5f) {
						catSounds.clip = eat;
						catSounds.Play ();

						Destroy(mouse.gameObject);
						blood.SetActive(true);//Make blood visible
					} else {
						if (catSounds.isPlaying == false) {
							catSounds.Play ();
						}

						this.GetComponent<Rigidbody> ().AddForce (directionToMouse.normalized * 1000f);
					}
				}
			}
		}
	}
}
