using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {

	private bool levelSelect;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if ( Input.GetMouseButtonDown (0)){ 
			RaycastHit hit; 
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); 
			if ( Physics.Raycast (ray,out hit,10.0f)){
				if (hit.transform.name == "Normal") {

				}
				if (hit.transform.name == "Tester") {
					GameObject.Find ("Normal").GetComponent<SignController> ().MoveUp ();
					GameObject.Find ("Tester").GetComponent<SignController> ().MoveUp ();
					GameObject.Find ("Exit").GetComponent<SignController> ().MoveUp ();
					GameObject.Find ("Level1").GetComponent<SignController> ().MoveDown ();
					GameObject.Find ("Level2").GetComponent<SignController> ().MoveDown ();
					GameObject.Find ("Level3").GetComponent<SignController> ().MoveDown ();
					levelSelect = true;
				}
				if (hit.transform.name == "Exit") {
					Application.Quit ();
				}
				if (hit.transform.name == "Level1") {
					SceneManager.LoadScene (1);
				}
				if (hit.transform.name == "Level2") {
					SceneManager.LoadScene (2);
				}
				if (hit.transform.name == "Level3") {
					SceneManager.LoadScene (3);
				}
			}
		}
		if (Input.GetKeyDown(KeyCode.Escape) && levelSelect)
		{
			levelSelect = false;
			GameObject.Find ("Normal").GetComponent<SignController> ().MoveDown ();
			GameObject.Find ("Tester").GetComponent<SignController> ().MoveDown ();
			GameObject.Find ("Exit").GetComponent<SignController> ().MoveDown ();
			GameObject.Find ("Level1").GetComponent<SignController> ().MoveUp ();
			GameObject.Find ("Level2").GetComponent<SignController> ().MoveUp ();
			GameObject.Find ("Level3").GetComponent<SignController> ().MoveUp ();
		}
	}
}