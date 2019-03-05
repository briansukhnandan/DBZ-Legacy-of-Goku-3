using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScenes : MonoBehaviour
{   

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Player") )
        {

            Debug.Log("Attempted to switch to Scene 2");
            SceneManager.LoadScene("2");

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
