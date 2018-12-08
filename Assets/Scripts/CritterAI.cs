using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CritterAI : MonoBehaviour {

    public Transform target1, target2;
    public float speed = 4.0f;
    public bool walkLeft = false;
    public bool walkRight = true;

    private void Update()
    {
        float step = speed * Time.deltaTime;

        float dist1 = Vector3.Distance(gameObject.transform.position, target1.transform.position);
        float dist2 = Vector3.Distance(gameObject.transform.position, target2.transform.position);
        if(walkRight)
        {
            transform.position = Vector3.MoveTowards(transform.position, target2.transform.position, step);
            if(dist2 < 1)
            {
                walkRight = false;
                walkLeft = true;
                transform.eulerAngles = new Vector3(0, 0, 90);
            }
        }

        if(walkLeft)
        {
            transform.position = Vector3.MoveTowards(transform.position, target1.transform.position, step);
            if(dist1 < 1)
            {
                walkLeft = false;
                walkRight = true;
                transform.eulerAngles = new Vector3(0, 0, -90);
            }
        }
        
    }
}
