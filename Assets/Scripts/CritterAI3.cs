using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CritterAI3 : MonoBehaviour {

    public Transform t1, t2, t3, t4, t5, t6, t7, t8;
    public float speed = 4.0f;
    public bool walkDown = true;
    public bool walkUp = false;
    public bool walkLeft = false;
    public bool walkRight = false;
    int countDown=1, countUp=0, countRight=0;//these num will tell the which waypoint its at

    private void Update()
    {
        float step = speed * Time.deltaTime;

        float dist1 = Vector3.Distance(gameObject.transform.position, t1.transform.position);
        float dist2 = Vector3.Distance(gameObject.transform.position, t2.transform.position);
        float dist3 = Vector3.Distance(gameObject.transform.position, t3.transform.position);
        float dist4 = Vector3.Distance(gameObject.transform.position, t4.transform.position);
        float dist5 = Vector3.Distance(gameObject.transform.position, t5.transform.position);
        float dist6 = Vector3.Distance(gameObject.transform.position, t6.transform.position);
        float dist7 = Vector3.Distance(gameObject.transform.position, t7.transform.position);
        float dist8 = Vector3.Distance(gameObject.transform.position, t8.transform.position);

        if (walkUp)
        {
            switch (countUp)
            {
                case 0:
                    transform.position = Vector3.MoveTowards(transform.position, t3.transform.position, step);
                    if (dist3 < 1)
                    {
                        walkUp = false;
                        walkRight = true;
                        transform.eulerAngles = new Vector3(0, 0, -90);
                        countUp++;
                    }
                    break;

                case 1:
                    transform.position = Vector3.MoveTowards(transform.position, t7.transform.position, step);
                    if (dist7 < 1)
                    {
                        walkUp = false;
                        walkRight = true;
                        transform.eulerAngles = new Vector3(0, 0, -90);
                        countUp = 0;
                    }
                    break;
            }


        }

        if (walkDown)
        {
            switch (countDown)
            {
                case 0:
                    transform.position = Vector3.MoveTowards(transform.position, t5.transform.position, step);
                    if (dist5 < 1)
                    {
                        walkDown = false;
                        walkRight = true;
                        transform.eulerAngles = new Vector3(0, 0, -90);
                        countDown++;
                    }
                    break;
                case 1:
                    transform.position = Vector3.MoveTowards(transform.position, t1.transform.position, step);
                    if (dist1 < 1)
                    {
                        walkDown = false;
                        walkLeft = true;
                        transform.eulerAngles = new Vector3(0, 0, 90);
                        countDown = 0;
                    }
                    break;
            }
        }

        if (walkRight)
        {
            switch (countRight)
            {
                case 0:
                    transform.position = Vector3.MoveTowards(transform.position, t4.transform.position, step);
                    if (dist4 < 1)
                    {
                        walkRight = false;
                        walkDown = true;
                        transform.eulerAngles = new Vector3(0, 0, 180);
                        countRight++;
                    }
                    break;
                case 1:
                    transform.position = Vector3.MoveTowards(transform.position, t6.transform.position, step);
                    if (dist6 < 1)
                    {
                        walkRight = false;
                        walkUp = true;
                        transform.eulerAngles = new Vector3(0, 0, 0);
                        countRight++;
                    }
                    break;
                case 2:
                    transform.position = Vector3.MoveTowards(transform.position, t8.transform.position, step);
                    if (dist8 < 1)
                    {
                        walkRight = false;
                        walkDown = true;
                        transform.eulerAngles = new Vector3(0, 0, 180);
                        countRight = 0;
                    }
                    break;
            }
        }

        if (walkLeft)
        {
            transform.position = Vector3.MoveTowards(transform.position, t2.transform.position, step);
            if (dist2 < 1)
            {
                walkLeft = false;
                walkUp = true;
                transform.eulerAngles = new Vector3(0, 0, 0);
            }
        }

    }
}
