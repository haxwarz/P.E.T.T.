using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	private Transform groundCheck;
	private bool grounded = true;
	public float maxspeed = 5f;

	public GameObject gui;

	// Use this for initialization
	void Start () {
		groundCheck = transform.Find("groundCheck");
		gui.SetActive (false);
	
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

		if(Input.GetButtonDown("Fire1")){
			interact();
		}
		
		if(Input.GetButtonDown("Fire2")){
			gui.SetActive(!gui.activeSelf);
		}
	}

	void OnCollisionStay(Collision collisionInfo) {
		if (collisionInfo.gameObject.tag == "platform" && grounded) {
			transform.parent = collisionInfo.transform;
				} else {
						transform.parent = null;
				}

	}

	void interact(){
		RaycastHit hitInfo;
		Vector3 dept = transform.TransformDirection(new Vector3(0,0,1));
		if (Physics.Raycast (transform.position, dept, out hitInfo, 100, 1 << 9)) {
			hitInfo.collider.SendMessageUpwards("interact");
		}
	}
}
