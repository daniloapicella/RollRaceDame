using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
	GameObject visual;
	public float speed;
	
	
	void FixedUpdate(){
		transform.position = Vector3.Lerp(transform.position, visual.transform.position , Time.deltaTime * speed);
		transform.rotation = Quaternion.Lerp(transform.rotation, visual.transform.rotation, Time.deltaTime * speed);	
	}
	
	
	public void ChangeVisual(GameObject visual){
		this.visual = visual;												//the visual\camera's reference gained by the player's script
	}
}
