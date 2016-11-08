using UnityEngine;
using System.Collections;

public class PlayerShootScript : MonoBehaviour {

    public int damagePerShot = 20;
    public float timeBetweenBullets = 0.15f;
    public float range = 100f;
    public GameObject shot;

    float timer;

    int shootableMask;
    Light gunLight;
    float effectsDisplayTime = 0.2f;

    void Awake()
    {
        shootableMask = LayerMask.GetMask("Shootable");
        gunLight = GetComponent< Light > ();

    }
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        if (Input.GetButton("Fire1") && timer > timeBetweenBullets)
        {
            Shoot();
        }
        if (timer >= timeBetweenBullets * effectsDisplayTime)
        {
            DisableEffects();
        }
	}
    public void DisableEffects()
    {
        gunLight.enabled = false;
    }
    void Shoot()
    {
        timer = 0f;
        gunLight.enabled = true;
        /*
        gunLine.enabled = true;
        gunLine.SetPosition(0, transform.position);
        shootRay.origin = transform.position;
        shootRay.direction = transform.forward;
        gunLine.SetPosition(1, shootRay.origin + shootRay.direction * range);
        */
        Instantiate(shot, transform.position, transform.rotation);

    }
}
