using UnityEngine;

public class CollectCoins : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnTriggerEnter(Collider other) 
    { if (other.CompareTag("Coin")) { Destroy(other.gameObject); } 
    }
}
