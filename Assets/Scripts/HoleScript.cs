using UnityEngine;
using System.Collections;

public class HoleScript : MonoBehaviour {
	
	public GameObject spawnPoint;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnCollisionEnter(Collision collision) {
		if(collision.gameObject.tag == "Player")
		{
			collision.gameObject.SendMessage("DisableMovement");
			StartCoroutine(MoveThenScale(collision.gameObject));
		}
	}
	
	void OnTriggerEnter(Collider other) {
		if(other.gameObject.tag == "Hole")
		{
			
				
		}    
	}
	
	IEnumerator MoveThenScale(GameObject other)
	{
		
		other.SendMessage("StopWalkSound");
		Vector3 temp = gameObject.transform.position;
		iTween.MoveTo(other, new Vector3(temp.x, temp.y+10, temp.z+1), 1f);
		other.SendMessage("PlaySuckedIn");
		other.SendMessage("PlaySuckedInSound");
		
		yield return new WaitForSeconds(1f);
		
		
		//iTween.ScaleTo(gameObject, Vector3.zero, 0.5f);
		
		//yield return new WaitForSeconds(1f);
		
		Vector3 tempPos = new Vector3(spawnPoint.transform.position.x, spawnPoint.transform.position.y+1.2f, spawnPoint.transform.position.z);
		//iTween.MoveTo(other, tempPos, 0f);
		
		

		
		iTween.MoveTo(GameObject.FindWithTag("MainCamera"), new Vector3(spawnPoint.transform.position.x,20f,spawnPoint.transform.position.z), 0.0f);
		yield return new WaitForSeconds(0.1f);
		
		other.SendMessage("PlayFall");
		other.SendMessage("PlayFallSound");
		
		iTween.MoveTo(other,iTween.Hash("position",tempPos,"time",0.5f,"easetype",iTween.EaseType.easeInSine));				

		//iTween.MoveTo(other, tempPos, 0.5f);
		
		yield return new WaitForSeconds(0.5f);
		
		other.SendMessage("PlayLand");
		yield return new WaitForSeconds(0.5f);
		other.SendMessage("PlayLandSound");
		
		
		other.SendMessage("PlayMove");
		yield return new WaitForSeconds(0.1f);

		
		//other.transform.position = spawnPoint.transform.position;
		
		Debug.Log(spawnPoint.transform.position.ToString());
		
		other.SendMessage("EnableMovement");
		
		//iTween.RotateTo(gameObject, new Vector3(45f,0,0), 0.5f);
		//iTween.MoveTo(gameObject, new Vector3(temp.x, temp.y-100, temp.z+1), 1f);
	}
}



