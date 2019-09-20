using UnityEngine;
using System.Collections;

public class ObstacleSpawner : MonoBehaviour {
	public GameObject prefab, player;
	Vector3 center;
	float roof, floor, leftWall, rightWall;
	public float spawnPoint, timeToSpawn, stopSpawningPosition;
	GameObject obstacle, obstacles;

	void Awake(){
				roof = transform.Find ("Roof").position.y;											
				floor = transform.Find ("Floor").position.y;
				leftWall = transform.Find ("Left Wall").position.x;
				rightWall = transform.Find ("Right Wall").position.x;
				center = new Vector3 ((rightWall + leftWall) / 2, (floor + roof) / 2, spawnPoint);	//tunnel's center
				obstacles = new GameObject ();
				obstacles.name = "Obstacles";
		}
	
	void Start(){
		StartCoroutine ( Generate() );
	}

	void LateUpdate(){
		if (player.transform.position.z < stopSpawningPosition)
														Destroy (this);
	}

	IEnumerator Generate(){
		for(;;){
			if (Random.Range (1, 100) > 50)									//having center's position means be dine to be an exeption - > equals to normal obstacle, < rotating or expetion
				obstacle = Instantiate (prefab, new Vector3 (center.x, Random.Range (roof, floor), spawnPoint), Quaternion.identity) as GameObject;
			else
				obstacle = Instantiate (prefab, new Vector3 (center.x, center.y, spawnPoint), Quaternion.identity) as GameObject;
			obstacle.transform.parent = obstacles.transform;
			obstacle.name = "Obstacle";
			yield return new WaitForSeconds (timeToSpawn); 
		}
	}


	public Vector3 GetCenter(){
			return(center);
		}


	public float[] GetTunnelLimits(){
		return (new float[]{leftWall, rightWall, floor, roof});
	}
}