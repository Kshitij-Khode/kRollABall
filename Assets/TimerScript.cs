using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour {

    public Text timerText;
	
	void Update () {
        timerText.text = "Timer: " + Time.timeSinceLevelLoad;
	}
}
