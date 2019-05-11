using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProyectilJugador : MonoBehaviour
{
	//Velocidad del proyectil
	public float speed = 10f;

    // Update is called once per frame
    void FixedUpdate() {
        Vector2 position = transform.position;
        position = new Vector2(position.x + speed * Time.deltaTime, position.y);
        transform.position = position;

    }

    void OnBecameInvisible() {
        Destroy(gameObject);
    }
}
