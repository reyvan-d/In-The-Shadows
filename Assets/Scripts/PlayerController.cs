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
		if (tag == "Stupid")
			transform.Rotate (0, 0, 90);
		else if (tag == "Easy")
			transform.Rotate (0, 90, 90);
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.Mouse0)) {
			mousePos = Input.mousePosition;
		}
		if (Mathf.Abs (transform.rotation.eulerAngles.z - solutionRotation.z) <= precision &&
			Mathf.Abs(transform.rotation.eulerAngles.x - solutionRotation.x) <= precision &&
			Mathf.Abs(transform.rotation.eulerAngles.y - solutionRotation.y) <= precision && !(Input.GetKey(KeyCode.Mouse0))) {
			playing = false;
			if (transform.rotation.eulerAngles.z - solutionRotation.z <= 0.05f)
				transform.Rotate (0, 0, 0.05f);
			else
				transform.Rotate (0, 0, -0.05f);
			if (transform.rotation.eulerAngles.x - solutionRotation.x <= 0.05f)
				transform.Rotate (0, 0, 0.05f);
			else
				transform.Rotate (0, 0, -0.05f);
			if (transform.rotation.eulerAngles.y - solutionRotation.y <= 0.05f)
				transform.Rotate (0, 0, 0.05f);
			else
				transform.Rotate (0, 0, -0.05f);
		}
		if (Input.GetKey (KeyCode.Mouse0) && playing && !(Input.GetKey(KeyCode.LeftControl))) {
			transform.Rotate (0, 0, (mousePos.x - prevMousePos.x));
		}
		if ((tag == "Easy" || tag == "Normal") && Input.GetKey(KeyCode.LeftControl) && Input.GetKey(KeyCode.Mouse0)) {
			transform.Rotate (0, (mousePos.y - prevMousePos.y), 0);
		}
		prevMousePos = mousePos;
	}
}
