using UnityEngine;
using System.Collections;

public class ObstacleRotator : MonoBehaviour {

	void Update(){
		transform.Rotate (Vector3.forward);
	}
}
