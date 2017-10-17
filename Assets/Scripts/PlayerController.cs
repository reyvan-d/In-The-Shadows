using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	private Vector3 solutionRotation;
	private Vector3 mousePos, prevMousePos;
	private bool playing;
	public float precision;
	// Use this for initialization
	void Start () {
		solutionRotation = transform.rotation.eulerAngles;
		mousePos = new Vector3 (0, 0, 0);
		prevMousePos = new Vector3 (0, 0, 0);
		playing = true;
		transform.Rotate (0, 0, 90);
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.Mouse0)) {
			mousePos = Input.mousePosition;
		}
		if (Mathf.Abs (transform.rotation.eulerAngles.z - solutionRotation.z) <= precision) {
			playing = false;
			if (transform.rotation.eulerAngles.z - solutionRotation.z <= 0.05f)
				transform.Rotate (0, 0, 0.05f);
			else
				transform.Rotate (0, 0, -0.05f);
		}
		if (Input.GetKey (KeyCode.Mouse0) && playing) {
			transform.Rotate (0, 0, (mousePos.x - prevMousePos.x));
		}
		prevMousePos = mousePos;
	}
}
