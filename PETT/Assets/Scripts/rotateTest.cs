using UnityEngine;
using System.Collections;

public class rotateTest : MonoBehaviour {

    private float timer = 0;
	
	void Start () {}
	
	void FixedUpdate () {
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
        

        
	}

    void forward()
    {
        transform.position += transform.forward * (2 * Time.deltaTime);
    }

    void rotateRight()
    {
        transform.Rotate(Vector3.up, 90);
    }
    void rotateLeft()
    {
        transform.Rotate(Vector3.up, -90);
    }
}
