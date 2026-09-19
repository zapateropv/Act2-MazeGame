
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float bounceForce = 10f;

    private Rigidbody rb;
    private Vector3 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
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
}

