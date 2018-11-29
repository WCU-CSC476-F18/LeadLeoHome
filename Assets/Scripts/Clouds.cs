using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clouds : MonoBehaviour {

    [Header("Set in Inspector")]
    public GameObject cloud;
    public int numCloudsMin = 4, numCloudsMax = 10;
    public Vector3 cloudOffsetScale = new Vector3(5, 2, 1);
    public Vector2 cloudScaleRangeX = new Vector2(4, 8);
    public Vector2 cloudScaleRangeY = new Vector2(3, 4);
    public Vector2 cloudScaleRangeZ = new Vector2(2, 4);
    public float scaleYMin = 2.0f;

    private List<GameObject> clouds;

    // Use this for initialization
    void Start () {
        clouds = new List<GameObject>();

        int num = Random.Range(numCloudsMin, numCloudsMax);
        for(int i = 0; i < num; i++)
        {
            GameObject cl = Instantiate<GameObject>(cloud);
            clouds.Add(cl);
            Transform clTrans = cl.transform;
            clTrans.SetParent(this.transform);

            //randomly assign cloud position
            Vector3 offset = Random.insideUnitSphere;
            offset.x *= cloudOffsetScale.x;
            offset.y *= cloudOffsetScale.y;
            offset.z *= cloudOffsetScale.z;
            clTrans.localPosition = offset;

            //randomly make clouds bigger/smaller
            Vector3 scale = Vector3.one;
            scale.x = Random.Range(cloudScaleRangeX.x, cloudScaleRangeX.y);
            scale.y = Random.Range(cloudScaleRangeY.x, cloudScaleRangeY.y);
            scale.z = Random.Range(cloudScaleRangeZ.x, cloudScaleRangeZ.y);

            //adjust y scale by x-distance from the core
            scale.y *= 1 - (Mathf.Abs(offset.x) / cloudOffsetScale.x);
            scale.y = Mathf.Max(scale.y, scaleYMin);

            clTrans.localScale = scale;
        }

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    
}
