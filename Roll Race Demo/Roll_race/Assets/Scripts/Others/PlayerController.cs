using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public int speed;
	public int jumpSpeed;
	public Vector3 movement;
	GameObject playerFollower;                     //to allow the camera following the player
	Vector3 offset;
	public CameraController camera;
	string side1, side2;
	int sign1, sign2;
	
	void Awake(){
		playerFollower = new GameObject();											//camera's reference created in scene
		playerFollower.name = "Player Follower";
		offset = camera.transform.position - transform.position;                  //distance between camera and player
		playerFollower.transform.position = transform.position + offset;               //effective camera's position
		playerFollower.transform.rotation = camera.transform.rotation;					
		camera.ChangeVisual (playerFollower);									//visual inatialization
		side1 = "Horizontal";
		side2 = "Vertical";
		sign1 = -1; sign2 = -1;
	}
	
	void FixedUpdate(){
		movement = new Vector3 (sign1 * Input.GetAxis (side1), 0.0F, sign2 * Input.GetAxis (side2) );			
		GetComponent<Rigidbody>().AddForce (movement * speed);
		playerFollower.transform.position = transform.position + offset;               
	}
	
	void OnTriggerEnter(Collider other){
		if (other.name == "Change Visual Mesh")
					camera.ChangeVisual (other.transform.Find ("Camera Reference").gameObject);				//camera's reference within that zone
	}
	
	void OnTriggerExit(Collider other){
	    if(other.name == "Change Visual Mesh")
					camera.ChangeVisual (playerFollower);													//default camera's reference
	}
	
	void OnTriggerStay(Collider Other){
		if (Other.tag == "Accellerator")  GetComponent<Rigidbody>().AddForce (2 * movement * speed);              
		
		if (Other.tag == "ActiveJumpBase") 
			if( Input.GetKey("space") )	GetComponent<Rigidbody>().AddForce(Vector3.up * jumpSpeed * speed);
	}	

	public void GetAxisExternally(string side1, string side2, int sign1, int sign2){
		this.side1 = side1;
		this.side2 = side2;
		this.sign1 = sign1;
		this.sign2 = sign2;
	}
}
