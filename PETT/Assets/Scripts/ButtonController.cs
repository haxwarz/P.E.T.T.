using UnityEngine;
using System.Collections;

public class ButtonController : MonoBehaviour {

    public GameObject door;

    private GameObject computer;
    private ComputerControllerRobot script;
	// Use this for initialization

    public void init( GameObject comp)
    {
        this.computer = comp;
    }
	public void open(){
        script = computer.GetComponent<ComputerControllerRobot>();
        script.openDoor();
    }
}
