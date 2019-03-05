using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class kingKaiDialogue : MonoBehaviour
{

    public Text npcDialogue;

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Player")
        {


            Debug.Log("Player Entered NPC BoxCollider.");
            npcDialogue.enabled = true;


        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        
        if (collision.tag == "Player")
        {

            Debug.Log("Player left King Kai NPC.");
            npcDialogue.enabled = false;



        }



    }


}
