using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NamekianDialogue : MonoBehaviour
{
    
    public Text npcDialogue; // Drag from UnityEditor.
    
    void OnTriggerEnter2D(Collider2D other) {

        if (other.tag == "Player"){

            Debug.Log("Player Entered NPC BoxCollider.");
            npcDialogue.enabled = true;

        }

    }

    void OnTriggerExit2D(Collider2D other) {

        if (other.tag == "Player") {

            Debug.Log("Player left Namekian NPC.");
            npcDialogue.enabled = false;

        }
        
    }

}
