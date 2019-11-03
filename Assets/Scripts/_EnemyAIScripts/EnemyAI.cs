 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This class controls the enemies AI
public class EnemyAI : MonoBehaviour
{
    private const float MAX_DISTANCE = 10F;

    // Reference to the MushroomMon_Ani_Test script
    MushroomMon_Ani_Test mushroom;

    [SerializeField]
    private Color tintColor = Color.green;

    [SerializeField]
    private Color tintColorForRayCastAll = Color.yellow;

    [SerializeField]
    private LayerMask layerMask;

    private bool multiple;

    void Update()
    {
        RayCastSingle(); 
    }

    private void RayCastSingle() 
    {
        // Get the origin of the Ray/Line
        Vector3 origin = transform.position;

        // Point the Ray in the forward direction
        Vector3 direction = transform.forward;

        // Draw the ray on the screen from it's
        // origin, then point it foward * 10 to
        //  determine the distances it travels 
        Debug.DrawRay(origin, direction * MAX_DISTANCE, Color.red);

        // Create a new ray by passing in the origin
        // and the direction it should travel
        Ray ray = new Ray(origin, direction);

        if(Physics.Raycast(ray, out RaycastHit rayCastHit, MAX_DISTANCE, layerMask))
        {

            rayCastHit.collider.GetComponent<Renderer>().material.color = tintColor;
            Debug.Log("Seen");
        }
    }

    void RayCastAll()
    {
        // Get the origin of the Ray/Line
        Vector3 origin = transform.position;

        // Point the Ray in the forward direction
        Vector3 direction = transform.forward;

        // Draw the ray on the screen from it's
        // origin, then point it foward * 10 to
        //  determine the distances it travels 
        Debug.DrawRay(origin, direction * MAX_DISTANCE, Color.yellow);

        // Create a new ray by passing in the origin
        // and the direction it should travel
        Ray ray = new Ray(origin, direction);

        var multipleHits = Physics.RaycastAll(ray);

       foreach(var rayCastHit in multipleHits)
        {
            rayCastHit.collider.GetComponent<Renderer>().material.color = tintColor;
        }
    }
}