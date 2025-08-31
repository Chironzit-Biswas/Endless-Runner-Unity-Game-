using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;



public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float playerSpeed = 20f;
    [SerializeField] private float playerHorizontalSpeed = 1f;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float xBoundary = 4f;
    [SerializeField] private GameManager gameManager;

    private bool isAlive = true;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (isAlive)
        {
            PlayerMovement();
        }
    }

    void PlayerMovement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        transform.Translate(horizontal * playerHorizontalSpeed, 0f, playerSpeed * Time.deltaTime);
        Boundary();
    }

    void Boundary()
    {
        if (transform.position.x < -xBoundary)
        {
            transform.position = new Vector3(-xBoundary, transform.position.y, transform.position.z);
        }
        if (transform.position.x > xBoundary)
        {
            transform.position = new Vector3(xBoundary, transform.position.y, transform.position.z);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("obstacles"))
        {
            isAlive = false; // stop movement
            //gameManager.restartPanel.SetActive(true); // show restart panel
            gameManager.GameOver();
        }
    }
}

