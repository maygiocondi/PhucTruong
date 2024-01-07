using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float moveSpeed = 5f;

    public float distanceZ;

    Plane plane;
    Vector3 distanceFromCamera;

    void Star()
    {
        distanceFromCamera = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, Camera.main.transform.position.z - distanceZ);
        plane = new Plane(Vector3.forward, distanceFromCamera);
    }

    void Update()
    {
        // Check if the left mouse button is pressed
        if (Input.GetMouseButtonDown(0))
        {
            // Get the mouse position in screen coordinates
            Vector3 mousePos = Input.mousePosition;

            // Convert the screen coordinates to a ray
            Ray ray = Camera.main.ScreenPointToRay(mousePos);

            float hitDist;

            // Check if the ray intersects with the plane
            if (plane.Raycast(ray, out hitDist))
            {
                // Get the point where the ray intersects with the plane
                Vector3 targetPoint = ray.GetPoint(hitDist);

                // Move the player towards the target point
                transform.LookAt(targetPoint);
                transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
            }
        }
    }

    // void Move()
    // {
    //     if (Input.GetMouseButton(0))
    //     {
    //         Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    //         RaycastHit hit;

    //         if (Physics.Raycast(ray, out hit))
    //         {
    //             agent.SetDestination(hit.point);
    //         }
    //     }
    // }
}
