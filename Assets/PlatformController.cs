using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WaypointsFree;

public class PlatformController : MonoBehaviour
{
    public WaypointsGroup waypointsGroup;
    public float speed;

    Collider2D collider;
    List<Waypoint> waypoints;
    Waypoint nextwp;
    int index;
    Bounds nextwpbounds;

    // Start is called before the first frame update
    void Start()
    {
        waypoints = waypointsGroup.waypoints;
        index = 0;
        nextwp = waypoints[index];
        nextwpbounds = new Bounds(nextwp.position, Vector3.one);
        collider = transform.GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (collider.bounds.Intersects(nextwpbounds))
        {
            index = index < waypoints.Count - 1 ? index + 1 : 0;
            nextwp = waypoints[index];
            nextwpbounds = new Bounds(nextwp.position, Vector3.one);
        }
        else
            transform.position = Vector3.MoveTowards(transform.position, nextwp.position, speed * Time.deltaTime);
    }

}
