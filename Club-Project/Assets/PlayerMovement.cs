using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

  //  public CharacterController2D controller;
    public float avgSpeed = 10f;
    public float horizontalMovement = 0f;

    //Because of this game's nature, we don't need to jump or crouch.
    bool jump = false;
    bool crouch = false;

    // Start is called before the first frame update
    void Start()
    {
        
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


    }

   
}
