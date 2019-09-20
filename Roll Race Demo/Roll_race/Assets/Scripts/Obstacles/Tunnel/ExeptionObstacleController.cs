using UnityEngine;
using System.Collections;

public class ExeptionObstacleController : MonoBehaviour {
	float[] tunnelLimits;			//limits = (leftWall, rightWall, floor, roof)
	float direction;
	Vector3 center;
	public float speed;
	public int timesForSide;
	public float rotatingSpeed;
	int cont;
	bool up,stop;
	Quaternion newRotation;
	int angle;
	
	void Start(){
		tunnelLimits = GameObject.Find ("Tunnel").GetComponent<ObstacleSpawner> ().GetTunnelLimits();
		center = GameObject.Find ("Tunnel").GetComponent<ObstacleSpawner> ().GetCenter();
		direction = tunnelLimits [1];
		transform.rotation = Quaternion.Euler (0, 0, 90);
		angle = 90;
		stop = false; cont = 0;
	}
	
	void Update(){
		center = new Vector3 (center.x, center.y, transform.position.z);
		if (!stop) {														//if translation has not been stopped
			if (cont == timesForSide) change ();					//change direction
			if(up)
				MoveUpDown ();
			else  
				MoveLeftRight ();
			
		} else {
			transform.position = Vector3.MoveTowards(transform.position, center, speed * Time.deltaTime);			
			if (transform.position == center)			
				if(transform.rotation != newRotation)
					transform.rotation = Quaternion.RotateTowards(transform.rotation, newRotation, rotatingSpeed * Time.deltaTime);
			else stop = false;
		}				
		
	}
	
	void change (){
		up = (direction == tunnelLimits [0]) ? true : false;					//limits = (leftWall, rightWall, floor, roof)
		cont = 0;
		stop = true;
		angle = angle + 90;
		newRotation = Quaternion.Euler (0, 0, angle);
	}
	
	void MoveLeftRight(){
		if (transform.position.x == tunnelLimits [1]) {
			direction = tunnelLimits [0];
			cont++;
		} else
			if ( (transform.position.x == tunnelLimits [0]) || (direction == tunnelLimits [3]) ) direction = tunnelLimits [1];
		transform.position = Vector3.MoveTowards(transform.position, new Vector3 (direction, transform.position.y, transform.position.z), Time.deltaTime * speed);
	}
	
	void MoveUpDown(){		
		if (transform.position.y == tunnelLimits [2]) {
			direction = tunnelLimits [3];
			cont++;
		}
		else
			if ( (transform.position.y == tunnelLimits [3]) || (direction == tunnelLimits [0]) ) direction = tunnelLimits [2];
		transform.position = Vector3.MoveTowards(transform.position, new Vector3 (transform.position.x, direction, transform.position.z), Time.deltaTime * speed);
	}
}
