using UnityEngine;
using System.Collections;

public class TextController : MonoBehaviour {
	public GUIText timeText;
	public GUIText finalText;
	bool end;
	public int visualizingInterval;
	
	void Start(){
		end = false;
		StartCoroutine (VisualizeFinalText ());
	}

	void OnTriggerEnter(Collider other){
		if(other.tag == "Player") end = true;
	}

	IEnumerator VisualizeFinalText(){
		while (!end) {
						yield return new WaitForSeconds (1);
						timeText.text = "Time: " + (int)Time.time;
				}
		finalText.text = "Ended in" + timeText.text;
		timeText.text = "";
		yield return new WaitForSeconds(visualizingInterval);
		finalText.text = "Thanks for have been playing to";
		yield return new WaitForSeconds(visualizingInterval);
		finalText.text = "Roll Race Demo";
		yield return new WaitForSeconds(visualizingInterval);
		finalText.text = "Game Created By: \t Danilo Apicella";
	}
}
