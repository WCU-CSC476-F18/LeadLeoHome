using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyMaker : MonoBehaviour {

    [Header("Set in Inspector")]
    public int numClouds = 20;//# of clouds to generate
    public GameObject cloudPrefab;//cloud prefab
    public Vector3 cloudPosMin = new Vector3(-50, -5, 10);//left/bottom border for cloud placement
    public Vector3 cloudPosMax = new Vector3(150, 1000, 25);//top/right border for cloud placement
    public float cloudScaleMin = 0.15f, cloudScaleMax = 0.65f, cloudSpeedMult = 1.0f;//size&speed of clouds

    private GameObject[] cloudInstances;

    private void Awake()
    {
        //array to hold all instances of clouds
        cloudInstances = new GameObject[numClouds];
        GameObject anchor = GameObject.Find("Sky");//find the CloudAnchor parent gameObject

        GameObject cloud;
        //iterate through cloud making
        for (int i=0; i < numClouds; i++)
        {
            cloud = Instantiate<GameObject>(cloudPrefab);
            //positioning
            Vector3 cPos = Vector3.zero;
            cPos.x = Random.Range(cloudPosMin.x, cloudPosMax.x);
            cPos.y = Random.Range(cloudPosMin.y, cloudPosMax.y);
            //scaling
            float scaleU = Random.value;
            float scaleVal = Mathf.Lerp(cloudScaleMin, cloudScaleMax, scaleU);

            //make smaller clouds position closer to the bottom to show distance
            cPos.y = Mathf.Lerp(cloudPosMin.y, cPos.y, scaleU);
            cPos.z = 100 - 90 * scaleU;

            //apply transformations to the cloud
            cloud.transform.position = cPos;
            cloud.transform.localScale = Vector3.one * scaleVal;
            //make cloud a child of the sky
            cloud.transform.SetParent(anchor.transform);
            cloudInstances[i] = cloud;//add the cloud to array of all clouds
        }
    }

    // Update is called once per frame
    void Update () {
		//iterate each cloud made
        foreach(GameObject cloud in cloudInstances)
        {
            //get scale & pos
            float scaleVal = cloud.transform.localScale.x;
            Vector3 cPos = cloud.transform.position;
            //move larger clouds faster for more realistic effect
            cPos.x -= scaleVal * Time.deltaTime * cloudSpeedMult;
            //if a cloud moves too far left...cut it and spawn one from the right
            if (cPos.x <= cloudPosMin.x)
                cPos.x = cloudPosMax.x;//move it to the far right

            //apply new pos to the cloud
            cloud.transform.position = cPos;

        }
	}
}
