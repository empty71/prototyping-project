using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GravityGun : MonoBehaviour
{

    [SerializeField] Camera cam;
    [SerializeField] float maxGrabDistance = 10f, throwForce = 20f, lerpSpeed = 10f;
    [SerializeField] Transform objectHolder;

    Rigidbody grabbedRB;
    bool isHolding = false;

    void Update()
    {
        if (isHolding && grabbedRB)
        {
            // Move the object to the holder position using interpolation
            Vector3 targetPosition = objectHolder.transform.position;
            Vector3 newPosition = Vector3.Lerp(grabbedRB.position, targetPosition, Time.deltaTime * lerpSpeed);

            // Check for collisions before moving the object
            if (!CheckCollision(grabbedRB.position, newPosition))
            {
                grabbedRB.MovePosition(newPosition);

                if (Input.GetMouseButtonUp(0))
                {
                    // Throw the object when the mouse button is released
                    ThrowObject();
                }
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (grabbedRB)
                {
                    // If we already have an object, release it
                    ReleaseObject();
                }
                else
                {
                    RaycastHit hit;
                    Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f));
                    int layerMask = ~LayerMask.GetMask("Ignore Raycast"); // Ignore the layer of the object we are grabbing
                    if (Physics.Raycast(ray, out hit, maxGrabDistance, layerMask))
                    {
                        grabbedRB = hit.collider.gameObject.GetComponent<Rigidbody>();
                        if (grabbedRB)
                        {
                            // Disable physics to allow smooth movement
                            grabbedRB.isKinematic = true;
                            isHolding = true;
                        }
                    }
                }
            }
        }
    }

    void ReleaseObject()
    {
        grabbedRB.isKinematic = false;
        grabbedRB = null;
        isHolding = false;
    }

    void ThrowObject()
    {
        grabbedRB.isKinematic = false;
        grabbedRB.AddForce(cam.transform.forward * throwForce, ForceMode.Impulse);
        grabbedRB = null;
        isHolding = false;
    }

    bool CheckCollision(Vector3 fromPosition, Vector3 toPosition)
    {
        Vector3 direction = toPosition - fromPosition;
        float distance = direction.magnitude;

        // Perform a raycast to check for collisions along the movement path
        RaycastHit[] hits;
        int layerMask = ~LayerMask.GetMask("Ignore Raycast"); // Ignore the layer of the object we are grabbing
        hits = Physics.RaycastAll(fromPosition, direction.normalized, distance, layerMask);

        foreach (var hit in hits)
        {
            if (!hit.collider.isTrigger) // Ignore trigger colliders
            {
                return true; // Collision detected, do not move the object
            }
        }
        return false; // No collision, move the object
    }
}