using UnityEngine;
using System.Collections;

public class ButtonController : MonoBehaviour {

    private GameObject computer;
    private ComputerControllerRobot script;
	// Use this for initialization

    public void init( GameObject comp)
    {
        this.computer = comp;
    }
    public void open()
    {
        if (computer != null)
        {
            script = computer.GetComponent<ComputerControllerRobot>();
            if(script != null)
                script.openDoor();
        }
    }
}
