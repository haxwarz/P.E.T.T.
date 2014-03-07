using UnityEngine;
using System.Collections;

public class rotateTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if(Input.GetKeyDown(KeyCode.RightArrow)){
            transform.Rotate(Vector3.up, 90);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.RotateAround(transform.position, -Vector3.up, 90);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            this.transform.position += transform.forward;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            this.transform.position -= transform.forward;
        }
	}
}
