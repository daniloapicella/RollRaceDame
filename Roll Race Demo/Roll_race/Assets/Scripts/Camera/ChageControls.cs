using UnityEngine;
using System.Collections;

public class ChageControls : MonoBehaviour {
	public bool moveForward, moveLeft;
	int allow1, allow2;
	public float timeToChange;

	void Awake(){
		allow1 = (moveForward) ? 1 : 0;
		allow2 = (moveLeft) ? 1 : 0;
	}

	void OnTriggerEnter( Collider other){
		if (other.tag == "Player")
				other.GetComponent<PlayerController>().GetAxisExternally("Vertical", "Horizontal", -1 * allow1, 1 * allow2);	//1 -1 decide what changing
	}

	void OnTriggerExit( Collider other){
		if(other.tag == "Player")
			StartCoroutine( ChangeControls(other.GetComponent<PlayerController>() ) );
	}

	IEnumerator ChangeControls(PlayerController player){
		yield return new WaitForSeconds (timeToChange);				//for making ball intuitive to control
		player.GetAxisExternally("Horizontal", "Vertical", -1, -1);			
	}
}
