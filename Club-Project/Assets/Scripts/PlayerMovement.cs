using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{

    public float avgSpeed = 10f;
    public float horizontalMovement = 0f;

    //A reference to the animator we made, so it's private, we don't want a duplicate showing up in Unity.
    private Animator animationHandler;

    private int coinCounter;

    public Text countText;


    // Start is called before the first frame update
    void Start()
    {

        //Initializes the animationHandler to the animator attached to the object this script is attached to.
        animationHandler = GetComponent<Animator>();

        coinCounter = 0;

        countText.text = "Coins: " + coinCounter.ToString();

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetAxisRaw("Horizontal") > 0.1f || Input.GetAxisRaw("Horizontal") < -0.1f)
        {


            //Will be positive or negative based on input, no need to add an extra if statement.
            transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * avgSpeed * Time.deltaTime, 0f, 0f));


        }

        else if (Input.GetAxisRaw("Vertical") > 0.1f || Input.GetAxisRaw("Vertical") < -0.1f) {

            transform.Translate(new Vector3(0f, Input.GetAxisRaw("Vertical") * avgSpeed * Time.deltaTime, 0f) );


        }

        animationHandler.SetFloat("MoveX", Input.GetAxisRaw("Horizontal"));

        animationHandler.SetFloat("MoveY", Input.GetAxisRaw("Vertical"));

       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Coin"))
        {
            collision.gameObject.SetActive(false);
            coinCounter++;

            countText.text = "Coins: " + coinCounter.ToString();
        }


    }


}
