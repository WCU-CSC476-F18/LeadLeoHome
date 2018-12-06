using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeoControls : MonoBehaviour {

    public float speed = 0.35f;

    private Rigidbody rb;

	// Use this for initialization
	void Awake () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        //get user input to make leo move
        float moveX = Input.GetAxis("Horizontal") * 15;
        float moveY = Input.GetAxis("Vertical") * 15;
        Vector3 movement = new Vector3(moveX, 0.0f, moveY);
        
        //add user input to Leo's velocity
        movement.x = moveX;
        movement.y = moveY;
        rb.velocity = movement*speed;

        //code to make leo face the direction of movement
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.eulerAngles = new Vector3(0, 0, 90);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.eulerAngles = new Vector3(0, 0, -90);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.eulerAngles = new Vector3(0, 0, 180);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        if(Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.DownArrow))
        {
            transform.eulerAngles = new Vector3(0, 0, 135);
        }
        if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.UpArrow))
        {
            transform.eulerAngles = new Vector3(0, 0, 45);
        }
        if (Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.DownArrow))
        {
            transform.eulerAngles = new Vector3(0, 0, -135);
        }
        if (Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.UpArrow))
        {
            transform.eulerAngles = new Vector3(0, 0, -45);
        }


    }//end fixedupdate




    //variable to keep track of what tree area leo is currently in
    private int woodsLevel = 1;
    //bool to make sure that the trigger doesnt fire more than once
    bool isTriggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (isTriggered == false)
        {
            //if leo picked the right path--progress to next area
            if (other.gameObject.CompareTag("Finish"))
            {
                isTriggered = true;//set this to true so that the trigger isnt activated more than once
                woodsLevel++;
                WoodsLevelHandler(woodsLevel);
            }
            //if leo picked the wrong path--set back to area 1
            if (other.gameObject.CompareTag("Respawn"))
            {
                isTriggered = true;//set this to true so that the trigger isnt activated more than once
                woodsLevel = 1;
                WoodsLevelHandler(woodsLevel);
            }
            //isTriggered = true;//set this to true so that the trigger isnt activated more than once
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        isTriggered = false;
    }

    //handles where to "teleport" leo depending on the path choice
    void WoodsLevelHandler(int level)
    {
        //there are 7 wooded areas
        switch (level)
        {
            case 1:
                rb.transform.position = new Vector3(0.0f, 0.0f, -1.0f);
                rb.velocity = Vector3.zero;//make sure they dont carry their momentum in the next room
                break;
            case 2:
                rb.transform.position = new Vector3(0.0f, 15.0f, -1.0f);
                rb.velocity = Vector3.zero;//make sure they dont carry their momentum in the next room
                break;
            case 3:
                rb.transform.position = new Vector3(0.0f, 30.0f, -1.0f);
                rb.velocity = Vector3.zero;//make sure they dont carry their momentum in the next room
                break;
            case 4:
                rb.transform.position = new Vector3(0.0f, 45.0f, -1.0f);
                rb.velocity = Vector3.zero;//make sure they dont carry their momentum in the next room
                break;
            case 5:
                rb.transform.position = new Vector3(0.0f, 60.0f, -1.0f);
                rb.velocity = Vector3.zero;//make sure they dont carry their momentum in the next room
                break;
            case 6:
                rb.transform.position = new Vector3(0.0f, 75.0f, -1.0f);
                rb.velocity = Vector3.zero;//make sure they dont carry their momentum in the next room
                break;
            case 7:
                rb.transform.position = new Vector3(0.0f, 90.0f, -1.0f);
                rb.velocity = Vector3.zero;//make sure they dont carry their momentum in the next room
                break;
            case 8:
                //teleport to level 2 - the river
                rb.transform.position = new Vector3(60.0f, 0.0f, -1.0f);
                rb.velocity = Vector3.zero;//make sure they dont carry their momentum in the next room
                break;
        }
    }
}
