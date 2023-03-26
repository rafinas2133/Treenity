using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPointBehaviour : MonoBehaviour
{

    [SerializeField] GameObject[] waypoints;
    private int currentWaypointIndex = 0;
    
    [SerializeField] private float speed = 2f;

    private void Update() {
        //Menghitung jarak platform dengan waypoint sesuai index
        if (Vector2.Distance(this.waypoints[this.currentWaypointIndex].transform.position, transform.position) < .1f) {
            //Reset index waypoint
            if (++this.currentWaypointIndex == this.waypoints.Length) {
                this.currentWaypointIndex = 0;
            }
        }
        //Gerakkan platform ke waypoint sesuai index dengan kecepatan yang tertera
        transform.position = Vector2.MoveTowards(transform.position, this.waypoints[this.currentWaypointIndex].transform.position, this.speed * Time.deltaTime);
    }

}
