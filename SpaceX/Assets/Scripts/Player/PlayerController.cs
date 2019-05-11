using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	//Variable de velocidad de desplazamiento
	public float speed = 8f;

	public float min_Y, min_X, max_Y, max_X;

	//Aparecer los proyectiles
	[SerializeField]
	private GameObject player_Bullet;
    [SerializeField]
    private GameObject explosion;

	[SerializeField]
	private Transform[] attack_points;

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
        Vector3 temp = this.transform.position;
        float movY = Input.GetAxisRaw("Vertical");
        float movX = Input.GetAxisRaw("Horizontal");
        
        if (movY > 0f){
    		temp.y += speed * Time.deltaTime;
    		if(temp.y > max_Y) {
                temp.y = max_Y;
            }
    	} else if (movY < 0f) {
    		temp.y -= speed * Time.deltaTime;
    		if(temp.y < min_Y) {
                temp.y = min_Y;
            }
    	}

        if (movX > 0f) {
            temp.x += speed * Time.deltaTime;
            if (temp.x > max_X) {
                temp.x = max_X;
            }
        }
        else if (movX < 0f) {
            temp.x -= speed * Time.deltaTime;
            if (temp.x < min_X) {
                temp.x = min_X;
            }
        }

        this.transform.position = temp;
    }

    void Disparar()
    {
    	if(Input.GetKeyDown(KeyCode.Space))
    	{   
            foreach(Transform point in attack_points) {
                Instantiate(player_Bullet, point.position, Quaternion.identity);
            }
    		
    	}
    }

    void MostrarExplosion() {
        Instantiate(explosion, transform.position, Quaternion.identity);
    }
}
