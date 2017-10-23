using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	private Vector3 solutionRotation;
	private Vector3 mousePos, prevMousePos;
	private bool playing;
	public float precision;
	public int objSelection;

	void Start () {
		solutionRotation = transform.rotation.eulerAngles;
		mousePos = new Vector3 (0, 0, 0);
		prevMousePos = new Vector3 (0, 0, 0);
		playing = true;
		objSelection = 0;
		if (tag == "Stupid")
			transform.Rotate (0, Random.Range(45, 250), 0, Space.World);
		else if (tag == "Easy")
			transform.Rotate (0, Random.Range(45, 250), Random.Range(45, 250), Space.World);
		else if (tag == "Normal1" || tag == "Normal2")
		{
			transform.Rotate (0, Random.Range(45, 250), Random.Range(45, 250), Space.World);
			transform.Translate (Random.Range (-2, 2), Random.Range (-2, 2), 0, Space.World);
		}
	}

	void Update () {
		if (Input.GetKeyDown (KeyCode.Alpha1))
			objSelection = 0;
		if (Input.GetKeyDown (KeyCode.Alpha2))
			objSelection = 1;
		if (Input.GetKey(KeyCode.Mouse0)) {
			mousePos = Input.mousePosition;
		}
		if (Mathf.Abs (transform.rotation.eulerAngles.z - solutionRotation.z) <= precision &&
			Mathf.Abs(transform.rotation.eulerAngles.x - solutionRotation.x) <= precision &&
			Mathf.Abs(transform.rotation.eulerAngles.y - solutionRotation.y) <= precision && 
			GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<CameraController> ().positionChecked && !(Input.GetKey(KeyCode.Mouse0))) {
			playing = false;
			if (transform.rotation.eulerAngles.z - solutionRotation.z <= 0.05f)
				transform.Rotate (0, 0, 0.05f);
			else
				transform.Rotate (0, 0, -0.05f);
			if (transform.rotation.eulerAngles.x - solutionRotation.x <= 0.05f)
				transform.Rotate (0.05f, 0, 0);
			else
				transform.Rotate (-0.05f, 0, 0);
			if (transform.rotation.eulerAngles.y - solutionRotation.y <= 0.05f)
				transform.Rotate (0, 0.05f, 0);
			else
				transform.Rotate (0, -0.05f, 0);
		}
		if (Input.GetKey (KeyCode.Mouse0) && playing && !(Input.GetKey(KeyCode.LeftControl)) && !(Input.GetKey(KeyCode.LeftShift))) {
			if ((objSelection == 0 && tag == "Normal1") || (objSelection == 1 && tag == "Normal2"))
				transform.Rotate (0, (mousePos.x - prevMousePos.x), 0, Space.World);
			if (tag == "Stupid" || tag == "Easy")
				transform.Rotate (0, (mousePos.x - prevMousePos.x), 0, Space.World);
		}
		if ((tag == "Easy" || tag == "Normal1" || tag == "Normal2") && Input.GetKey(KeyCode.LeftControl) && Input.GetKey(KeyCode.Mouse0)) {
			if ((objSelection == 0 && tag == "Normal1") || (objSelection == 1 && tag == "Normal2"))
				transform.Rotate ((mousePos.y - prevMousePos.y), 0, 0, Space.World);
			if (tag == "Easy")
				transform.Rotate ((mousePos.y - prevMousePos.y), 0, 0, Space.World);
		}
		if ((tag == "Normal1" || tag == "Normal2") && Input.GetKey (KeyCode.LeftShift) && Input.GetKey (KeyCode.Mouse0)) {
			if ((objSelection == 0 && tag == "Normal1") || (objSelection == 1 && tag == "Normal2"))
				transform.Translate ((mousePos.x - prevMousePos.x) / 100, (mousePos.y - prevMousePos.y) / 100, 0, Space.World);
		}
		prevMousePos = mousePos;
	}
}
