using UnityEngine;
using System.Collections;

public class ComputerController : MonoBehaviour {

	public GameObject platform;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.D)) {
			platform.transform.position += Vector3.right * 1 * Time.deltaTime;
		}
		if (Input.GetKey (KeyCode.A)) {
			platform.transform.position += Vector3.left * 1 * Time.deltaTime;
		}
	}
}
