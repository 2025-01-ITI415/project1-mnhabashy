using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadGuy : MonoBehaviour
{
    private Transform currentTarget;  // stores current target of bad guys
    public float speed = 10f;  // public variable for bad guy speed

    public Waypoint firstWaypoint;

    // will be called from Waypoint's OnTriggerEnter to update bad guys' target
    public void setNewTarget(Transform newTarget)
    {
        // sets new target
        currentTarget = newTarget;
    }

    // Start is called before the first frame update
    void Start()
    {
        // starts moving after delay of 1 second
        Invoke("StartMovement", 1f);
    }

    private void StartMovement()
    {
        // set first waypoint as target
        if (firstWaypoint != null)
        {
            currentTarget = firstWaypoint.transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // if BadGuy has a target, move towards it
        if (currentTarget != null)
        {
            // move towards target using Vector3.MoveTowards
            transform.position = Vector3.MoveTowards(transform.position, currentTarget.position, speed * Time.deltaTime);
        }
    }
}