using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deathDoor : MonoBehaviour
{

    public Collider2D b_collider;

    private PlayerMovement playerScript;

    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {

        b_collider = GetComponent<Collider2D>();

        playerScript = player.GetComponent<PlayerMovement>();

    }

    // Update is called once per frame
    void Update()
    {
     
        if (playerScript.dragonBallCounter == 3)
        {

            Debug.Log("Collider.enabled =  "+ b_collider.enabled);
            b_collider.enabled = !b_collider.enabled;

            Destroy(this.gameObject);


        }


    } 
}
