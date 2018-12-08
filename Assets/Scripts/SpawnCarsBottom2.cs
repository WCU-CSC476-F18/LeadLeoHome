using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCarsBottom2 : MonoBehaviour
{

    public GameObject[] cars;
    public GameObject car;
    public Transform carSpwn, carExit;//car spawners and car exits
    public float carSpeed = 1.0f;
    public Vector3 limit = new Vector3(0.0f, 19.0f, 0.0f);

    void SpawnCar()
    {

        car = Instantiate<GameObject>(cars[Random.Range(0, cars.Length)]);
        car.transform.position = transform.position;


    }
    // Use this for initialization
    void Start()
    {
        Invoke("SpawnCar", Random.Range(0.5f, 1.0f));

    }

    // Update is called once per frame
    void Update()
    {
        float step = carSpeed * Time.deltaTime;
        if (car)
        {
            car.transform.position = Vector3.MoveTowards(car.transform.position, carExit.transform.position, step);
            if (car.transform.position.y < limit.y)
                car.transform.position = Vector3.MoveTowards(car.transform.position, carExit.transform.position, step);
            else if (car.transform.position.y > limit.y)
            {
                Destroy(car);
                Invoke("SpawnCar", 0.0f);
            }
        }
    }
}