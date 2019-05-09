using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProyectilJugador : MonoBehaviour
{
	//Velocidad del proyectil
	public float speed = 5f;
	public float deactivate_Timer = 3f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Mover();
    }

    void Mover()
    {
    	Vector3 temp = transform.position;
    	temp.x += speed * Time.deltaTime;
    	transform.position = temp;
    }
}
