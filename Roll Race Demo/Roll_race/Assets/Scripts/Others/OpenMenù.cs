using UnityEngine;
using System.Collections;

public class OpenMenù : MonoBehaviour {
	public GameObject menu;

	void LateUpdate(){
		if (Input.GetKey ("tab"))     
					menu.SetActive(true);
	}

	public void Resume(){
		menu.SetActive (false);
		Time.timeScale = 1;
	}

	public void Quit(){
		Application.LoadLevel("Main Menu");
	}
}
