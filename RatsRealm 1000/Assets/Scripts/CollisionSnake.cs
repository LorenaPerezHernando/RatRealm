using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionSnake : MonoBehaviour
{
    /* Script Player, grows snake in each collision with head & waits so collision doesnt repeat each second*/
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

        }
        
    }
    /* No vale, pq cada tail empieza otra vez, y crea como loco
      IEnumerator EsperarDespuesdeColision()
    {
        yield return new WaitForSeconds(10);
        
    }
    */
}
