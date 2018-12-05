using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamController : MonoBehaviour {

    public GameObject leo;
    private Vector3 offset;

	// Use this for initialization
	void Start () {
        offset = transform.position - leo.transform.position;
	}
	
	// Update is called once per frame
	void LateUpdate () {
        transform.position = leo.transform.position + offset;
	}
}
