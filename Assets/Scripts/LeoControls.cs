﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LeoControls : MonoBehaviour {
    
    //used to print the time
    public Text runningTime, woodsTime, riverTime, fieldsTime, highwayTime;
    float gameTimer = 0.0f;//used in Update
    float levelTimer = 0.0f;
    bool gameOver = false;
    bool woodsDone = false;
    bool riverDone = true;
    bool fieldsDone = true;
    bool highwayDone = true;
    int s, m, woodsSec, woodsMin, riverSec, riverMin, fieldsSec, fieldsMin, highwaySec, highwayMin;

    //paw prints to leave the correct trail once found in woodslevel
    public GameObject pp1, pp2, pp3, pp4, pp5, pp6;

    //branches that leo must pick up in level 2--mouthBranch is the 
    //branch that leo will be carrying in his mouth
    public GameObject b1, b2, b3, b4, b5, mouthBranch;

    //river parts that will be deleted with each branch
    public GameObject r1, r2, r3, r4, r5;

    //bool used to make leo distracted for 5s if hit by a critter
    bool distracted = false;
    float distractTime = 0.0f;
    int danceDirection = 0;
    AudioSource bark;

    //bool used to see if animal control should come or not
    bool timeUp = false;

    //Leo's speed
    public float speed = 0.4f;

    private Rigidbody rb;

	// Use this for initialization
	void Awake () {

        rb = GetComponent<Rigidbody>();

        Physics.gravity = new Vector3(0.0f, 0.0f, 50.0f);//set gravity going into the screen

        //get the bark ready for if leo hits a critter
        bark = GetComponent<AudioSource>();
        bark.Play(0);
        bark.Pause();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (!timeUp)//there is still time before animal control comes
        {
            if (distracted)
            {
                //count to 5 and meanwhile make leo do some shit
                distractTime += Time.deltaTime;
                if (distractTime > 5)
                {
                    distracted = false;
                    bark.Pause();
                }
                if (distractTime % (.25) < 0.02)
                {
                    switch (danceDirection)
                    {
                        case 0:
                            transform.eulerAngles = new Vector3(0, 0, 90);
                            danceDirection++;
                            break;
                        case 1:
                            transform.eulerAngles = new Vector3(0, 0, 45);
                            danceDirection++;
                            break;
                        case 2:
                            transform.eulerAngles = new Vector3(0, 0, 0);
                            danceDirection++;
                            break;
                        case 3:
                            transform.eulerAngles = new Vector3(0, 0, -45);
                            danceDirection++;
                            break;
                        case 4:
                            transform.eulerAngles = new Vector3(0, 0, -90);
                            danceDirection++;
                            break;
                        case 5:
                            transform.eulerAngles = new Vector3(0, 0, -135);
                            danceDirection++;
                            break;
                        case 6:
                            transform.eulerAngles = new Vector3(0, 0, 180);
                            danceDirection++;
                            break;
                        case 7:
                            transform.eulerAngles = new Vector3(0, 0, 135);
                            danceDirection = 0;
                            break;
                    }
                }

            }
            else
            {
                ///////////////////////////////////////////////////////////
                ///////////////  displaying timer  ////////////////////////
                ///////////////////////////////////////////////////////////
                if (gameOver == false)
                {
                    gameTimer += Time.deltaTime;

                    s = (int)(gameTimer % 60);
                    m = (int)(gameTimer / 60) % 60;

                    int sec = 59 - s;
                    int min = 14 - m;

                    if (m == 15)
                        timeUp = true;

                    string runTime = string.Format("{0:00}:{1:00}", m, s);//format the time nicely
                    string runTimeCountdown = string.Format("{0:00}:{1:00}", min, sec);//format the string to countdown

                    runningTime.text = ("Time until Animal Control arrives: " + runTimeCountdown);//set runTime to current run timer

                    //timer for the woods level
                    if (woodsDone == false)
                    {
                        woodsTime.text = ("The Woods: " + runTime);
                        woodsSec = s;
                        woodsMin = m;
                    }
                    //timer for the river level
                    if (riverDone == false)
                    {
                        levelTimer += Time.deltaTime;
                        riverSec = (int)(levelTimer % 60);
                        riverMin = (int)(levelTimer / 60) % 60;
                        riverTime.text = string.Format("The River: {0:00}:{1:00}", riverMin, riverSec);
                    }
                    //timer for the fields level
                    if (fieldsDone == false)
                    {
                        levelTimer += Time.deltaTime;
                        fieldsSec = (int)(levelTimer % 60);
                        fieldsMin = (int)(levelTimer / 60) % 60;
                        fieldsTime.text = string.Format("The Fields: {0:00}:{1:00}", fieldsMin, fieldsSec);
                    }
                    //timer for the highway level
                    if (highwayDone == false)
                    {
                        levelTimer += Time.deltaTime;
                        highwaySec = (int)(levelTimer % 60);
                        highwayMin = (int)(levelTimer / 60) % 60;
                        highwayTime.text = string.Format("The Highway: {0:00}:{1:00}", highwayMin, highwaySec);
                    }
                }

                //////////////////////////////////////////////////
                ///////  get user input to make leo move  ////////
                /////////////////////////////////////////////////
                float moveX = Input.GetAxis("Horizontal") * 15;
                float moveY = Input.GetAxis("Vertical") * 15;
                Vector3 movement = new Vector3(moveX, moveY, 0.0f);

                //add user input to Leo's velocity
                movement.x = moveX;
                movement.y = moveY;
                rb.velocity = movement * speed;

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
                if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.DownArrow))
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
            }
        }
        else
        {
            //15 minutes are up
            gameOver = true;
            woodsDone = true;
            riverDone = true;
            fieldsDone = true;
            highwayDone = true;

            runningTime.text = string.Format("Oh no! You didn't get Leo home in time!");
            SceneManager.LoadScene("_Game_Over");
        }

    }//end fixedupdate




    //variable to keep track of what tree area leo is currently in
    private int level = 1;
    private int branch = 1;//keeps track of what branch leo is picking up
    private int riverPart = 1;//keeps track of what part of the river to block

    //bool to make sure that the trigger doesnt fire more than once
    bool isTriggered = false;

    private void OnTriggerEnter(Collider other)
    {
        //////////////////////////////////////////////////////////////////
        ///////////////////////  INTERACTIONS  ///////////////////////////
        //////////////////////////////////////////////////////////////////
        if (isTriggered == false)
        {
            //if leo picked the right path--progress to next area
            if (other.gameObject.CompareTag("Finish"))
            {
                isTriggered = true;//set this to true so that the trigger isnt activated more than once
                level++;
                LevelHandler(level);
            }

            //if leo picked the wrong path--set back to area 1
            if (other.gameObject.CompareTag("Respawn"))
            {
                isTriggered = true;//set this to true so that the trigger isnt activated more than once
                level = 1;
                LevelHandler(level);
            }

            //if leo steps on the trigger to place a branch and dam the river
            if (other.gameObject.CompareTag("Dam"))
            {
                isTriggered = true;
                
                //check if leo has a stick in his mouth--if not do nothing
                if(mouthBranch.activeSelf == true)
                {
                    mouthBranch.SetActive(false);//if he does set it to false
                    DamRiver(riverPart++);//dam the river
                    
                }
                
                
            }

            //if leo steps on a branch to pick it up. The level is designed that 
            //the player must use one branch before they can find the next one.
            //Therefore the iteration of "branch" variable takes place in the
            //DamRiver() function--after the player has placed the branch.
            if (other.gameObject.CompareTag("Branch"))
            {
                //if leo steps on a branch pick it up
                switch (branch)
                {
                    case 1:
                        b1.SetActive(false);//make the branch that leo stepped on dissapear
                        mouthBranch.SetActive(true);//make leo appear to have picked up that branch
                        break;
                    case 2:
                        b2.SetActive(false);//make the branch that leo stepped on dissapear
                        mouthBranch.SetActive(true);//make leo appear to have picked up that branch
                        break;
                    case 3:
                        b3.SetActive(false);//make the branch that leo stepped on dissapear
                        mouthBranch.SetActive(true);//make leo appear to have picked up that branch
                        break;
                    case 4:
                        b4.SetActive(false);//make the branch that leo stepped on dissapear
                        mouthBranch.SetActive(true);//make leo appear to have picked up that branch
                        break;
                    case 5:
                        b5.SetActive(false);//make the branch that leo stepped on dissapear
                        mouthBranch.SetActive(true);//make leo appear to have picked up that branch
                        break;
                }
                branch++;//iterate so that leo can pick up the next branch
            }
        }
        
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        ///////////////////////////////////////////////////////////////
        ///////////  collisions with critters in the fields  //////////
        ///////////////////////////////////////////////////////////////
        GameObject obj_hit = collision.gameObject;

        if (obj_hit.tag == "Critter")
        {
            distractTime = 0.0f;//reset timer for each time leo is hit
            //now make leo dance for 5s
            distracted = true;
            bark.UnPause();//barking SFX
        }

        if (obj_hit.tag == "Car")
        {
            //kill leo and respawn him at Vector3(166.0f, 0.0f, -1.0f)
            rb.transform.position = new Vector3(166.0f, 0.0f, -1.0f);
        }
        
    }
    private void OnTriggerExit(Collider other)
    {
        isTriggered = false;
    }
    //need this to make sure leo doesnt collide more than once
    private void OnCollisionExit(Collision collision)
    {
        //isTriggered = false;
    }

    //handles where to "teleport" leo throughout the whole game
    void LevelHandler(int level)
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
                pp1.SetActive(true);//show paw prints for correct way found
                break;

            case 3:
                rb.transform.position = new Vector3(0.0f, 30.0f, -1.0f);
                rb.velocity = Vector3.zero;//make sure they dont carry their momentum in the next room
                pp2.SetActive(true);//show paw prints for correct way found
                break;

            case 4:
                rb.transform.position = new Vector3(0.0f, 45.0f, -1.0f);
                rb.velocity = Vector3.zero;//make sure they dont carry their momentum in the next room
                pp3.SetActive(true);//show paw prints for correct way found
                break;

            case 5:
                rb.transform.position = new Vector3(0.0f, 60.0f, -1.0f);
                rb.velocity = Vector3.zero;//make sure they dont carry their momentum in the next room
                pp4.SetActive(true);//show paw prints for correct way found
                break;

            case 6:
                rb.transform.position = new Vector3(0.0f, 75.0f, -1.0f);
                rb.velocity = Vector3.zero;//make sure they dont carry their momentum in the next room
                pp5.SetActive(true);//show paw prints for correct way found
                break;

            case 7:
                rb.transform.position = new Vector3(0.0f, 90.0f, -1.0f);
                rb.velocity = Vector3.zero;//make sure they dont carry their momentum in the next room
                pp6.SetActive(true);//show paw prints for correct way found
                break;

            case 8:
                //teleport to level 2 - the river

                woodsDone = true;//stops the timer for the woods level
                woodsTime.text = string.Format("The Woods: {0:00}:{1:00}", woodsMin, woodsSec);//set the score
                riverDone = false;//start running the timer for the river

                rb.transform.position = new Vector3(47.0f, 0.0f, -1.0f);

                
                rb.velocity = Vector3.zero;//make sure they dont carry their momentum in the next room
                break;

            case 9:
                //teleport to level 3 - the fields

                riverDone = true;//stops the timer for the river level
                riverTime.text = string.Format("The River: {0:00}:{1:00}", riverMin, riverSec);//set the score
                levelTimer = 0.0f;//reset the level timer to 0 to be used for the fieldsTime
                fieldsDone = false;//start running the timer for the fields

                rb.transform.position = new Vector3(97.0f, 0.0f, -1.0f);

                rb.velocity = Vector3.zero;//make sure they dont carry their momentum in the next room
                break;

            case 10:
                //teleport to level 4 - the highway

                fieldsDone = true;//stops the timer for the field level
                fieldsTime.text = string.Format("The Fields: {0:00}:{1:00}", fieldsMin, fieldsSec);//set the score
                levelTimer = 0.0f;//reset the level timer to 0 to be used for the highwayTime
                highwayDone = false;//start running the timer for the fields

                rb.transform.position = new Vector3(166.0f, 0.0f, -1.0f);

                rb.velocity = Vector3.zero;//make sure they dont carry their momentum in the next room
                break;

            case 11:
                //teleport leo to his house :-)
                gameOver = true;//stops game timer

                highwayDone = true;
                highwayTime.text = string.Format("The Highway: {0:00}:{1:00}", highwayMin, highwaySec);

                runningTime.text = string.Format("Congrats! You got Leo home in {0:00}:{1:00}!", m, s);

                rb.transform.position = new Vector3(216.0f, 0.0f, -1.0f);

                rb.velocity = Vector3.zero;
                break;

            case 12:
                //load the game over scene
                SceneManager.LoadScene("_Game_Over");
                break;
        }
    }

    void DamRiver(int riverPart)
    {
        //delete parts of the river as leo passes sticks
        switch (riverPart)
        {
            case 1:
                r1.SetActive(false);
                break;
            case 2:
                r2.SetActive(false);
                break;
            case 3:
                r3.SetActive(false);
                break;
            case 4:
                r4.SetActive(false);
                break;
            case 5:
                r5.SetActive(false);
                break;
            case 6:
                break;
        }

    }
}
