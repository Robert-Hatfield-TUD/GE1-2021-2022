using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;


public class AITank : MonoBehaviour {

    private static StringBuilder message = new StringBuilder();

    public float radius = 10;
    public int numWaypoints = 5;
    public int current = 0;
    public List<Vector3> waypoints = new List<Vector3>();
    public float speed = 10;
    public Transform player;
    public Transform target;    

    public void OnDrawGizmos()
    {
    
        float theta = (Mathf.PI * 2.0f) / numWaypoints;
        for(int i = 0 ; i < numWaypoints ; i ++)
        {
            float angle = theta * i;
            Vector3 pos = new Vector3(Mathf.Sin(angle) * radius, 0, Mathf.Cos(angle) * radius);
            pos = transform.TransformPoint(pos);
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(pos, 1); 
        }

        // Task 1
        // Put code here to draw the gizmos
        // Use sin and cos to calculate the positions of the waypoints 
        // You can draw gizmos using
        // Gizmos.color = Color.green;
        // Gizmos.DrawWireSphere(pos, 1);
        
    }

    public void OnGUI()
    {
        GUI.color = Color.white;
        GUI.Label(new Rect(0, 0, Screen.width, Screen.height), "" + message);
        if (Event.current.type == EventType.Repaint)
        {
            message.Length = 0;
        }
    }

    // Use this for initialization
    void Awake () {
        float theta = (Mathf.PI * 2.0f) / numWaypoints;
        for(int i = 0 ; i < numWaypoints ; i ++)
        {
            float angle = theta * i;
            Vector3 pos = new Vector3(Mathf.Sin(angle) * radius, 0, Mathf.Cos(angle) * radius);
            pos = transform.TransformPoint(pos);
            waypoints.Add(pos); 
        }
    }

    // Update is called once per frame
    void Update () {
        // Task 3
        // Put code here to move the tank towards the next waypoint
        // When the tank reaches a waypoint you should advance to the next one

        Vector3 toTarget = waypoints[current] - transform.position;

        if (toTarget.magnitude < 1)
        {
            current = (current + 1) % waypoints.Count;
        }

        toTarget.Normalize();
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(toTarget), Time.deltaTime * 5);
        transform.Translate(toTarget * speed * Time.deltaTime, Space.World);

        // Task 4
        // Put code here to check if the player is in front of or behine the tank

        float distance = Vector3.Distance(target.position, transform.position);
        Vector3 toTarget1 = target.position - transform.position;
        float distance1 = toTarget1.magnitude;

        //message.Append("Distance: " + distance + "\n");
        //message.Append("Distance1: " + distance1 + "\n");

        if(distance < 10) {
            message.Append("In range\n");
        }
        else {
            message.Append("Not in range\n");
        }

        toTarget1 = Vector3.Normalize(toTarget1);

        float dot = Vector3.Dot(transform.forward, toTarget1);
        float angle1 = Vector3.Angle(toTarget1, transform.forward);


        
        // Task 5
        // Put code here to calculate if the player is inside the field of view and in range
        // You can print stuff to the screen using:

        message.Append((dot > 0) ? "in front " : "behind");
        if (angle1 < 45)
        {
            message.Append("\nInside FOV");
        }
        else
        {
            message.Append("\nOutside FOV");
        }



        //GameManager.Log("Hello from th AI tank");
    }
}
