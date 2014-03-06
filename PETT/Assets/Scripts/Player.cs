using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	private Transform groundCheck;
	private bool grounded = false;
	private bool movable = true;

	public float maxspeed = 5f;
	public float jumpPower = 250f;

	public Vector3 checkpoint;

	// Use this for initialization
	void Start () {
		groundCheck = transform.Find("groundCheck");
	
	}
	
	// Update is called once per frame
	void Update () {

		grounded = Physics.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));

		if (Physics.Linecast (transform.position, groundCheck.position, 1 << LayerMask.NameToLayer ("OffWorld"))) {
			this.transform.position = checkpoint;
			rigidbody.velocity=new Vector2(0f,0f);
		}

		if (Physics.Linecast (transform.position, groundCheck.position, 1 << LayerMask.NameToLayer ("Checkpoint"))) {
			checkpoint = this.transform.position;
		}

		if(Input.GetKey(KeyCode.RightArrow) && movable){
			if(rigidbody.velocity.x < maxspeed){
				rigidbody.AddForce(new Vector2(15f,0f));
			}
			else{
				rigidbody.velocity=new Vector2(maxspeed, rigidbody.velocity.y);
			}
		}
		
		if(Input.GetKey(KeyCode.LeftArrow) && movable){
			if(rigidbody.velocity.x > (-maxspeed)){
				rigidbody.AddForce(new Vector2(-15f,0f));
			}
			else{
				rigidbody.velocity=new Vector2(-maxspeed, rigidbody.velocity.y);
			}
		}
		
		if(Input.GetKeyDown(KeyCode.UpArrow) && grounded && movable){
			rigidbody.AddForce(new Vector2(0f,jumpPower));
		}

		if(Input.GetButtonDown("Fire1") && movable){
			interact();
		}
		
		if(Input.GetButtonDown("Fire2")){
			movable = !movable;
		}
	}

	void OnCollisionStay(Collision collisionInfo) {
		if (collisionInfo.gameObject.tag == "platform" && grounded) {
			transform.parent = collisionInfo.transform;
				} else {
						transform.parent = null;
				}

	}
	
	void OnTriggerEnter(Collider collider) {
		print ("test");
		collider.gameObject.GetComponent<EndpointController>().interact();
		
	}

	public void interact(){
		RaycastHit hitInfo;
		Vector3 dept = transform.TransformDirection(new Vector3(0,0,1));
		if (Physics.Raycast (transform.position, dept, out hitInfo, 100, 1 << 9)) {
			hitInfo.collider.gameObject.GetComponent<ComputerController>().interact();
			movable = false;
		}
	}

    public void setMovable(bool move)
    {
        movable = move;
    }
}
