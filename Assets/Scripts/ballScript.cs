using UnityEngine;
using UnityEngine.UI;

using UnityEngine.SceneManagement;

public class ballScript : MonoBehaviour {

	[SerializeField]
	float drag;
	Rigidbody rb;
	[SerializeField]
	AudioClip squeek;

	[SerializeField]
	float sandDrag;	
	[SerializeField]
	float iceDrag;
	[SerializeField]
	float defaultDrag;


	public AudioClip fireworks;
    public GameObject fireworkPre;
    public Text scoreText;
    public Text winText;

	AudioSource audio;

	public Transform RespawnPoint;

	private float playerScore;


	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
		drag = defaultDrag;

		playerScore = 0;

        audio = GetComponent<AudioSource>();
        scoreText.text = "Score: 0";
        winText.text = "";
	}
	
	// Update is called once per frame
	void Update () {
		transform.GetChild(0).gameObject.GetComponent<AudioSource>().volume = Mathf.Clamp(3 * rb.velocity.magnitude,0,1);

		rb.angularDrag = drag;

		if(Vector3.Distance(this.transform.position, RespawnPoint.position) >= 50.0f) {
			RespawnBall ();
			//Debug.Log ("forced respawn");
		}
	}

	public void RespawnBall() {
		this.transform.position = RespawnPoint.position;
		rb.velocity = Vector3.zero;
	}

	void OnCollisionEnter(Collision col){
		//print(col.relativeVelocity.magnitude);
		if(col.relativeVelocity.magnitude > 5){
			//audio.PlayOneShot(squeek,1.0f); --doesn't sound good
		}
	}

	void OnTriggerEnter(Collider col){
		// sand around holes as a safety net for player
		if (col.tag == "sand") {
			drag = sandDrag;
			Debug.Log ("Dragging");
		} else if (col.tag == "ice") {
			drag = iceDrag;
			Debug.Log ("Slippery");
		} else if (col.tag == "checkpoint") {
			RespawnPoint.position = col.transform.position;
			col.gameObject.GetComponent<Animator> ().SetTrigger ("check");
			audio.PlayOneShot (fireworks);
		} else if (col.tag == "Respawn") {
			RespawnBall ();
		} else if (col.tag == "pickup") {
			col.gameObject.GetComponent<bugScript> ().die ();
			playerScore += 100;
			Debug.Log (playerScore);
            scoreText.text = "Score: " + playerScore;
        }
        else if (col.tag == "Finish") {
            winText.text = "You Win!";
			Invoke("now2",2);
			audio.PlayOneShot(fireworks);
		}
	}

	void now2(){
		SceneManager.LoadScene(1);
	}

	void OnTriggerExit(Collider col){
		if (col.tag == "sand") {
			drag = defaultDrag;
			Debug.Log ("Free");
		} else if (col.tag == "ice") {
			drag = defaultDrag;
			Debug.Log ("Free");
		}
	}
	
}
