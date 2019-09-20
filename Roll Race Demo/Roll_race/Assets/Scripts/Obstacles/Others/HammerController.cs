using UnityEngine;
using System.Collections;

public class HammerController : MonoBehaviour {

	Vector3 pivot;
	public float spaceSwinging;
	float direction;
	Vector3 firstExtreme, secondExtreme;
	public string side;

	void Start(){
		pivot = transform.Find ("Pivot").position;				
		if (side == "left")																			//initialization
				{	
					transform.RotateAround(Vector3.forward, pivot, spaceSwinging/2);							//start from. Inizialization from the central axis
					secondExtreme = transform.position;
					transform.RotateAround(Vector3.forward, pivot, -spaceSwinging);
					firstExtreme = transform.position;
				}
			else{
					transform.RotateAround(Vector3.forward, pivot, -spaceSwinging/2);
					firstExtreme = transform.position;
					transform.RotateAround(Vector3.forward, pivot, spaceSwinging);
					secondExtreme = transform.position;
				}
		direction = 1;
	}

	void Update(){
		if (transform.position.x < secondExtreme.x) {												//if it's before the center
			direction = -1;																
				}else if (transform.position.x > firstExtreme.x) {
						direction = 1;
				}
		transform.RotateAround(Vector3.forward, pivot, direction * spaceSwinging * Time.deltaTime);
	}
}