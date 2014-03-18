using UnityEngine;
using System.Collections;

//TODO: Place Expainatory comments in the code
public class ComputerControllerRobot : MonoBehaviour {

	public GameObject robot;
	public GameObject gui;
	public GameObject camera;
    private GameObject[] buttons;
    public GameObject door;
    public GameObject button;

	public bool ableLeft;
	public bool ableRight;
	public bool ableUp;
	public bool ableDown;

	// Use this for initialization
	void Start () {
        button.GetComponent<ButtonController>().init(this.gameObject);
        
        turnOffGUI();

	}

	public void interact(){
		gui.SetActive(true);
		camera.SetActive (true);
		gui.GetComponent<guiInterfaceRobot>().startup (this.gameObject);
        robot.GetComponent<RobotMovement>().startup(this.gameObject);
	}

	public void reacted(ArrayList commands){
		if (commands.Count <= 0) {
			this.turnOffGUI();
		}
		foreach (string str in commands) {
			if (str == "up") {
                robot.GetComponent<RobotMovement>().forward();
			}
			else if (str == "down") {
                robot.GetComponent<RobotMovement>().backwards();
			}
			else if (str == "left") {
                robot.GetComponent<RobotMovement>().rotateLeft();
			}
			else if (str == "right") {
                robot.GetComponent<RobotMovement>().rotateRight();
			}
		}
	}

	public void turnOffGUI(){
        print("turnOffGUI");
				gui.SetActive (false);
				camera.SetActive (false);
				GameObject.Find ("Player").GetComponent<Player> ().setMovable(true);
		}

    internal void openDoor()
    {
        turnOffGUI();
        Destroy(door);
    }
}
