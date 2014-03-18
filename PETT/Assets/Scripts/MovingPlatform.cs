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
        /*
        if (destinations.Count > 0)
        {
            Vector3 currentDestination = (Vector3)destinations[0];
            if (currentDestination.x < this.transform.position.x)
            {
                this.transform.position += Vector3.left * 1 * Time.deltaTime;
            }
            else if (currentDestination.x > this.transform.position.x)
            {
                this.transform.position += Vector3.right * 1 * Time.deltaTime;
            }

            if (currentDestination.y > this.transform.position.y)
            {
                this.transform.position += Vector3.up * 1 * Time.deltaTime;
            }
            else if (currentDestination.y < this.transform.position.y)
            {
                this.transform.position += Vector3.down * 1 * Time.deltaTime;
            }

            float dist = Vector3.Distance(currentDestination, transform.position);
            if (dist < 0.01)
            {
                this.transform.position = currentDestination;
                destinations.RemoveAt(0);
            }
            if(destinations.Count <= 0)
                computer.GetComponent<ComputerController>().turnOffGUI();
        }
         */
    }

    public void moveLeft()
    {
        destinations.Add(dirs.left);
        /*
        if (destinations.Count == 0)
        {
            //if (this.transform.position.x - horizontalMove >= borderLeft)
                destinations.Add(new Vector3(this.transform.position.x - horizontalMove, this.transform.position.y, this.transform.position.z));
        }
        else
        {
            Vector3 temp = (Vector3)destinations[destinations.Count - 1];
            //if(temp.x - horizontalMove >= borderLeft)
                destinations.Add(new Vector3(temp.x - horizontalMove, temp.y, temp.z));
        }
         */
    }

    public void moveRight()
    {
        destinations.Add(dirs.right);
        /*
        if (destinations.Count == 0)
        {
            //if(this.transform.position.x + horizontalMove <= borderRight)
                destinations.Add(new Vector3(this.transform.position.x + horizontalMove, this.transform.position.y, this.transform.position.z));
        }
        else
        {
            Vector3 temp = (Vector3)destinations[destinations.Count - 1];
            //if(temp.x + horizontalMove <= borderRight)
                destinations.Add(new Vector3(temp.x + horizontalMove, temp.y, temp.z));
        }*/
    }

    public void moveUp()
    {
        destinations.Add(dirs.up);
        /*
        if (destinations.Count == 0)
        {
            //if(this.transform.position.y + verticalMove <= borderTop)
                destinations.Add(new Vector3(this.transform.position.x, this.transform.position.y + verticalMove, this.transform.position.z));
        }
        else
        {
            Vector3 temp = (Vector3)destinations[destinations.Count - 1];
            //if(temp.y + verticalMove <= borderTop)
                destinations.Add(new Vector3(temp.x, temp.y + verticalMove, temp.z));
        }*/
    }

    public void moveDown()
    {
        destinations.Add(dirs.down);
        /*if (destinations.Count == 0)
        {
            //if(this.transform.position.y - verticalMove >= borderBot)
                destinations.Add(new Vector3(this.transform.position.x, this.transform.position.y - verticalMove, this.transform.position.z));
        }
        else
        {
            Vector3 temp = (Vector3)destinations[destinations.Count - 1];
            //if(temp.y - verticalMove >= borderBot)
                destinations.Add(new Vector3(temp.x, temp.y - verticalMove, temp.z));
        }*/
    }

    public void startup(GameObject comp)
    {
        computer = comp;
        restart();
    }

    public void restart()
    {
        currentDestination = new Vector3(0, -1, 0);
        this.transform.localPosition = startPos;
        destinations = new ArrayList();
        moving = false;
    }
    void OnCollisionEnter(Collision collision)
    {
        if (moving)
            restart();
    }
}
