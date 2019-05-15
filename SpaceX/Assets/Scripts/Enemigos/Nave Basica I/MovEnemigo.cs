using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovEnemigo : MonoBehaviour {

    private GameObject gameController;

    // Use this for initialization
    public Transform comienzo, fin;
    public Transform disparadorDerecho;
    public Transform disparadorIzquierdo;

    public GameObject disparadorPrefab;
    [SerializeField]
    private GameObject explosion;

    [Tooltip("Puntos de vida")]
    public int maxHp = 100;

    private int hp;
    private int scoreValue = 250;
    public float speed = 10f;

    int score = 200;
   

    void Start() {
        Raycasting();
        hp = maxHp;
    }

    // Update is called once per frame
    void Update(){
        gameObject.transform.Translate(new Vector3(-speed * Time.deltaTime, 0));
    }

    void Raycasting() {
        //Debug.DrawLine(comienzo.position, fin.position, Color.blue,2f);
        float timeDisp = 0f;

        if (Physics2D.Linecast(comienzo.position, fin.position, 1 << LayerMask.NameToLayer("Player"))) {
            disparar();
            timeDisp = 1f;
        }
        Invoke("Raycasting", timeDisp);
    }


    void disparar(){     
         Instantiate(disparadorPrefab, disparadorDerecho.position, disparadorPrefab.transform.rotation);
         Instantiate(disparadorPrefab, disparadorIzquierdo.position, disparadorPrefab.transform.rotation);
    }

    void MostrarExplosion() {
        GameObject cloneExplosion = Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(cloneExplosion, 1.0f);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("BalaPlayer"))
        {
            hp -= 25;
            if (hp <= 0) {

                ScoreManager.score += score;
                MostrarExplosion();
                Destroy(gameObject);
            }
        }
    }


  


}
