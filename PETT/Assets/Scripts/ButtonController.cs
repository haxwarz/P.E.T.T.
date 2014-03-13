using UnityEngine;
using System.Collections;

public class ButtonController : MonoBehaviour {

    public GameObject door;
	// Use this for initialization
	public void open(){
        Destroy(door);
    }
}
