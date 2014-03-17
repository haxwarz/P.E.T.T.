using UnityEngine;
using System.Collections.Generic;

//TODO: Place Expainatory comments in the code
public class StoryPoint : MonoBehaviour
{
		public List<string> strings = new List<string> ();
		public GameObject pane;
        public TextMesh text;

		// Use this for initialization
		void Start ()
		{
	
		}
	
		// Update is called once per frame
		void Update ()
		{
			if(Input.GetKeyDown(KeyCode.Q)){
                if (strings.Count > 0)
                { strings.RemoveAt(0); }
			}
	
		}

		void OnTriggerStay(Collider collider){
            if (collider.gameObject == GameObject.Find("Player"))
            {
                collider.gameObject.GetComponent<Player>().setMovable(false);
                if (strings.Count > 0)
                {
                    string s = strings[0].Replace(";;;", "\n");
                    text.text = s;
                    pane.SetActive(true);
                }
                else
                {
                    Destroy(this.gameObject);
                    collider.gameObject.GetComponent<Player>().setMovable(true);
                }
            }
			
		}
}

