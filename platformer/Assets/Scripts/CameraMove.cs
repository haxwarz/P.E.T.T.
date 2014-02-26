using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour {
	public float leftLimit = -15;
	public float rightLimit = -2;

	GameObject mainCamera;
	// Use this for initialization
	
	
	void Start () {
		mainCamera = (GameObject) GameObject.FindWithTag ("MainCamera");
	}
	
	// Update is called once per frame
	void Update () {
		mainCamera.transform.position = new Vector3(Mathf.Clamp(transform.position.x, leftLimit, rightLimit),transform.position.y,-10);
	}
}
