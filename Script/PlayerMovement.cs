using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float speed = 6f;
    public Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate()
    {
        
     transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

}
