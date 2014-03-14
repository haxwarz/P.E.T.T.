using UnityEngine;
using System.Collections;

public class RobotGameStartup : MonoBehaviour {

 	// Use this for initialization
	void Start () {
        Transform[] allChildren = GetComponentsInChildren<Transform>();
        foreach (Transform child in allChildren)
        {
            if(child.name != "Plane"){
                float tempX = Mathf.Round(child.localPosition.x);
                float tempZ = Mathf.Round(child.localPosition.z);

                child.localPosition = new Vector3(tempX, child.localPosition.y, tempZ);
            }
        }
	}
}
