using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tiltScript : MonoBehaviour {
	[SerializeField]
	bool invert;

	[HideInInspector]
	public bool animate;

	public GameObject cam;

	[SerializeField]
	public float tiltSpeed = 2;

	Vector3	initPos;

	// Use this for initialization
	void Start () {
		initPos	= cam.transform.position;
	}

	public void letsGo(){
		animate = true;
	}


	public static Vector3 centerAngle(Vector3 angles){
			return new Vector3(angles.x > 180 ? angles.x - 360 : angles.x,
						   	   angles.y > 180 ? angles.y - 360 : angles.y,
						       angles.z > 180 ? angles.z - 360 : angles.z);
	}

	
	// Update is called once per frame
	void Update () {
		if(animate){
			transform.eulerAngles = Vector3.Lerp(centerAngle(transform.eulerAngles),Vector3.zero, .5f * Time.deltaTime);
		}
		else{
			Vector3	centered = centerAngle(transform.eulerAngles);
			Vector2 tilt = new Vector2(Input.GetAxis("HorizontalTilt") * tiltSpeed,Input.GetAxis("VerticalTilt") * tiltSpeed);
			transform.Rotate(new Vector3((invert ? -1 : 1) * tilt.y,0,(invert ? -1 : 1) * tilt.x));		
			transform.eulerAngles = new Vector3(transform.eulerAngles.x,0,transform.eulerAngles.z);
			if(Mathf.Abs(centerAngle(transform.eulerAngles).x) + Mathf.Abs(centerAngle(transform.eulerAngles).z) > 45 && 
								Mathf.Abs(centered.x) + Mathf.Abs(centered.z) < 
								Mathf.Abs(centerAngle(transform.eulerAngles).x) + Mathf.Abs(centerAngle(transform.eulerAngles).z)){
				transform.Rotate(new Vector3((invert ? 1 : -1) * tilt.y,0,(invert ? 1 : -1) * tilt.x));	
				float xOverY = (Mathf.Abs(tilt.x) > Mathf.Abs(tilt.y) ? 1 : -1);
				float signXY = (xOverY == 1 ? Mathf.Sign(tilt.x) : Mathf.Sign(tilt.y));
				if(Mathf.Sign(tilt.x * tilt.y) == 1){
							transform.eulerAngles = new Vector3(transform.eulerAngles.x + Time.deltaTime * xOverY * signXY,
							transform.eulerAngles.y,transform.eulerAngles.z - Time.deltaTime * xOverY * signXY);
						}
			}
			//cam.transform.eulerAngles	= (transform.eulerAngles / 2) + new Vector3(24.29f,0,0);
			if(centered.x > 30 || centered.z > 30 || centered.x < -30 || centered.z < -30
				|| Mathf.Abs(centered.x) + Mathf.Abs(centered.z) > 35){
					cam.transform.position = Vector3.Lerp(cam.transform.position,initPos + new Vector3(0,13,-5),Time.deltaTime / 2);
			} else {
					cam.transform.position = Vector3.Lerp(cam.transform.position,initPos,Time.deltaTime / 2);
			}
			print(centered);
		}
	}
}
