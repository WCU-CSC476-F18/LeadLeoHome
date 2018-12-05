using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeoControls : MonoBehaviour {

    public float speed = 0.5f;

    private Rigidbody rb;

	// Use this for initialization
	void Awake () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        float moveX = Input.GetAxis("Horizontal") * 15;
        float moveY = Input.GetAxis("Vertical") * 15;
        Vector3 movement = new Vector3(moveX, 0.0f, moveY);
        //rb.AddForce(movement * speed);
        
        movement.x = moveX;
        movement.y = moveY;
        rb.velocity = movement*speed;
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

        //transform.rotation = Quaternion.Slerp(Quaternion.LookRotation(movement), transform.rotation, 0.15F);
        /*
        bool flipSpriteX = (spriteRenderer.flipX ? (movement.x > 0.01f) : (movement.x < 0.01f));
        bool flipSpriteY = (spriteRenderer.flipY ? (movement.y > 0.01f) : (movement.y < 0.01f));
        if (flipSpriteX)
            spriteRenderer.flipX = !spriteRenderer.flipX;
        if (flipSpriteY)
            spriteRenderer.flipY = !spriteRenderer.flipY;*/
    }
}
