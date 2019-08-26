using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class godModeOn : MonoBehaviour
{

    public GameObject player;

    void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Player")
        {
            Debug.Log("Player touched 'God Mode On' button");


        }

    }


    // Start is called before the first frame update
    /* 
    void Start()
    {

        // Get box collider component
        b_collider = GetComponent<Collider2D>();

        playerScript = player.GetComponent<PlayerMovement>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    */
}
