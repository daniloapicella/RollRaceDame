using UnityEngine;
using System.Collections;

public class PinwheelAscensor : MonoBehaviour {
	Vector3 lowPosition, highPosition,direction;
	public float hight, speed, waitingTime;
	public string startingDirection;
	bool stop, playerTouched;
	GameObject player;

	void Awake(){
		stop = false;
		if (startingDirection == "up") {  //to define the starting direction
						lowPosition = transform.position;
						highPosition = new Vector3 (transform.position.x, transform.position.y + hight, transform.position.z);
						direction = highPosition;
					} 
		else {
				lowPosition = new Vector3(transform.position.x, transform.position.y - hight, transform.position.z);
				highPosition = transform.position;
				direction = lowPosition;
				}
	}

	void FixedUpdate(){	
		if (!stop) {
					if (Vector3.Distance(transform.position, highPosition) < 1) {  
												direction = lowPosition;
												StartCoroutine (Wait ());
							} else if (Vector3.Distance(transform.position, lowPosition) < 1) {
								direction = highPosition;
								StartCoroutine (Wait ());
							}
					transform.position = Vector3.MoveTowards (transform.position, direction, speed * Time.deltaTime);
					if (playerTouched) 
									player.transform.position = Vector3.MoveTowards (player.transform.position, direction + Vector3.up, speed * Time.deltaTime);
				}
	}

	IEnumerator Wait(){
		stop = true;
		yield return new WaitForSeconds (waitingTime);
		stop = false;
	}

	void OnTriggerEnter(Collider other){
		if (other.tag == "Player") {
						player = other.gameObject;
						playerTouched = true;
				}
	}

	void OnTriggerExit(Collider other){
		if (other.tag == "Player")
					playerTouched = false;
	}
}
