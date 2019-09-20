using UnityEngine;
using System.Collections;

public class CubeMultiplier : MonoBehaviour {
	public GameObject prefab;
	public float width, height;
	GameObject brick,wall;
	public GameObject parent;


	void Awake(){
		wall = new GameObject();
		wall.name = "Wall";
		if (parent != null)
						wall.transform.parent = parent.transform;
		for (int i = 0; i < height; i++)
						for (int j = 1; j < width; j++) {
								brick = Instantiate (prefab, new Vector3 (transform.position.x + j, transform.position.y + i, transform.position.z), Quaternion.identity) as GameObject;
								brick.name = "Brick";
								brick.transform.parent = wall.transform;				
							 }
	}
}
