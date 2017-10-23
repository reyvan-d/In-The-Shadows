using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public bool positionChecked;
	public float positionPrecision;
	private Vector3 pos1, pos2;

	void Start () {
		if (GameObject.Find("logo-2"))
			positionChecked = false;
		else
			positionChecked = true;
	}

	void Update () {
		if (!(positionChecked))
		{
			pos1 = GameObject.FindGameObjectWithTag ("Normal1").transform.position;
			pos2 = GameObject.FindGameObjectWithTag ("Normal2").transform.position;
			if ((Mathf.Abs (pos1.x - pos2.x) <= 3.8 + positionPrecision && Mathf.Abs (pos1.x - pos2.x) >= 3.8 - positionPrecision && pos1.x < pos2.x) &&
			    (Mathf.Abs (pos1.y - pos2.y) <= 0.65 + positionPrecision && Mathf.Abs (pos1.y - pos2.y) >= 0.65 - positionPrecision && pos1.y < pos2.y))
				positionChecked = true;
			else
				positionChecked = false;
		}

	}
}
