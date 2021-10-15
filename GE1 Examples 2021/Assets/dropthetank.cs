using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dropthetank : MonoBehaviour
{

    public GameObject tank;

    int i = 0;
    System.Collections.IEnumerator Drop()
    {
        int maxcount = 5;

        while(true)
        {
            if(i < maxcount)
            {
                GameObject tankPre = GameObject.Instantiate<GameObject>(tank);
                tankPre.transform.position = new Vector3(0, 20, 0);
                tankPre.AddComponent<Rigidbody>();
                tankPre.tag = "brick";
                i++;
            }
            yield return new WaitForSeconds(1);
        }
       


    }

    public void OnEnable()
    {
        StartCoroutine(Drop());
    }

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
