using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bugScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(new Vector3(0,Time.deltaTime * 90,0));
		//transform.position += new Vector3(0,Mathf.PingPong(Time.time,1) - 2f,0);
	}

	public void die(){
		GetComponent<Animator>().SetTrigger("die");
		Destroy(gameObject,.665f);

	}
}
