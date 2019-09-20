using UnityEngine;
using System.Collections;

public class Accellerator : MonoBehaviour {
	public float speed;


	void OnTriggerStay(Collider other){
		if (other.tag == "Player") 
						other.GetComponent<Rigidbody>().AddForce (other.GetComponent<PlayerController> ().movement * speed);
	}

}
