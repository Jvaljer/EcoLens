using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharksMovements : MonoBehaviour
{

    // Variables to store waypoints
    public GameObject[] waypoints;
    private int currentIndex = 0;
    private float speed = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        // Start at the last waypoint (assuming waypoints have valid elements)
        int index = waypoints.Length - 1;

        // Check if waypoints exist
        if (waypoints.Length > 0)
        {
            // Set fish position to the last waypoint
            transform.position = waypoints[index].transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {

        // Check if end of path reached
        if (currentIndex >= waypoints.Length)
        {
            // Choose your desired behavior at the end of the path:
            // - Loop the path: 
            currentIndex = 0;
        }

        // Check if the fish has reached the current waypoint
        if (Vector3.Distance(transform.position, waypoints[currentIndex].transform.position) < 0.1f)
        {
            // Reached waypoint, increment index
            currentIndex++;
        }

        // Check if not the last waypoint and waypoints exist
        if (currentIndex < waypoints.Length && waypoints.Length > 0)
        {
            // Calculate direction and update local forward
            Vector3 direction = (waypoints[currentIndex].transform.position - transform.position).normalized;
            transform.forward =  direction;
            transform.Rotate(new Vector3(0, 90, 0));
        }

        if (currentIndex < waypoints.Length)
        {
            // Move the fish towards the current waypoint
            transform.position = Vector3.MoveTowards(transform.position, waypoints[currentIndex].transform.position, speed * Time.deltaTime);
        }
    }
}
