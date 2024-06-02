using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTail : MonoBehaviour
{
    public GameObject target;
    //private float speed = 5 ; 
    [SerializeField] private float distance;

    private void Start()
    {

    }
    void Update()
    {
        
        distance = Vector3.Distance (transform.position, target.transform.position);

        //So that it doesnt get INSIDE the target, space between target and tail
        if(distance >= 0.7f)
        {
            print("Hello");
            //Follow, MoveTowars
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, 2 * Time.deltaTime );
                                                                                                    //distance 
                                                                         //!! Si no contenta,  Añadir variable *speed
        }
        if(distance <= 0.6f)
        {
            print("WTF"); 
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, 0 * Time.deltaTime);
        }
    }

}
