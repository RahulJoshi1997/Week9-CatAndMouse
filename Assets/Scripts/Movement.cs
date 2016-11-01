using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

	void FixedUpdate () {
		this.GetComponent<Rigidbody> ().velocity = transform.forward * 10f + Physics.gravity;
		Ray moveRay = new Ray ();
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
