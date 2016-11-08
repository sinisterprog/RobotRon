using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour
{

    public float lifetime = 2f;
    public float speed = 2f;
    public float twat;
    Rigidbody rb;
    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * speed;
        Destroy(gameObject, lifetime);
    }

    void OnTriggerEnter(Collider other)
    {
        
        Debug.Log("Boing!" + transform.rotation.y);
        if (other.tag == "TopWall")
        {
            rb.velocity = -transform.forward * speed;
            float xSpeed = rb.velocity.x;
            rb.velocity = new Vector3(-xSpeed, 0f, rb.velocity.z);
            
        }
        else if (other.tag == "SideWall")
        {
            rb.velocity = -transform.forward * speed;
            float zSpeed = rb.velocity.z;
            rb.velocity = new Vector3(rb.velocity.x, 0f, -zSpeed);
            
        }
        transform.rotation = Quaternion.LookRotation(rb.velocity);

    }
  
}
