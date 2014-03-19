using UnityEngine;
using System.Collections;

//TODO: Place Expainatory comments in the code
public class guiInterface : MonoBehaviour
{
		private GameObject computer;
		public TextMesh text;
        private ArrayList commands = new ArrayList();
        public Vector2 scrollPosition = Vector2.zero;
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
										//text.text += "\nup";
								} else if (hit == "DownButton") {
										commands.Add ("down");
										//text.text += "\ndown";
								} else if (hit == "LeftButton") {
										commands.Add ("left");
										//text.text += "\nleft";
								} else if (hit == "RightButton") {
										commands.Add ("right");
										//text.text += "\nright";
								} else if (hit == "UploadButton") {
                                    computer.GetComponent<ComputerController>().reacted(commands);
                                    //text.text = "Commands:";
                                    commands = new ArrayList();

								} else if (hit == "RemoveButton") {
                                        //string txt = text.text;
                                        //int index = txt.LastIndexOf ("\n");
                                        //if (index > 0) {
                                        //        txt = txt.Substring (0, index);
                                        //        commands.RemoveAt(commands.Count-1);
                                        //}
                                        //text.text = txt;
                                        if(commands.Count > 0)
                                        commands.RemoveAt(commands.Count - 1);

                                } scrollPosition.y = Mathf.Infinity;
						}
				}
		}

		public void startup (GameObject comp)
		{
				computer = comp;
				text.text = "commands:";
                commands = new ArrayList();

		}

        void OnGUI()
        {
            GUI.skin.label.normal.textColor = Color.black;


            scrollPosition = GUI.BeginScrollView(new Rect(Screen.width / 2 - 50, Screen.height / 100*20, 300, Screen.height / 100*70), scrollPosition, new Rect(0, 0, 80, 10 + (commands.Count * 40)));
            for (int i = 0; i < commands.Count; i++)
            {
                GUI.Label(new Rect(0, i * 40, 300, 100), "<size=40>" + (string)commands[i] + "</size>");
            }
            GUI.EndScrollView();
        }
}
