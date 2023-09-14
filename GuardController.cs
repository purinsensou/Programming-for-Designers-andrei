using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardController : MonoBehaviour
{
    public GameObject[] waypoints;
    public GameObject target;
    public int iterator = 0;
    private void NextWaypoint()
    {
        iterator++;
        iterator = iterator % waypoints.Length;
        target = waypoints[iterator];
    }
    private void TargetClosest()
    {
        GameObject closest = null;
        double shortest = double.MaxValue;
        foreach (var waypoint in waypoints)
        {
            double dist = Vector3.Distance(transform.position, waypoint.transform.position);
            if (dist < shortest)
            {
                shortest = dist;
                closest = waypoint;
            }
        }
        target = closest;
    }

    // Start is called before the first frame update
    void Start()
    {
        target = waypoints[0];
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dest = target.transform.position;
        Vector3 pos = transform.position;
        float distance = 2 * Time.deltaTime;

        if (pos.x > dest.x)
        {
            pos.x -= distance;
        }
        else
        {
            pos.x += distance;
        }

        transform.position = pos;

        //if (Mathf.Abs(pos.x - dest.x) < distance)
        // {
        // NextWaypoint();
        // }
    }
}
}
