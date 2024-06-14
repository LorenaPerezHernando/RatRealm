using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CoinsTeeth : MonoBehaviour
{
    /*Manager creates random Teeth(coins) & add coins to buy muebles */
    //Attributes
    public int teethPlayer; 
    public TextMeshProUGUI t_teethPlayer;

#region Creates Random Teeth in Scene
    /*Creates Random Teeth (coins) */
    public float range = 10f; //Radius of sphere
    public Transform centrePoint; //Center of area that agent move in
    public GameObject prefabTeeth;

    [SerializeField] float cuantosDienteshay;
    public float dientesMaximos;
#endregion
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
         if (cuantosDienteshay <= dientesMaximos)
         {
            StartCoroutine(RandomPoint());
            cuantosDienteshay++;
         }

         t_teethPlayer.text = "Teeth : " + teethPlayer;
    }

    IEnumerator RandomPoint()
    {
        if(cuantosDienteshay <= dientesMaximos)
        {
            print("Crear Diente");

            //Coordenadas en las que se va a crear el randomPoint(Que va a crear los dientes) 
            float minX = centrePoint.position.x; float maxX = centrePoint.position.x + range;
            float minZ = centrePoint.position.z; float maxZ = centrePoint.position.z + range;
            float randomX = Random.Range(minX, maxX);
            float randomZ = Random.Range(minZ, maxZ);

            Vector3 randomPoint = new Vector3(randomX,0, randomZ);
            Quaternion rotation = Quaternion.identity;

            Instantiate(prefabTeeth, randomPoint, rotation);
            yield return new WaitForSeconds(100);
        }

        
    }
}