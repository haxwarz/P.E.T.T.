using UnityEngine;
using System.Collections;

public class ComputerController : MonoBehaviour {

	public GameObject platform;
	public GameObject gui;
	public GameObject camera;

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
		gui.SetActive(true);
		camera.SetActive (true);
		gui.GetComponent<guiInterface>().startup (this.gameObject);
        platform.GetComponent<MovingPlatform>().startup();
	}

	public void reacted(ArrayList commands){
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

		GameObject.Find ("Player").GetComponent<Player> ().setMovable(true);
		gui.SetActive (false);
		camera.SetActive (false);
	}
}
