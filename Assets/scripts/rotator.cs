﻿using UnityEngine;

public class rotator : MonoBehaviour {
    
	void Update () {
        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
	}
}
