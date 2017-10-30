using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignController : MonoBehaviour {

	private bool move;
	private float stepsLeft, direction;

	// Use this for initialization
	void Start () {
		direction = 0;
		move = false;
		stepsLeft = 0.0f;
	}

	// Update is called once per frame
	void Update () {
		if (move) {
			stepsLeft = 10.0f;
			move = false;
		}
		if (direction != 0) {
			transform.Translate (0.0f, 0.0f, this.direction);
			stepsLeft -= Mathf.Abs (this.direction);
			if (stepsLeft <= 0.0f)
				direction = 0;
		}
	}

	public void MoveUp()
	{
		this.move = true;
		this.direction = -0.5f;
	}

	public void MoveDown()
	{
		this.move = true;
		this.direction = 0.5f;
	}
}
