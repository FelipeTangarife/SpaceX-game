using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
	//Variable de velocidad de desplazamiento
	public float speed = 8f;
    public float min_Y, min_X, max_Y, max_X;
    public int health = 3;
    private int numberOfHearts = 3;

	//Aparecer los proyectiles
	[SerializeField]
	private GameObject player_Bullet;
    [SerializeField]
    private GameObject explosion;
    [SerializeField]
    private Image[] hearts;
    [SerializeField]
    private Sprite fullHeart;
    [SerializeField]
    private Sprite emptyHeart;
	[SerializeField]
	private Transform[] attack_points;

    private Renderer rend;

    public Canvas canvas;


     void Awake()
    {
        
    
    }

    // Start is called before the first frame update


    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = true;
    }

    // Update is called once per frame
    void Update() {
        MoverJugador();
        ActualizarVida();
        Disparar();
    }
    
    void ActualizarVida() {
        if (this.health > this.numberOfHearts) {
            this.health = this.numberOfHearts;
        }

        for (int i = 0; i < this.hearts.Length; i++) {
            this.hearts[i].sprite = (i < this.health) ? fullHeart : emptyHeart;
            this.hearts[i].enabled = (i < this.numberOfHearts) ? true : false;
        }
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
    	if(Input.GetKeyDown(KeyCode.Space) && Time.timeScale !=0)
    	{   
            foreach(Transform point in attack_points) {
                Instantiate(player_Bullet, point.position, Quaternion.identity);
            }
    		
    	}
    }

    void MostrarExplosion() {
        GameObject cloneExplosion = Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(cloneExplosion, 1.0f);
    }

    void DestruirNave() {
        Destroy(gameObject);
      
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Enemigo") && rend.enabled==true) {
            health--;
            ActualizarVida();
            MostrarExplosion();
            if (health > 0) {
                StartCoroutine(Dead());
               
            }
            else {
                DestruirNave();
                canvas.GetComponent<Animator>().SetTrigger("muerto");
                canvas.GetComponent<Canvas>();
                canvas.GetComponent<Reiniciar>().canvas.enabled = !canvas.enabled;
             
            }
        }

        IEnumerator Dead() {
            transform.position = GameObject.FindWithTag("Respawn").transform.position;
            rend.enabled = false;
            yield return new WaitForSeconds(1);
            rend.enabled = true;
        }
    }
}
