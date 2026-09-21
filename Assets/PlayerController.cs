
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float bounceForce = 10f;

    public Timer timer;

    // Coin UI
    public TextMeshProUGUI coinText;

    // Win UI
    public GameObject winPanel;
    public TextMeshProUGUI winText;
    public TextMeshProUGUI totalCoinsText;

    private Rigidbody rb;
    private Vector3 movement;
    private int coins = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        // Hide the win popup when the game starts
        winPanel.SetActive(false);

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
        // Player hits Hazard
        if (collision.gameObject.CompareTag("Hazard"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        // Player reaches Indicator
        if (collision.gameObject.CompareTag("Indicator"))
        {
            WinGame();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Player collects Coin
        if (other.CompareTag("Coin"))
        {
            coins++;

            // Add 5 seconds to timer
            timer.AddTime(5f);

            UpdateCoinText();

            Destroy(other.gameObject);
        }
    }

    void WinGame()
    {
        // Show Win Panel
        winPanel.SetActive(true);

        // Show "YOU WON!"
        winText.text = "YOU WON!";

        // Show total coins
        totalCoinsText.text = "Total Coins Collected: " + coins;

        // Stop timer
        timer.StopTimer();

        // Stop player movement
        rb.linearVelocity = Vector3.zero;

        // Freeze the game
        Time.timeScale = 0f;
    }

    void UpdateCoinText()
    {
        coinText.text = "Coins: " + coins;
    }
}

