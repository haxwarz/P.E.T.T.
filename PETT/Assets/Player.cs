using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	private Transform groundCheck;
	private bool grounded = true;

	// Use this for initialization
	void Start () {
		groundCheck = transform.Find("groundCheck");
	
	}
	
	// Update is called once per frame
	void Update () {

		grounded = Physics.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));

		if(Input.GetKey(KeyCode.RightArrow)){
			rigidbody.velocity = new Vector2(2f,rigidbody.velocity.y);
		}
		
		if(Input.GetKey(KeyCode.LeftArrow)){
			rigidbody.velocity = new Vector2(-2f,rigidbody.velocity.y);
		}
		
		if(Input.GetKeyDown(KeyCode.UpArrow) && grounded){
			rigidbody.AddForce(new Vector2(0f,250f));
		}
	
	}
}
