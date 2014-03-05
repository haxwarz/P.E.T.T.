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
		platform.GetComponent<MovingPlatform> ().interact();

	}
}
