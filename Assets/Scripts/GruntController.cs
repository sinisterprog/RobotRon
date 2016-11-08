using UnityEngine;
using System.Collections;

public class GruntController : MonoBehaviour
{
    private Transform player;
    public void Awake() 
    {
        player = GameObject.FindGameObjectWithTag ("Player").transform;
    }
    public float speed = 2;
    public float homingSensitivity = 1;
    // Use this for initialization
    void Start()
    {
        GetComponent<Rigidbody>().velocity = transform.forward * speed;
    }

    void Update()
    {
        if (player != null)
        {
            Vector3 relativePos = player.position - transform.position;
            Quaternion rotation =  Quaternion.LookRotation(relativePos);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, homingSensitivity);
        }

        transform.Translate(0, 0, speed * Time.deltaTime, Space.Self);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet")
        {
            Debug.Log("Watch this!");
            gameObject.AddComponent<TriangleExplosion>();
            StartCoroutine(gameObject.GetComponent <TriangleExplosion>().SplitMesh(true));
            Destroy(other);
        }
    }
}
