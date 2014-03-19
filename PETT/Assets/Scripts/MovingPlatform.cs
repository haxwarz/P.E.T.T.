using UnityEngine;
using System.Collections;

//TODO: Place Expainatory comments in the code
public class MovingPlatform : MonoBehaviour
{
    // Use this for initialization
    private enum dirs { up = 0, down = 1, left = 2, right = 3 }
    private ArrayList destinations = new ArrayList();
    private Vector3 startPos;
    private GameObject computer;
    private bool moving = false;

    private Vector3 currentDestination;

    public float horizontalMove = 0.5f;
    public float verticalMove = 0.5f;

    public float borderLeft = 1f;
    public float borderRight = 3f;
    public float borderTop = 3.1f;
    public float borderBot = 1.7f;

    void Start()
    {
        startPos = this.transform.position;
        currentDestination = new Vector3(0, -1, 0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (currentDestination.y != -1)
        {
            moving = true;
            if (currentDestination.y > this.transform.localPosition.y)
            {
                this.transform.localPosition += new Vector3(0, 1, 0) * 1 * Time.deltaTime;
            }
            else if (currentDestination.y < this.transform.localPosition.y)
            {
                this.transform.localPosition += new Vector3(0, 1, 0) * -1 * Time.deltaTime;
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
                if (destinations.Count <= 0)
                {
                    computer.GetComponent<ComputerController>().turnOffGUI();
                }
            }
        }
        else
        {
            if (destinations.Count > 0)
            {
                switch ((dirs)destinations[0])
                {
                    case dirs.up:
                        currentDestination = transform.localPosition + (transform.up * verticalMove);
                        break;
                    case dirs.down:
                        currentDestination = transform.localPosition + (-transform.up * verticalMove);
                        break;
                    case dirs.left:
                        currentDestination = transform.localPosition + (-transform.right * horizontalMove);
                        break;
                    case dirs.right:
                        currentDestination = transform.localPosition + (transform.right * horizontalMove);
                        break;
                }
                destinations.RemoveAt(0);
            }
            else
            {
                moving = false;
            }
        }
    }

    public void moveLeft()
    {
        destinations.Add(dirs.left);
    }

    public void moveRight()
    {
        destinations.Add(dirs.right);
    }

    public void moveUp()
    {
        destinations.Add(dirs.up);
    }

    public void moveDown()
    {
        destinations.Add(dirs.down);
    }

    public void startup(GameObject comp)
    {
        computer = comp;
        restart();
    }

    public void restart()
    {
        currentDestination = new Vector3(0, -1, 0);
        this.transform.position = startPos;
        destinations = new ArrayList();
        moving = false;
    }
    void OnCollisionEnter(Collision collision)
    {
        if (moving)
            restart();
    }
}
