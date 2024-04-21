using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowTail : MonoBehaviour
{
    public GrowSnake head;
    public bool chocar = false;
    void Start()
    {
        
        head = GameObject.FindWithTag("Snake").GetComponent<GrowSnake>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            head.GrowSnakeTail();
            chocar = true;
            if(chocar == true)
            {
                
                chocar =false;
            }
        }
    }
    IEnumerator EsperarDespuesdeColision()
    {

        yield return new WaitForSeconds(4);
    }

    
}
