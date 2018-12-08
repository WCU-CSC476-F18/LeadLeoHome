using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CritterAI2 : MonoBehaviour {

    public Transform target1, target2;
    public float speed = 4.0f;
    public bool walkDown = true;
    public bool walkUp = false;

    private void Update()
    {
        float step = speed * Time.deltaTime;

        float dist1 = Vector3.Distance(gameObject.transform.position, target1.transform.position);
        float dist2 = Vector3.Distance(gameObject.transform.position, target2.transform.position);
        if (walkUp)
        {
            transform.position = Vector3.MoveTowards(transform.position, target2.transform.position, step);
            if (dist2 < 1)
            {
                walkUp = false;
                walkDown = true;
                transform.eulerAngles = new Vector3(0, 0, 0);
            }
        }

        if (walkDown)
        {
            transform.position = Vector3.MoveTowards(transform.position, target1.transform.position, step);
            if (dist1 < 1)
            {
                walkDown = false;
                walkUp = true;
                transform.eulerAngles = new Vector3(0, 0, 180);
            }
        }

    }
}
