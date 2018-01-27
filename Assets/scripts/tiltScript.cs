using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tiltScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(new Vector3(Input.GetAxis("Vertical"),0,Input.GetAxis("Horizontal")));		
	}
}
