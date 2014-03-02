using UnityEngine;
using System.Collections;

public class MovingPlatform : MonoBehaviour
{
		// Use this for initialization

		ArrayList destinations = new ArrayList ();
		float horizontalMove = 1f;
		float verticalMove = 0.2f;

		void Start ()
		{
		}

		// Update is called once per frame
		void Update ()
		{
				if (destinations.Count > 0) {
						Vector3 currentDestination = (Vector3)destinations [0];
						if (currentDestination.x < this.transform.position.x) {
								this.transform.position += Vector3.left * 1 * Time.deltaTime;
						} else if (currentDestination.x > this.transform.position.x) {
								this.transform.position += Vector3.right * 1 * Time.deltaTime;
						}

						if (currentDestination.y > this.transform.position.y) {
								this.transform.position += Vector3.up * 1 * Time.deltaTime;
						} else if (currentDestination.y < this.transform.position.y) {
								this.transform.position += Vector3.down * 1 * Time.deltaTime;
						}

						float dist = Vector3.Distance (currentDestination, transform.position);
						if (dist < 0.01) {
								this.transform.position = currentDestination;
								destinations.RemoveAt (0);
						}
				}
		}
	
		public void moveLeft ()
		{
				if (destinations.Count == 0) {
						destinations.Add (new Vector3 (this.transform.position.x - horizontalMove, this.transform.position.y, this.transform.position.z));
				} else {
						Vector3 temp = (Vector3)destinations [destinations.Count - 1];
						destinations.Add (new Vector3 (temp.x - horizontalMove, temp.y, temp.z));
				}
		}
	
		public void moveRight ()
		{
				if (destinations.Count == 0) {
						destinations.Add (new Vector3 (this.transform.position.x + horizontalMove, this.transform.position.y, this.transform.position.z));
				} else {
						Vector3 temp = (Vector3)destinations [destinations.Count - 1];
						destinations.Add (new Vector3 (temp.x + horizontalMove, temp.y, temp.z));
				}
		}
	
		public void moveUp ()
		{
				if (destinations.Count == 0) {
						destinations.Add (new Vector3 (this.transform.position.x, this.transform.position.y + verticalMove, this.transform.position.z));
				} else {
						Vector3 temp = (Vector3)destinations [destinations.Count - 1];
						destinations.Add (new Vector3 (temp.x, temp.y + verticalMove, temp.z));
				}
		}
	
		public void moveDown ()
		{
				if (destinations.Count == 0) {
						destinations.Add (new Vector3 (this.transform.position.x, this.transform.position.y - verticalMove, this.transform.position.z));
				} else {
						Vector3 temp = (Vector3)destinations [destinations.Count - 1];
						destinations.Add (new Vector3 (temp.x, temp.y - verticalMove, temp.z));
				}
		}

		public void interact ()
		{
				moveUp ();
				//moveRight ();
		}
}
