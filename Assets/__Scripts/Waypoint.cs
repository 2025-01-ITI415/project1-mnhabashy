using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    public List <Waypoint> neighbors;

    private void OnTriggerEnter(Collider other) {
        // tells bad guy to go to new waypoint
        if (other.gameObject.CompareTag("Bad Guy")) {
            // gets BadGuy script
            BadGuy badGuyScript = other.gameObject.GetComponent<BadGuy>();

            if (badGuyScript != null)
            {
                // chooses random new waypoint from Neighbors list
                Waypoint newTarget = GetRandomNeighbor();

                // repeats until we get waypoint that's not current waypoint
                while (newTarget == this)
                {
                    newTarget = GetRandomNeighbor();
                }

                // calls setNewTarget method from BadGuy script to update target
                badGuyScript.setNewTarget(newTarget.transform);
            }
        }
    }

    // gets random neighbor
    private Waypoint GetRandomNeighbor()
    {
        if (neighbors.Count == 0) return null;

        int randomIndex = Random.Range(0, neighbors.Count);
        return neighbors[randomIndex];
    }
}