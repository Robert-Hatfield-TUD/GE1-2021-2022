using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

public class Mover : MonoBehaviour
{
    private static StringBuilder message = new StringBuilder();

    public Transform target;

    public float speed = 5;
    public float time = 10;

    public void OnGUI()
    {
        GUI.color = Color.white;
        GUI.Label(new Rect(0, 0, Screen.width, Screen.height), "" + message);
        if (Event.current.type == EventType.Repaint)
        {
            message.Length = 0;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        float distance = Vector3.Distance(target.position, transform.position);
        speed = distance / time;

    }


    // Update is called once per frame
    void Update()
    {
    
        float distance = Vector3.Distance(target.position, transform.position);
        Vector3 toTarget = target.position - transform.position;
        float distance1 = toTarget.magnitude;

        //message.Append("\nDistance: " + distance + "\n");
        //message.Append("Distance1: " + distance1);

        toTarget = Vector3.Normalize(toTarget);
        
        /*
        if (distance1 > 0.1f)
        {        
            transform.position = transform.position + (toTarget * speed * Time.deltaTime);
        }
        message.Append("Time taken: " + Time.timeSinceLevelLoad);
        */

        /*        transform.LookAt(target);
        transform.Translate(0, 0, speed * Time.deltaTime);
        */

        float dot = Vector3.Dot(transform.forward, toTarget);
        float angle1 = Vector3.Angle(toTarget, transform.forward);
        //float theta = Mathf.Acos(dot) * Mathf.Rad2Deg;
        //Debug.Log("theta" +theta);
        //message.Append("Angle between mover & target: " + theta);
        //message.Append((dot > 0) ? "\nin front " : "\nbehind");
        if (angle1 < 45)
        {
            //message.Append("\nInside FOV");
        }
        else
        {
            //message.Append("\nOutside FOV");
        }

        //float angle1 = Vector3.Angle(toTarget, transform.forward);
        //Debug.Log("ang1 " + angle1);

        //float angle3 = Vector3.SignedAngle(toTarget, transform.forward, Vector3.up);
        //Debug.Log(angle3);
    }
}
