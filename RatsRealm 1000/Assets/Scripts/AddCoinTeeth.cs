using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AddCoinTeeth : MonoBehaviour
{
    /*Script del Diente para sumar cuantos dientes ha cogido el player y destruirse*/ 
    private CoinsTeeth s_CoinsTeeth;


    private void Start()
    {
        s_CoinsTeeth = GameObject.FindWithTag("GameManager").GetComponent<CoinsTeeth>();

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            print("Collision");
           s_CoinsTeeth.teethPlayer++;
            Destroy(gameObject);
        }
    }
}
