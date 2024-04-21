using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionSnake : MonoBehaviour
{
    private GrowSnake s_growSnake;
    void Start()
    {
        s_growSnake = GameObject.FindWithTag("Snake").GetComponent<GrowSnake>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Snake")
        {
            s_growSnake.GrowSnakeTail();
            
            StartCoroutine(EsperarDespuesdeColision());

        }
    }
    IEnumerator EsperarDespuesdeColision()
    {
        yield return new WaitForSeconds(10);
        
    }
}
