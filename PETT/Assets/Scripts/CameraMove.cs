using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour {
	public float leftLimit;// = -3;//GameObject.FindWithTag("leftwall").transform.position.x+2;
	public float rightLimit = 1.9f;
	public float toplimit = 3.5f;
	public float bottomlimit = 2;

	GameObject mainCamera;
	// Use this for initialization
	
	
	void Start () {
		mainCamera = (GameObject) GameObject.FindWithTag ("MainCamera");
		leftLimit = GameObject.FindWithTag ("leftwall").transform.position.x + 2.5f;
		print (GameObject.FindWithTag ("leftwall").transform.position.x.ToString ());

	}
	
	// Update is called once per frame
	void Update () {
		mainCamera.transform.position = new Vector3(Mathf.Clamp(transform.position.x, leftLimit, rightLimit),Mathf.Clamp(transform.position.y, bottomlimit, toplimit),5);
	}
}
