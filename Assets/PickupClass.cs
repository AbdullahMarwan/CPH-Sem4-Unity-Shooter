using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickClass : MonoBehaviour
{
    [SerializeField] private LayerMask PickupLayer;
    [SerializeField] private Camera PlayerCamera;
    [SerializeField] private float ThrowingForce;
    [SerializeField] private float PickupRange;
    [SerializeField] private Transform Hand;

    private Rigidbody CurrrentObjectRigidbody;
    private Collider CurrentObjectCollider;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            Ray PickupRay = new Ray(PlayerCamera.transform.position, PlayerCamera.transform.forward);

            if (Physics.Raycast(PickupRay, out RaycastHit HitInfo, PickupRange, PickupLayer))
            {
                if (CurrrentObjectRigidbody)
                {
                    CurrrentObjectRigidbody.isKinematic = false;
                    CurrentObjectCollider.enabled = true;

                    CurrrentObjectRigidbody = HitInfo.rigidbody;
                    CurrentObjectCollider = HitInfo.collider;

                    CurrrentObjectRigidbody.isKinematic = true;
                    CurrentObjectCollider.enabled = false;

                }
                else
                {
                    CurrrentObjectRigidbody = HitInfo.rigidbody;
                    CurrentObjectCollider = HitInfo.collider;

                    CurrrentObjectRigidbody.isKinematic = true;
                    CurrentObjectCollider.enabled = false;
                }

                return;

            }

            if (CurrrentObjectRigidbody)
            {
                CurrrentObjectRigidbody.isKinematic = false;
                CurrentObjectCollider.enabled = true;

                CurrrentObjectRigidbody = null;
                CurrentObjectCollider = null;
            }
        }

        if (Input.GetKeyDown(KeyCode.V))
        {
            if (CurrrentObjectRigidbody)
            {
                CurrrentObjectRigidbody.isKinematic = false;
                CurrentObjectCollider.enabled = true;

                CurrrentObjectRigidbody.AddForce(PlayerCamera.transform.forward * ThrowingForce, ForceMode.Impulse);

                CurrrentObjectRigidbody = null;
                CurrentObjectCollider = null;
            }
        }

        if (CurrrentObjectRigidbody)
        {
            CurrrentObjectRigidbody.position = Hand.position;
            CurrrentObjectRigidbody.rotation = Hand.rotation;
        }

    }
}
