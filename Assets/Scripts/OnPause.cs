using UnityEngine;
using UnityEngine.EventSystems;

public class OnPause : MonoBehaviour {

    public Transform canvas;
    public GameObject firstButton;
    public AudioClip pauseFx;

    AudioSource aSrc;

    void Start()
    {
        aSrc = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Joystick1Button7))
        {
            Pause();
        }
    }

    public void Pause()
    {
        if (canvas.gameObject.activeInHierarchy == false)
        {
            canvas.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            canvas.gameObject.SetActive(false);
            Time.timeScale = 1;
        }
        aSrc.PlayOneShot(pauseFx);
    }
}
