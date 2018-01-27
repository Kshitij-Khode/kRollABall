using UnityEngine;
using UnityEngine.UI;

public class playerController : MonoBehaviour {
    private Rigidbody rb;
    private int count;

    public float moveSpeed;
    public Text countText;
    public Text winText;

	void Start ()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winText.text = "";
    }

    void FixedUpdate ()
    {
        rb.AddForce(moveSpeed*(new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"))));
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("pickup"))
        {
            other.gameObject.SetActive(false);
            count++;
            SetCountText();
        }
    }

    void SetCountText()
    {
        countText.text = "Count" + count.ToString();
        if (count >= 12)
        {
            winText.text = "You Win!";
        }
    }
}
