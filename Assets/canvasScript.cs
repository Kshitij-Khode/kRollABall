using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class canvasScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	public void anim(){
		transform.parent.gameObject.GetComponent<Animator>().SetTrigger("start");
	}
}
