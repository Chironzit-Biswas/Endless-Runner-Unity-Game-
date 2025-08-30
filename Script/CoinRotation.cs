using UnityEngine;

public class CoinRotation : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [Header("Rotation Speed")]
    public float rotationSpeed = 100f;

    public AudioClip collectSound; // Assign in Inspector
    public int scoreValue = 1;


    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Make sure your player has "Player" tag
        {
            // Play sound at coin's position
            AudioSource.PlayClipAtPoint(collectSound, transform.position);

            // Add score (if you have a GameManager)
            GameManager.instance.AddScore(scoreValue);

            // Destroy coin after collecting
            Destroy(gameObject);
        }
    }
}
