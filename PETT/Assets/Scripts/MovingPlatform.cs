using UnityEngine;
using System.Collections;

public class MovingPlatform : MonoBehaviour
{
    // Use this for initialization

    private ArrayList destinations = new ArrayList();
    private Vector3 startPos;

    public float horizontalMove = 1f;
    public float verticalMove = 0.2f;

    public float borderLeft = 1f;
    public float borderRight = 3f;
    public float borderTop = 3.1f;
    public float borderBot = 1.7f;

    void Start()
    {
        startPos = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
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
        }
    }

    public void moveLeft()
    {
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
    }

    public void moveRight()
    {
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
        }
    }

    public void moveUp()
    {
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
        }
    }

    public void moveDown()
    {
        if (destinations.Count == 0)
        {
            //if(this.transform.position.y - verticalMove >= borderBot)
                destinations.Add(new Vector3(this.transform.position.x, this.transform.position.y - verticalMove, this.transform.position.z));
        }
        else
        {
            Vector3 temp = (Vector3)destinations[destinations.Count - 1];
            //if(temp.y - verticalMove >= borderBot)
                destinations.Add(new Vector3(temp.x, temp.y - verticalMove, temp.z));
        }
    }

    public void startup()
    {
        this.transform.position = startPos;
    }
}
