using UnityEngine;
using System.Collections;

public class ButtonController : MonoBehaviour {

    public GameObject door;
    public GameObject computer;
	// Use this for initialization
	public void open(){
        Destroy(door);
        computer.GetComponent<ComputerControllerRobot>().turnOffGUI();
    }
}
