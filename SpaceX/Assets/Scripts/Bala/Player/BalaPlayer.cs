using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    public float velocidad = 20;

    // Update is called once per frame
    void FixedUpdate() {
        Vector2 position = transform.position;
        position = new Vector2(position.x + velocidad * Time.deltaTime, position.y);
        transform.position = position;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.tag);
        if(collision.gameObject.CompareTag("Enemigo")) {
            Destroy(gameObject);
        }

    }

    void OnBecameInvisible() {
        Destroy(gameObject);
    }
}
