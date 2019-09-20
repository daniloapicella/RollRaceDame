using UnityEngine;
using System.Collections;

public class TakePlaceBehindPlayer : MonoBehaviour {
	public GameObject cameraReference;
	public float distance;
	public float speed;
	public InstructionTextController commandText;

	void OnTriggerEnter (Collider other){
				if (other.tag == "Player") {
						Physics.gravity = new Vector3 (0, -20, 0);
						StartCoroutine( commandText.UpdateText("press 'Space' to jump") );		
					}
		}

	void OnTriggerStay(Collider other){
		if (other.tag == "Player")
						cameraReference.transform.position = Vector3.Lerp (cameraReference.transform.position,
			                                                   			   new Vector3(cameraReference.transform.position.x, cameraReference.transform.position.y,
			                                                  			   			   other.transform.position.z + distance),
			                                                   			   Time.deltaTime * speed);
	}
}
