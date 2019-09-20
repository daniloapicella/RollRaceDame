using UnityEngine;
using System.Collections;

public class TakePlaceOnLeft : MonoBehaviour {
	Vector3 offset;	
	public GameObject cameraReference;
	public bool lookPlayer;
	Vector3 startingCameraPosition;
	bool increaseGravity;
	public float gravity;

	void Awake(){
		startingCameraPosition = cameraReference.transform.position;
		increaseGravity = true;
	}

	void OnTriggerEnter(Collider other){
		if (other.tag == "Player") {
						cameraReference.transform.position = startingCameraPosition;
						offset = cameraReference.transform.position - other.transform.position;
						}
		}

	void OnTriggerStay(Collider other){
		if (other.tag == "Player") {
						if(increaseGravity){
											Physics.gravity = new Vector3(0, -gravity, 0);
											increaseGravity = false;
											}
			if(lookPlayer)cameraReference.transform.LookAt(other.transform);
						cameraReference.transform.position = other.transform.position + offset;
				}
	}
}
