using UnityEngine;
using System.Collections;

public class PlayerRepulse : MonoBehaviour {
	public GameObject player;
	bool changeDirection;
	public PlayerPositionPrinter playerPositionPrinter;
	public float repulse;
	
	void Update(){
		Debug.DrawRay (player.transform.position, player.GetComponent<Rigidbody>().velocity, Color.blue);
		changeDirection = playerPositionPrinter.GetChangeDirection ();  //changeDirection update
	}

	
	void OnCollisionEnter(Collision collision){
			if (collision.gameObject.name == "Repulse Reference")     //if it's the player position print 
													changeDirection = true;     
				else
					if (!changeDirection) {	//first touch with the player	
						//Debug.DrawRay (collision.contacts [0].point, Vector3.Reflect (collision.contacts [0].point - playerPositionPrinter.GetPlayerPositionPrint (), collision.contacts [0].normal), Color.red);
						player.GetComponent<Rigidbody>().velocity = Vector3.Reflect (collision.contacts [0].point - playerPositionPrinter.GetPlayerPositionPrint (), collision.contacts [0].normal) * repulse;
						} else {//first touch with the Repulse Reference
								Debug.DrawRay (collision.contacts [0].point, Vector3.Reflect (playerPositionPrinter.GetPlayerPositionPrint () - player.transform.position, collision.contacts [0].normal), Color.red);
								player.GetComponent<Rigidbody>().velocity = Vector3.Reflect (playerPositionPrinter.GetPlayerPositionPrint () - player.transform.position, collision.contacts [0].normal) * repulse;
								}
		}
}