using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generador_NavII : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject naveII;
    private GameObject generador;




    void Start()
    {



    }

    // Update is called once per frame
    void Update()
    {



    if(generador== null){


            generador = Instantiate(naveII) as GameObject;

            generador.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
        }
      

        


    }





        
   


}
