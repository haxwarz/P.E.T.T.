﻿using UnityEngine;
using System.Collections;

public class guiInterfaceRobot : MonoBehaviour
{
		public GameObject robot;
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
                                        robot.GetComponent<MovingPlatform>().moveUp();
								} else if (hit == "DownButton") {
										commands.Add ("down");
                                        text.text += "\ndown";
                                        robot.GetComponent<MovingPlatform>().moveDown();
								} else if (hit == "LeftButton") {
										commands.Add ("left");
                                        text.text += "\nleft";
                                        robot.GetComponent<MovingPlatform>().moveLeft();
								} else if (hit == "RightButton") {
										commands.Add ("right");
                                        text.text += "\nright";
                                        robot.GetComponent<MovingPlatform>().moveRight();
								} else if (hit == "UploadButton") {

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

		public void startup ()
		{
				text.text = "commands:";
				commands = new ArrayList ();
		}
}