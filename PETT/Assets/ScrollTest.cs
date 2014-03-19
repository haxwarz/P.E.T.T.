using UnityEngine;
using System.Collections;

public class ScrollTest : MonoBehaviour {
    ArrayList myList = new ArrayList();
    GUIStyle style;
    public Vector2 scrollPosition = Vector2.zero;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            myList.Add("forward");
            
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            myList.RemoveAt(myList.Count - 1);
        }
    }
    void OnGUI()
    {
        GUI.skin.label.normal.textColor = Color.black;

        scrollPosition = GUI.BeginScrollView(new Rect(50, 50, 100, 100), scrollPosition, new Rect(0, 0, 80, 10+(myList.Count* 10)));
        for (int i = 0; i < myList.Count; i++)
        {
            print((string)myList[i]);
            GUI.Label(new Rect(0, i*10, 80, 100), (string)myList[i]);
        }
        GUI.EndScrollView();
    }
}
