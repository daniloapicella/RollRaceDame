using UnityEngine;
using System.Collections;

public class ObstacleController : MonoBehaviour {
	public float zMax;
	public float speed;
	public float thrust;
	Vector3 center;
	float roofY;
	ObstacleSpawner tunnel;


	void Awake(){
		tunnel = GameObject.Find ("Tunnel").GetComponent<ObstacleSpawner> ();
		center = tunnel.GetCenter ();
		roofY = tunnel.GetTunnelLimits() [3];
	}

	void Start(){
		if (transform.position.y == tunnel.GetCenter ().y) {
						if (Random.Range (0, 100) < 50) 													//<50 means being dine to be an exeption
								transform.GetComponent<ExeptionObstacleController> ().enabled = true;
						else
								transform.GetComponent<ObstacleRotator> ().enabled = true;
		}else {
			float playerScaleY = GameObject.FindWithTag("Player").transform.lossyScale.y;			//to not have an obstacle impossibile to avoid
			if ( (transform.position.y > roofY + playerScaleY / 2) && (transform.position.y < roofY + playerScaleY) )
				transform.position += new Vector3(0, playerScaleY + 80, 0);  //just over the player
			}
		}
	
	void Update(){
					transform.position += Vector3.forward * Time.deltaTime * speed;
					if (transform.position.z > zMax) Destroy (gameObject, 0);			//stop to spwan = destroy this script;
		}
	
	void OnTriggerEnter(Collider other){
		if (other.tag == "Player")
				if (other.GetComponent<Rigidbody>().velocity.z < 0)
						other.GetComponent<Rigidbody>().velocity += Vector3.forward * thrust; //other.rigidbody.AddForce (Vector3.forward * thrust);
					else
						other.GetComponent<Rigidbody>().AddForce (Vector3.back * thrust * 2);
	}
}