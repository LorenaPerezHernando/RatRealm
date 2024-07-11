using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;
using TMPro;
using UnityEngine.UI;

public class muebleCollision : MonoBehaviour
{
    TextMeshProUGUI textoInformacion;
    public GameObject playerAnim;
    public GameObject posMuebles;
    public bool collision;
    public bool isFollowing;
    public bool fuera; 

    public BoxCollider boxCollider;

  
    
  
    void Start()
    {
        textoInformacion = GameObject.FindWithTag("textoInfo").GetComponent<TextMeshProUGUI>();
        playerAnim = GameObject.FindWithTag("Player");
        
        isFollowing = false; collision = false;

        boxCollider = gameObject.GetComponent<BoxCollider>();
        //posMuebles = GameObject.FindWithTag("PosMueble");
        textoInformacion.text ="Acercate a un objeto y pulsa enter para llevarlo a casa";       
    }

    private void Update() {
        
        MoverObjeto();
        
    }
    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag == "Player")
        {
            collision = true;
            playerAnim.GetComponent<Animator>().SetBool("GetObject", true);
            print("Objeto Conseguido");
            textoInformacion.text ="Pulsa Enter para coger el objeto";      
             
        }
    }
    public void MoverObjeto(){
        
        if(Input.GetKeyDown(KeyCode.Return) && collision == true)
        {   
            textoInformacion.text ="Pulsa Enter para coger el objeto";        
            isFollowing = !isFollowing;   
               
        }

        if(isFollowing == true)
        {
            print("Coger");
             playerAnim.GetComponent<Animator>().SetBool("GetObject", false);    
            gameObject.transform.position = posMuebles.GetComponent<Transform>().position;
            //gameObject.GetComponent<BoxCollider>().enabled = false;
             textoInformacion.text ="Pulsa Enter para soltar el objeto"; 
        }
        //!!Soltar Objeto
        if(isFollowing == false)
        {
            
            print("Soltar");
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z); 
            
        }
    }


    private void OnTriggerEnter(Collider other) 
    { 
        print("En casa"); 
        fuera = true; 
        if(fuera == true)
        {
            Destroy(this);
            print("Home");

        }
        
    }
}

