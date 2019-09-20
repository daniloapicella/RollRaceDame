using UnityEngine;
using System.Collections;

public class PlayerPositionPrinter : MonoBehaviour { //there are more then one pinwheel. A script reference is needed
	GameObject player, playerPositionPrint;
	Collider colliderPrint;
	PlayerRepulse playerRepulse;
	public float printingTime;
	bool changeDirection;

	void Awake(){
		playerPositionPrint = new GameObject ();								//this is a reference object and a photo of the player position
		playerPositionPrint.name = "Repulse Reference";
		colliderPrint = playerPositionPrint.AddComponent<SphereCollider>() as SphereCollider;
		colliderPrint.isTrigger = true;	//if the walls collides with the playerPositionPrint before then player, it is moving around the pinwheel				
		changeDirection = false;	    //and the force must be diverted: playerPoisitonPrint is placed behind the wall, the player in front of
	}

	void OnTriggerEnter(Collider other){ //the penwheel is placed inside a box colider that delimitates the zone. Don't consider it.
		if (other.tag == "Player") { 
			colliderPrint.transform.localScale = other.transform.localScale;
						player = other.gameObject;
						StartCoroutine(PrintPlayer());
		}
	}

	IEnumerator PrintPlayer(){
		for(;;) {
						playerPositionPrint.transform.position = player.transform.position; //instant print
						changeDirection = false;
						yield return new WaitForSeconds (printingTime); //set to 0.3
				}
	}

	public bool GetChangeDirection(){
		return(changeDirection); //changeDirection must be set to false, cause of I want the collision player would have got a single instant before
	}

	public Vector3 GetPlayerPositionPrint(){
		return(playerPositionPrint.transform.position);  //needed to define the direction
	}  }
