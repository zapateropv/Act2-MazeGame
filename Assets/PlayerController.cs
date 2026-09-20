
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float bounceForce = 10f;
    public Timer timer;

    public TextMeshProUGUI coinText;

    private Rigidbody rb;
    private Vector3 movement;
    private int coins = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        UpdateCoinText();
    }

    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        movement = new Vector3(x, 0f, z).normalized;
    }

    void FixedUpdate()
    {
        rb.AddForce(movement * speed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Hazard"))
        {
            rb.linearVelocity = new Vector3(
                rb.linearVelocity.x,
                bounceForce,
                rb.linearVelocity.z
            );
        }


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            coins++;

            timer.AddTime(5f);

            UpdateCoinText();

            Destroy(other.gameObject);
        }

    }

    void UpdateCoinText()
    {
        coinText.text = "Coins: " + coins;
    }
}

