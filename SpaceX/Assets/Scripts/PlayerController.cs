using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	//Variable de velocidad de desplazamiento
	public float speed = 8f;

	public float min_Y, max_Y;

	//Aparecer los proyectiles
	[SerializeField]
	public GameObject player_Bullet;

	[SerializeField]
	private Transform attack_point;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoverJugador();
        Disparar();
    }

    void MoverJugador()
    {
    	if(Input.GetAxisRaw("Vertical") > 0f)
    	{
    		Vector3 temp = transform.position;
    		temp.y += speed * Time.deltaTime;

    		if(temp.y > max_Y)
    		{
    			temp.y = max_Y;
    		}

    		transform.position = temp;
    	} else if (Input.GetAxisRaw("Vertical") < 0f)
    	{
    		Vector3 temp = transform.position;
    		temp.y -= speed * Time.deltaTime;

    		if(temp.y < min_Y)
    		{
    			temp.y = min_Y;
    		}

    		transform.position = temp;
    	}
    }

    void Disparar()
    {
    	if(Input.GetKeyDown(KeyCode.K))
    	{
    		Instantiate(player_Bullet, attack_point.position, Quaternion.identity);
    	}
    }
}
