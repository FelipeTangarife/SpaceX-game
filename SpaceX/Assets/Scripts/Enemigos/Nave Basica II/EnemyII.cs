using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyII : MonoBehaviour {
    // Start is called before the first frame update

    public GameObject player;

    public Transform comienzo, fin;

    public Transform disparador;

    public GameObject disparadorPrefab;
    [SerializeField]
    private GameObject explosion;

    public float ang = 0;

    public float velocidad = 5f;

    int score = 250;




    [Tooltip("Puntos de vida")]
    public int maxHp = 50;

    [Tooltip("Vida actual")]
    public int hp;

    void Start() {

        player = GameObject.FindGameObjectWithTag("Player");

        hp = maxHp;





        Raycasting();

    }

    // Update is called once per frame
    void Update() {



        if (transform.position.x <= 15f && player != null) {


            gameObject.transform.Translate(new Vector2(0 * Time.deltaTime, 0));

            Vector3 direccion = player.transform.position - transform.position;

            ang = Mathf.Atan2(direccion.y, direccion.x) * Mathf.Rad2Deg - 180f;


            transform.rotation = Quaternion.AngleAxis(ang, Vector3.forward);

        }

        else {



            gameObject.transform.Translate(new Vector2(-5f * Time.deltaTime, 0));
            transform.rotation = Quaternion.AngleAxis(0, Vector3.forward);



        }

    }

    void Raycasting() {
        //Debug.DrawLine(comienzo.position, fin.position, Color.blue, 2f);

        float timeDisp = 0f;


        if (Physics2D.Linecast(comienzo.position, fin.position, 1 << LayerMask.NameToLayer("Player")) && transform.position.x <= 15f) {

            disparar();
            timeDisp = 0.6f;
        }



        Invoke("Raycasting", timeDisp);


    }


    void disparar() {
        AudioManager.instance.Play("disparoEnemigo3");
        Instantiate(disparadorPrefab, disparador.position, disparador.transform.rotation);
    }

    void MostrarExplosion() {
        GameObject cloneExplosion = Instantiate(explosion, transform.position, Quaternion.identity);
        AudioManager.instance.Play("destruirNave");
        Destroy(cloneExplosion, 1.0f);
    } 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("BalaPlayer"))
        {


            hp -= 25;

            

            if (hp <= 0)
            {

                ScoreManager.score += score;
                MostrarExplosion();
                Destroy(gameObject);

                
               

            }
        }
    }


 
}
