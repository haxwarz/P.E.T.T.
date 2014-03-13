using System.Collections;
using UnityEngine;

public class RobotMovement : MonoBehaviour
{

    //private float timer = 0;
    private ArrayList destinations = new ArrayList();
    private Vector3 startPos;
    private GameObject computer;
    private Vector3 currentDestination;
    bool stopped = false;
    GameObject other;

    void Start()
    {
        startPos = transform.position;
        currentDestination = new Vector3(0, -1, 0);
    }

    void FixedUpdate()
    {
        if (currentDestination.y != -1)
        {
            if (currentDestination.z > this.transform.position.z)
            {
                this.transform.position += new Vector3(0, 0, 1) * 1 * Time.deltaTime;
            }
            else if (currentDestination.z < this.transform.position.z)
            {
                this.transform.position += new Vector3(0, 0, 1) * -1 * Time.deltaTime;
            }
            if (currentDestination.x > this.transform.position.x)
            {
                this.transform.position += new Vector3(1, 0, 0) * 1 * Time.deltaTime;
            }
            else if (currentDestination.x < this.transform.position.x)
            {
                this.transform.position += new Vector3(1, 0, 0) * -1 * Time.deltaTime;
            }
            if(Vector3.Distance(transform.position, currentDestination) < 0.01){
                currentDestination = new Vector3(0, -1, 0);
            }
        }
        else
        {
            if (stopped)
            {
                other.gameObject.GetComponent<ButtonController>().open();
            }
            else if (destinations.Count > 0)
            {
                string nextDest = (string)destinations[0];
                if (nextDest == "forward")
                {
                    currentDestination = transform.position + transform.forward;
                }
                else if (nextDest == "backwards")
                {
                    currentDestination = transform.position - transform.forward;
                }
                else if (nextDest == "left")
                {
                    transform.Rotate(Vector3.up, -90);
                }
                else if (nextDest == "right")
                {
                    transform.Rotate(Vector3.up, 90);
                }
                destinations.RemoveAt(0);
            }
        }
    }

    public void forward()
    {
        destinations.Add("forward");
    }

    public void rotateRight()
    {
        destinations.Add("right");
    }
    public void rotateLeft()
    {
        destinations.Add("left");
    }
    public void backwards()
    {
        destinations.Add("backwards");
    }

    public void startup(GameObject comp)
    {
        computer = comp;
        this.transform.position = startPos;
        currentDestination = new Vector3(0, -1, 0);
    }

    void OnTriggerEnter(Collider other)
    {
        stopped = true;
        this.other = other.gameObject;
    }
}









/*void FixedUpdate () {
    timer += Time.deltaTime;
    if (timer < 0.5)
    {
        forward();
    }
    else if (timer < 1)
    {
        float tempX = transform.position.x;
        float tempY = transform.position.y;
        float tempZ = transform.position.z;

        if (!(tempX % 1 == 0 && tempY % 1 == 0 && tempZ % 1 == 0))
        {
            tempX = Mathf.Round(tempX);
            tempY = Mathf.Round(tempY);
            tempZ = Mathf.Round(tempZ);
            print("rounded pos: " + tempX + " : " + tempY + " : " + tempZ);
            transform.position = new Vector3(tempX, tempY, tempZ);
        }
    }
    else
    {
        timer = 0;
        RaycastHit hit;
        if(rigidbody.SweepTest(transform.right, out hit, 1)){
            while (rigidbody.SweepTest(transform.forward, out hit, 1))
            {
                rotateLeft();
            }
        }
        else
        {
            rotateRight();
        }
    }     
}*/