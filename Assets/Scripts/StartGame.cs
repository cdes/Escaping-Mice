using UnityEngine;
using System.Collections;

public class StartGame : MonoBehaviour {
	
	public GameObject usedCamera;
	public GameObject[] story;
	public GameObject firstBoard;
	public GameObject spawnPoint;
	public GameObject player;
	
	bool startPressed = false;
	bool isPirated = false;
	
	// Use this for initialization
	void Start () {
		player.SendMessage("DisableMovement");
		
		
		string url = Application.absoluteURL;
		Debug.Log(url);
		
		if (Application.isWebPlayer) {
	        
	        if(url.StartsWith("http://www.gametako.com/"))
				isPirated = false;
	        
	        
    	
			if (isPirated){
				
            	Application.Quit();
				Application.OpenURL("http://www.gametako.com/");
			}
		}
		else
			isPirated = false;
		
	}
	
	// Update is called once per frame
	void Update () {
		if(!startPressed)
		{
			if(Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow) || 
				Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))
			{
				StartCutsceneSequence();
				startPressed = true;
			}
		}
	}
	
	void StartCutsceneSequence()
	{
		StartCoroutine(Cutscene());
	}
	
	IEnumerator Cutscene()
	{
		Vector3 tempPos2;
		for(int i=0; i<story.Length; i++)
		{
			
			tempPos2 = new Vector3(story[i].transform.position.x, 40f, story[i].transform.position.z);
			
			iTween.MoveTo(usedCamera, tempPos2, 0.5f);
			yield return new WaitForSeconds(4f);
		}
		
		tempPos2 = new Vector3(firstBoard.transform.position.x, 40f, firstBoard.transform.position.z);
		iTween.MoveTo(usedCamera, tempPos2, 0.5f);
		
		
		
		Vector3 tempPos = new Vector3(spawnPoint.transform.position.x, spawnPoint.transform.position.y, spawnPoint.transform.position.z);
		//iTween.MoveTo(other, tempPos, 0f);
		
		

		
		iTween.MoveTo(GameObject.FindWithTag("MainCamera"), new Vector3(spawnPoint.transform.position.x,20f,spawnPoint.transform.position.z), 0.0f);
		yield return new WaitForSeconds(0.1f);
		
		player.SendMessage("PlayFall");
		
		iTween.MoveTo(player,iTween.Hash("position",tempPos,"time",0.5f,"easetype",iTween.EaseType.easeInSine));				

		//iTween.MoveTo(other, tempPos, 0.5f);
		
		yield return new WaitForSeconds(0.5f);
		
		player.SendMessage("PlayLand");
		yield return new WaitForSeconds(0.5f);
		
		player.SendMessage("PlayMove");
		yield return new WaitForSeconds(0.1f);

		
		//other.transform.position = spawnPoint.transform.position;
		
		Debug.Log(spawnPoint.transform.position.ToString());
		
		player.SendMessage("EnableMovement");
		
		
		
		
		
		player.SendMessage("EnableMovement");
	
		

		
		

		
	}
}
