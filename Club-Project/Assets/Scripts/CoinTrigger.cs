using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinTrigger : MonoBehaviour
{

  //  private int coinCounter = 0;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        //If the player touches the coin.
        if (collision.CompareTag("Player"))
        {
            //Destroy coin object and increment coin counter by 1.
            Destroy(this.gameObject);

   //         coinCounter++;
        }


    }


    /*
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    } */
}
