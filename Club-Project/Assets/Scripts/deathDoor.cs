using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deathDoor : MonoBehaviour
{

    public Collider2D b_collider;

    private PlayerMovement playerScript;

    public GameObject player;

    void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Player")
        {
            Debug.Log("Player touched deathdoor");

        }

    }

}
