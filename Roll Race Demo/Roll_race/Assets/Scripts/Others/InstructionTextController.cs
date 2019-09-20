using UnityEngine;
using System.Collections;

public class InstructionTextController : MonoBehaviour {
	public float updateTime;

	void Start(){
		StartCoroutine( UpdateText ("Press 'A', 'W', 'D', 'S' \n to move the ball.\n Press Tab for menu") );
	}

	public IEnumerator UpdateText(string text){
		transform.GetComponent<GUIText>().text = text;
		yield return new WaitForSeconds (updateTime);
		transform.GetComponent<GUIText>().text = "";
	}	
}
