using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    public Transform bulletSpawnPoint;
    public float damage = 10f;
    public float impactForce = 100f;
    public float range = 100f;
    public float firingRate = 15f;

    public Camera FPSCam;
    private float nextTimeToFire = 0f;



    private void Update()
    {
        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire) // Checks if the player is holding down the left mouse button and if the current time is greater than or equal to the next time to fire
        {

            nextTimeToFire = Time.time + 1f / firingRate; // Sets the next time to fire to the current time plus 1 divided by the firing rate
            Shoot(); // Calls the Shoot function

        }
    }

    void Shoot()
    {
        RaycastHit hit; // Creates a RaycastHit variable

        if (Physics.Raycast(FPSCam.transform.position, FPSCam.transform.forward, out hit, range)) // Checks if the raycast hits something
        {
            Debug.Log(hit.transform.name);

            if (hit.rigidbody != null) // Checks if the object that was hit has a rigidbody
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce); // Adds force to the rigidbody of the object that was hit
            }
            Target target = hit.transform.GetComponent<Target>(); // Gets the Target component of the object that was hit
            if (target != null) // Checks if the object that was hit has a Target component
            {
                target.TakeDamage(damage); // Calls the TakeDamage function of the Target component
            }
        }
    }
}
