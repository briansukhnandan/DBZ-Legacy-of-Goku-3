﻿using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{

    public float avgSpeed = 10f;
    public float horizontalMovement = 0f;

    //A reference to the animator we made, so it's private, we don't want a duplicate showing up in Unity.
    private Animator animationHandler;
    private SpriteRenderer mySpriteRenderer;

    private static int coinCounter = 0;

    public Text countText;

    public static int dragonBallCounter = 0;

    public Text dragonBallText;

    private bool facingX;
    private bool facingY;
    private bool facingN;
    private bool facingW;

    public bool attackState;

  //  private bool enemyAtkPlayer;

    //Public so we can access it from another script
    public static int healthCounter;

    public Text healthText;

    private bool isPlayerDead;

    public static bool godMode;

    // Start is called before the first frame update
    void Start()
    {
        if (godMode) {

            healthCounter = 2147483647;

            dragonBallCounter = 7;

            healthText.text = "Health: " + healthCounter.ToString() + " (Dev Mode enabled)";

            dragonBallText.text = "Dragon Balls: " + dragonBallCounter.ToString();

        } else {

            healthCounter = 500;

        }

        //Initializes the animationHandler to the animator attached to the object this script is attached to.
        animationHandler = GetComponent<Animator>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
  //      coinCounter = 0;

  //      dragonBallCounter = 0;

        countText.text = "Coins: " + coinCounter.ToString();
        dragonBallText.text = "Dragon Balls: " + dragonBallCounter.ToString();
        healthText.text = "Health: " + healthCounter.ToString();

        isPlayerDead = false;


    }

    // Update is called once per frame
    void Update()
    {

        if (godMode) {

            healthCounter = 2147483647;

            dragonBallCounter = 7;

            healthText.text = "Health: " + healthCounter.ToString() + " (Dev Mode enabled)";

            dragonBallText.text = "Dragon Balls: " + dragonBallCounter.ToString();


        }

        if (healthCounter > 0) {

            isPlayerDead = false;

        }

        if (Input.GetButtonDown("Jump"))
        {

            attackState = true;
            avgSpeed /= 2f;
        }

        if (Input.GetButtonUp("Jump"))
        {

            attackState = false;
            avgSpeed = 5f;
        }

        if (Input.GetAxisRaw("Horizontal") > 0.1f || Input.GetAxisRaw("Horizontal") < -0.1f)
        {

            //Will be positive or negative based on input, no need to add an extra if statement.
            transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * avgSpeed * Time.deltaTime, 0f, 0f));

            if (Input.GetAxisRaw("Horizontal") < -0.1f)
            {

                facingX = true;
                facingW = true;

            }

            if (Input.GetAxisRaw("Horizontal") > 0.1f)
            {

                facingX = true;

                facingW = false;
            }


        }

        else if (Input.GetAxisRaw("Vertical") > 0.1f || Input.GetAxisRaw("Vertical") < -0.1f) {

            transform.Translate(new Vector3(0f, Input.GetAxisRaw("Vertical") * avgSpeed * Time.deltaTime, 0f) );

            if (Input.GetAxisRaw("Vertical") > 0.1f)
            {

                facingY = true;
                facingN = true;

            }

            if (Input.GetAxisRaw("Vertical") < 0.1f)
            {

                facingY = true;

                facingN = false;

            }


        }

        if (healthCounter <= 0)
        {
            Debug.Log("Player's health has reached 0.");
            isPlayerDead = true;

            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        }

        animationHandler.SetFloat("MoveX", Input.GetAxisRaw("Horizontal"));

        animationHandler.SetFloat("MoveY", Input.GetAxisRaw("Vertical"));

        animationHandler.SetBool("FacingX", facingX);
        animationHandler.SetBool("FacingY", facingY);
        animationHandler.SetBool("FacingN", facingN);
        animationHandler.SetBool("FacingW", facingW);

        animationHandler.SetBool("Attack", attackState);

        animationHandler.SetBool("PlayerDeath", isPlayerDead);
        animationHandler.SetInteger("Health", healthCounter);
    }

    public bool returnGodMode() {
        return godMode;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("health_regen")) {
            
            healthCounter = 500;
            healthText.text = "Health: " + healthCounter.ToString();

        }

        if (collision.CompareTag("end_door")) {

            Debug.Log("touched end door");

            if (dragonBallCounter == 7) SceneManager.LoadScene("4");

            else Debug.Log("Player does not have 7 DB");

        }

        if (collision.CompareTag("godModeOn")) {

            healthCounter = (int)(Math.Pow(2, 32)) - 1;

            healthText.text = "Health: " + healthCounter.ToString() + " (Dev Mode enabled)";

            godMode = true;

        }

        if (collision.CompareTag("godModeOff") && returnGodMode()) {

            godMode = false;


        }

        if (collision.CompareTag("deathDoor"))
        {

            if (dragonBallCounter < 3)
            {

                //healthCounter = 0;
                //healthText.text = "Health: " + healthCounter.ToString();

                //SceneManager.LoadScene(SceneManager.GetActiveScene().name);

                SceneManager.LoadScene("3");

            } else {

                SceneManager.LoadScene("3");

            }
            
            
            Debug.Log("Player touched death door.");
        }

        if (collision.CompareTag("Enemy"))
        {

            healthCounter -= 20;

            healthText.text = "Health: " + healthCounter.ToString();
        }
        
        if (collision.CompareTag("Coin"))
        {
            collision.gameObject.SetActive(false);
            coinCounter++;

            countText.text = "Coins: " + coinCounter.ToString();
        }

        if (collision.CompareTag("Dragonball"))
        {
            collision.gameObject.SetActive(false);
            dragonBallCounter++;

            dragonBallText.text = "Dragon Balls: " + dragonBallCounter.ToString();
        }

        if (collision.CompareTag("SceneChanging"))
        {

            Debug.Log("Attempted to switch to Scene 2");
            SceneManager.LoadScene("2");

        }


    }


}
