using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowSnake : MonoBehaviour
{
    public GameObject tailPrefab;
    public int Gap = 5;
    public int bodySpeed = 5;

    private List<GameObject> tailParts = new List<GameObject>();
    private List<Vector3> PositionHistory = new List<Vector3>(); //Save the positions on the tail
    public int NumberTails; 

    void Start()
    {
        //GrowsSnake(); //GrowsSnake();GrowsSnake();GrowsSnake();GrowsSnake();
        GrowSnakeTail();
    }

   
    void Update()
    {
        //Store position history
        PositionHistory.Insert(0, transform.position);

        //Move body parts
        int index = 0;
        foreach(var part in tailParts)
        {   
            //Order the parts + Adjust the spacing to the body parts
            Vector3 point = PositionHistory[Mathf.Min(index * Gap, PositionHistory.Count -1 )];
            //Adjust direction 
            Vector3 moveDirection = point - part.transform.position; //Substract 
            part.transform.position += moveDirection * bodySpeed * Time.deltaTime;
            part.transform.LookAt(point);
            index++;
        }
    }

    /*private void GrowsSnake()
    {

        if( tailParts.Count < NumberTails ) 
        {
        GameObject body = Instantiate(tailPrefab) ;
        tailParts.Add(body); //From list

            return;
        }
        

    }
    */

    public void GrowSnakeTail()
    {        
        for(int i = 0; i < NumberTails; i++)
        {
            GameObject body = Instantiate(tailPrefab);
            tailParts.Add(body); //From list
            
            //i++;
            i = i + 10;
            Debug.Log("Esperar");
            StartCoroutine(EsperarDespuesdeColision());

        }  
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            //NumberTails++;
            StartCoroutine(EsperarDespuesdeColision()); 
            
            
        }
    }
    IEnumerator EsperarDespuesdeColision()
    {
        GrowSnakeTail();
        yield return new WaitForSeconds(10);
    }


}
