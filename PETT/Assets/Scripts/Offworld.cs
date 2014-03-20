using UnityEngine;
using System.Collections.Generic;

//TODO: Place Expainatory comments in the code
public class Offworld : MonoBehaviour
{
		// Use this for initialization
		void Start ()
		{
	
		}
	
		// Update is called once per frame
		void Update ()
		{
				
		}

		void OnTriggerStay(Collider collider){
            if (collider.gameObject == GameObject.Find("Player"))
            {
                collider.gameObject.transform.position = collider.gameObject.GetComponent<Player>().checkpoint;
            }
			
		}
}

