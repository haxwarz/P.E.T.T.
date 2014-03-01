using UnityEngine;
using System.Collections;

public class ComputerController : MonoBehaviour {

	public GameObject platform;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	void interact(){
		//platform.transform.position += Vector3.right * 1 * Time.deltaTime;
		MovingPlatform movePlatform = platform.gameObject.GetComponent<MovingPlatform>();
		movePlatform.interact ();
	}
}
