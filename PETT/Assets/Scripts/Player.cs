using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	private Transform groundCheck;
	private bool grounded = true;
	public float maxspeed = 5f;

	// Use this for initialization
	void Start () {
		groundCheck = transform.Find("groundCheck");
	
	}
	
	// Update is called once per frame
	void Update () {

		grounded = Physics.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));

		if(Input.GetKey(KeyCode.RightArrow)){
			if(rigidbody.velocity.x < maxspeed){
				rigidbody.AddForce(new Vector2(15f,0f));
			}
		}
		
		if(Input.GetKey(KeyCode.LeftArrow)){
			if(rigidbody.velocity.x > (maxspeed *-1)){
				rigidbody.AddForce(new Vector2(-15f,0f));
			}
		}
		
		if(Input.GetKeyDown(KeyCode.UpArrow) && grounded){
			rigidbody.AddForce(new Vector2(0f,250f));
		}
	
	}
}
