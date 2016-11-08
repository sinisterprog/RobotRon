using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
    public float speed = 3f;
    Vector3 movement;
    Rigidbody playerRigidBody;
    Transform  gunTransform;
    int floorMask;
    float camRayLength = 100f;

    void Awake()
    {
        floorMask = LayerMask.GetMask("Floor");
        playerRigidBody = GetComponent<Rigidbody>();
        gunTransform = transform.Find("Gun").gameObject.transform;
        if (gunTransform == null)
        {
            Debug.Log("Can't find the gun");
        }
    }

    void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        Move(h,v);
        Turning();
	}
    void Move (float h, float v)
    {
        movement.Set(h, 0f, v);
        movement = movement.normalized * speed * Time.deltaTime;
        playerRigidBody.MovePosition(transform.position + movement);
    }
    void Turning()
    {
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit floorHit;
        if (Physics.Raycast(camRay, out floorHit, camRayLength, floorMask))
        {
            gunTransform = transform.Find("Gun").gameObject.transform;

            Vector3 playerToMouse = floorHit.point - gunTransform.position; // was transform
            playerToMouse.y = 0f;
            Quaternion newRotation = Quaternion.LookRotation(playerToMouse);
            playerRigidBody.MoveRotation(newRotation);
        }

    }
}
