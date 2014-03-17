using UnityEngine;
using System.Collections;

//TODO: Place Expainatory comments in the code
public class EndpointController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	// Update is called once per frame
	void Update () {

	}

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject == GameObject.Find("Player"))
        {
            Application.LoadLevel(Application.loadedLevel + 1);
        }
    }
}
