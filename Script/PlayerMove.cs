using UnityEngine;
using UnityEngine.UI;


public class PlayerMove : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private float plaerSpeed = 10f;
    [SerializeField] private float playerHorizontalSpeed = 3f;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float xBoundary = 4f;



    void Start()
    {
        rb = GetComponent<Rigidbody>();
    
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void FixedUpdate()
    {
        Playermove();
    }

    void Playermove()
    {
        float horizontal = Input.GetAxis("Horizontal");
        transform.Translate(horizontal * playerHorizontalSpeed * Time.deltaTime, 0f, plaerSpeed * Time.deltaTime);
        Boundary();
    }


    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.CompareTag("coin"))
    //    {
    //        Destroy(other.gameObject);
    //        score++;
    //        scoreText.text = score.ToString();

    //    }
    //}

    //void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.CompareTag("Obstacle"))
    //    {
    //        // Handle game over logic here
    //        Debug.Log("Game Over!");
    //        // For example, you might want to stop the player's movement
    //        plaerSpeed = 0f;
    //        playerHorizontalSpeed = 0f;
    //    }
    //}

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

}
