using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallDeactive : MonoBehaviour
{

    private GameManager gameManager;

    private void Start()
    {
      
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Ground")
        {
            gameObject.SetActive(false);
        }

        if (collision.gameObject.name == "Trampoline") 
        {
           
        }
    }

}
