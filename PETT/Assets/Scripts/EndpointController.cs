﻿using UnityEngine;
using System.Collections;

public class EndpointController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		print (Application.loadedLevel);
	}
	// Update is called once per frame
	void Update () {

	}

	public void interact(){
		Application.LoadLevel (Application.loadedLevel+1);
	}
}
