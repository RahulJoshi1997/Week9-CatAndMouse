using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public GameObject wall;

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.R)) {
			SceneManager.LoadScene ("CatAndMouse");
		}

		if (Input.GetKeyDown (KeyCode.Q)) {
			Destroy (wall);
		}
	}
}
