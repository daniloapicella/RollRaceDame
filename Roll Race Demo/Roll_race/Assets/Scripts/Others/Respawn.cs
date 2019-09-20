using UnityEngine;
using System.Collections;

public class Respawn : MonoBehaviour {
	public Vector3 respawnPoint;

	void OnTriggerEnter (Collider other){
		other.transform.position = respawnPoint;
		other.GetComponent<Rigidbody>().velocity = Vector3.zero;
		other.GetComponent<Rigidbody>().angularVelocity = Vector3.zero; 
	}
}
