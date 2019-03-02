using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScenes : MonoBehaviour
{   

    void OnTriggerEvent2D(Collider2D other)
    {

        if (other.tag == "Player")
        {

            SceneManager.LoadScene("Scene 2");


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
        
        if (other.CompareTag("Player"))
        {

            SceneManager.LoadScene()

        }

    } */
}
