using UnityEngine;
using System.Collections;

public class guiInterface : MonoBehaviour
{
		private GameObject computer;
		public TextMesh text;
		private ArrayList commands = new ArrayList ();
		// Use this for initialization
		void Start ()
		{
	
		}
	
		// Update is called once per frame
		void Update ()
		{
				if (Input.GetMouseButtonDown (0)) {
						RaycastHit hitInfo;
						string hit;
						Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
						if (Physics.Raycast (ray, out hitInfo, 100, 1 << 10)) {
								hit = hitInfo.collider.gameObject.name;
								if (hit == "UpButton") {
										commands.Add ("up");
										text.text += "\nup";
								} else if (hit == "DownButton") {
										commands.Add ("down");
										text.text += "\ndown";
								} else if (hit == "LeftButton") {
										commands.Add ("left");
										text.text += "\nleft";
								} else if (hit == "RightButton") {
										commands.Add ("right");
										text.text += "\nright";
								} else if (hit == "UploadButton") {
										computer.GetComponent<ComputerController> ().reacted (commands);

								} else if (hit == "RemoveButton") {
										string txt = text.text;
										int index = txt.LastIndexOf ("\n");
										if (index > 0) {
												txt = txt.Substring (0, index);
												commands.RemoveAt(commands.Count-1);
										}
										text.text = txt;
					
								}
						}
				}
		}

		public void startup (GameObject comp)
		{
				computer = comp;
				text.text = "commands:";
				commands = new ArrayList ();
		}
}
