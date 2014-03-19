using System.Collections;
using UnityEngine;

public class RobotMovement : MonoBehaviour
{
    private enum dirs { forward = 0, backward = 1, left = 2, right = 3 }

    private ArrayList destinations = new ArrayList();
    private Vector3 startPos;
    private Quaternion startRotate;
    private GameObject computer;
    private Vector3 currentDestination;

    bool stopped = false;
    GameObject other;

    void Start()
    {
        startPos = transform.localPosition;
        startRotate = transform.rotation;
        currentDestination = new Vector3(0, -1, 0);
    }

    void FixedUpdate()
    {
        if (currentDestination.y != -1)
        {
            if (currentDestination.z > this.transform.localPosition.z)
            {
                this.transform.localPosition += new Vector3(0, 0, 1) * 1 * Time.deltaTime;
            }
            else if (currentDestination.z < this.transform.localPosition.z)
            {
                this.transform.localPosition += new Vector3(0, 0, 1) * -1 * Time.deltaTime;
            }
            if (currentDestination.x > this.transform.localPosition.x)
            {
                this.transform.localPosition += new Vector3(1, 0, 0) * 1 * Time.deltaTime;
            }
            else if (currentDestination.x < this.transform.localPosition.x)
            {
                this.transform.localPosition += new Vector3(1, 0, 0) * -1 * Time.deltaTime;
            }
            if (Vector3.Distance(transform.localPosition, currentDestination) < 0.01)
            {
                currentDestination = new Vector3(0, -1, 0);
            }
        }
        else
        {
            if (stopped)
            {
                other.gameObject.GetComponent<ButtonController>().open();
                stopped = false;
            }
            else if (destinations.Count > 0)
            {
                switch ((dirs)destinations[0])
                {
                    case dirs.forward:
                        currentDestination = transform.localPosition + transform.forward;
                        break;
                    case dirs.backward:
                        currentDestination = transform.localPosition - transform.forward;
                        break;
                    case dirs.left:
                        transform.Rotate(Vector3.up, -90);
                        break;
                    case dirs.right:
                        transform.Rotate(Vector3.up, 90);
                        break;
                }

                //string nextDest = (string)destinations[0];

                //if (nextDest == "forward")
                //{
                //    currentDestination = transform.localPosition + transform.forward;
                //}
                //else if (nextDest == "backwards")
                //{
                //    currentDestination = transform.localPosition - transform.forward;
                //}
                //else if (nextDest == "left")
                //{
                //    transform.Rotate(Vector3.up, -90);
                //}
                //else if (nextDest == "right")
                //{
                //    transform.Rotate(Vector3.up, 90);
                //}
                destinations.RemoveAt(0);
            }
        }
    }

    public void forward()
    {
        destinations.Add(dirs.forward);
    }

    public void rotateRight()
    {
        destinations.Add(dirs.right);
    }
    public void rotateLeft()
    {
        destinations.Add(dirs.left);
    }
    public void backwards()
    {
        destinations.Add(dirs.backward);
    }

    public void startup(GameObject comp)
    {
        computer = comp;
        restart();
    }

    public void restart()
    {
        currentDestination = new Vector3(0, -1, 0);
        this.transform.rotation = startRotate;
        this.transform.localPosition = startPos;
        destinations = new ArrayList();
    }

    void OnTriggerEnter(Collider other)
    {
        if (stopped == false)
        {
            restart();
            stopped = true;
            this.other = other.gameObject;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        restart();
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