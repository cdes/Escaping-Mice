using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {
	
	tk2dAnimatedSprite anim;
	bool isControlable = true;
	bool isMoving = false;
	
	public AudioClip suckedInAudio;
	public AudioClip moveAudio;
	public AudioClip fallAudio;
	public AudioClip landAudio;

	
	
	// Use this for initialization
	void Start () {
		anim = GetComponent<tk2dAnimatedSprite>();
		
	}
	
	void PlaySuckedIn()
	{
		anim.Play("SuckedIn");
		PlaySuckedInSound();
	}
	
	void PlayMove()
	{
		anim.Play("HamsterMove");
	}
	
	void PlayFall()
	{
		anim.Play("Fall");
	}
	
	void PlayLand()
	{
		anim.Play("Land");
	}
	
	void Stop()
	{
		anim.Stop();
	}
	
	// Update is called once per frame
	void Update () {
	
		
			
	}
	
	void FixedUpdate()
	{
		if(isControlable){
			rigidbody.velocity = Vector3.zero;
			
			if(Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow) || 
				Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))
			{
				anim.Play("HamsterMove");
				PlayWalkSound();
				isMoving = true;
			}
			if(!Input.GetKey(KeyCode.UpArrow) && !Input.GetKey(KeyCode.DownArrow) && 
				!Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow))
			{
				anim.Stop();
				StopWalkSound();
				isMoving = false;
			}
			
			if(Input.GetKey(KeyCode.RightArrow)){
				rigidbody.transform.Translate(Time.fixedDeltaTime*10, 0,0);
				transform.localScale = new Vector3(1f,1f,20f);
				if(!isMoving)
				{
					anim.Play("HamsterMove");
					PlayWalkSound();
					isMoving = true;
				}
				
			}
			if(Input.GetKey(KeyCode.LeftArrow)){
				rigidbody.transform.Translate(-Time.fixedDeltaTime*10, 0,0);
				transform.localScale = new Vector3(-1f,1f,20f);
				if(!isMoving)
				{
					anim.Play("HamsterMove");
					PlayWalkSound();
					isMoving = true;
				}			
			}
			if(Input.GetKey(KeyCode.UpArrow)){
				rigidbody.transform.Translate(0, Time.fixedDeltaTime*10,0);
				if(!isMoving)
				{
					anim.Play("HamsterMove");
					PlayWalkSound();
					isMoving = true;
				}
			}
			if(Input.GetKey(KeyCode.DownArrow)){
				rigidbody.transform.Translate(0, -Time.fixedDeltaTime*10,0);
				if(!isMoving)
				{
					anim.Play("HamsterMove");
					PlayWalkSound();
					isMoving = true;
				}
			}
		}
	}
	
	void DisableMovement()
	{
		isControlable = false;
	}
	
	void EnableMovement()
	{
		isControlable = true;
	}
	
	void PlayFallSound()
	{
		
	}
	
	void PlayLandSound()
	{
		
	}
	
	void PlayWalkSound()
	{
		gameObject.audio.clip = moveAudio;
		gameObject.audio.volume = 0.3f;
		gameObject.audio.loop = true;
		gameObject.audio.pitch = Random.Range(0.95f, 1.05f);
		gameObject.audio.Play();
	}
	
	void StopWalkSound()
	{
		gameObject.audio.Stop();
		isMoving = false;
	}
	
	
	void PlaySuckedInSound()
	{
		gameObject.audio.clip = suckedInAudio;
		gameObject.audio.volume = 1f;
		gameObject.audio.loop = false;
		gameObject.audio.Play();
	}
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	


}
