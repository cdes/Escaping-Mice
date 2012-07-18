using UnityEngine;
using System.Collections;

public class BallShadeRotation : MonoBehaviour {
	
	public GameObject ball;
	float prePosX;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if(ball.transform.position.x != prePosX)
		{
			float delta = ball.transform.position.x - prePosX;
			if(Mathf.Abs(delta) > 0.1f){
				if(delta<0)
					transform.Rotate(0f,0f, Time.deltaTime*200);
				else
					transform.Rotate(0f,0f, -Time.deltaTime*200);
			}
		}
		
		prePosX = ball.transform.position.x;
	}
}
