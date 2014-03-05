using UnityEngine;
using System.Collections;

public class ComputerController : MonoBehaviour {

	public GameObject platform;
	public GameObject gui;

	public bool ableLeft;
	public bool ableRight;
	public bool ableUp;
	public bool ableDown;

	// Use this for initialization
	void Start () {
		gui.SetActive (false);
	}
	// Update is called once per frame
	void Update () {

	}

	public void interact(){
		//platform.transform.position += Vector3.right * 1 * Time.deltaTime;
		//movePlatform.interact ();
		gui.SetActive(true);
		gui.GetComponent<guiInterface>().startup (this.gameObject);
		//platform.GetComponent<MovingPlatform> ().interact();

	}

	public void reacted(ArrayList commands){
		gui.SetActive (false);
		foreach (string str in commands) {
			if (str == "up") {
				platform.GetComponent<MovingPlatform> ().moveUp();
			}
			else if (str == "down") {
				platform.GetComponent<MovingPlatform> ().moveDown();
			}
			else if (str == "left") {
				platform.GetComponent<MovingPlatform> ().moveLeft();
			}
			else if (str == "right") {
				platform.GetComponent<MovingPlatform> ().moveRight();
			}
		}

		//GameObject.Find ("Player").GetComponent<Player> ().movable = true;
	}
}
