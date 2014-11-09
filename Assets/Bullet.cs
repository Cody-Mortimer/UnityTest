using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	public AudioClip cowSound;

	// Use this for initialization
	void Start () {
		renderer.enabled = false;	//Makes the object invisible
	}
	
	// Update is called once per frame
	void Update () {
		//Get main input
		if (Input.GetButton("space")) 
		{
			renderer.enabled = true;	//Makes the object visible
			//Play the ray sound
			audio.Play();
		}

		if(renderer.enabled = true)
		{
			transform.position += Vector3.down * (Time.deltaTime * 2);
		}

		//Check for out of bounds
		if (this.transform.position.y < -1.5)
		{
			transform.position = new Vector2(0.08658695f, 0.1924166f);	//Return bullet to original position
			renderer.enabled = false;
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.name == "cow(Clone)")
		{
			AudioSource.PlayClipAtPoint(cowSound, transform.position);
			//Destroy the cow
			Destroy(other.gameObject);
			transform.position = new Vector2(0.08658695f, 0.1924166f);	//Return bullet to original position
			renderer.enabled = false;
		}
	}
}
