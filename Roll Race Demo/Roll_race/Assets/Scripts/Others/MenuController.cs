using UnityEngine;
using System.Collections;

public class MenuController : MonoBehaviour {

	public void Play(){
		Application.LoadLevel ("Level 1");
	}

	public void Quit(){
		Application.Quit ();
	}
}
