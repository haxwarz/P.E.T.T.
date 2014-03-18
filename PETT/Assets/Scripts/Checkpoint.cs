using UnityEngine;
using System.Collections.Generic;

//TODO: Place Expainatory comments in the code
public class Checkpoint : MonoBehaviour
{
		private bool active = false;

		// Use this for initialization
		void Start ()
		{
	
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}

        void OnTriggerEnter(Collider collider)
        {
            if (collider.gameObject == GameObject.Find("Player"))
            {
                collider.gameObject.GetComponent<Player>().checkpoint = collider.gameObject.transform.position;
                Destroy(this.gameObject);
            }
			
		}
}

