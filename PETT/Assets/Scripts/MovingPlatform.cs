using UnityEngine;
using System.Collections;

public class MovingPlatform : MonoBehaviour {
	// Use this for initialization

	ArrayList destinations = new ArrayList();

	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (destinations.Count > 0) {
			Vector3 currentDestination = (Vector3) destinations[0];
			if(currentDestination.x < this.transform.position.x){
				this.transform.position += Vector3.left * 1 * Time.deltaTime;
			}else if(currentDestination.x > this.transform.position.x){
				this.transform.position += Vector3.right * 1 * Time.deltaTime;
			}
			else{
				destinations.RemoveAt(0);
			}
		}
	}

	public void moveLeft(){
		destinations.Add(new Vector3(this.transform.position.x - 1, this.transform.position.y, this.transform.position.z));
	}

	public void moveRight(){
		destinations.Add(new Vector3(this.transform.position.x + 1, this.transform.position.y, this.transform.position.z));
	}

	public void interact(){
		moveLeft ();
		//moveRight ();
	}
}
