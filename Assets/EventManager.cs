using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour {
    AudioSource aSrc;

    public AudioClip hoverFx;

    void Start () {
        aSrc = GetComponent<AudioSource>();
	}

    public void playHover()
    {
        aSrc.PlayOneShot(hoverFx);
    }
}
