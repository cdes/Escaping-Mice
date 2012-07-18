using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
	
	public GameObject follow;
	Vector3 temp;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		temp = new Vector3(follow.transform.position.x, transform.position.y, follow.transform.position.z);
		
		
		transform.position = new Vector3(Mathf.Clamp(follow.transform.position.x, -6.6f, 6.6f) , transform.position.y, Mathf.Clamp(follow.transform.position.z, -5f, 5f) );
		
		
	}
}
