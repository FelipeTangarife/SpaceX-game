using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerarEnemigos : MonoBehaviour
{
    [SerializeField]
    private GameObject naveEnemiga;
    [SerializeField]
    private float tiempoCreacion = 2f;
    [SerializeField]
    private float rangoCreacion = 2f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Generar", 0.0f, tiempoCreacion);
    }

    private void Generar() {
        Vector3 spawnPosition = new Vector3(0, 0, 0);
        spawnPosition = this.transform.position + Random.onUnitSphere * rangoCreacion;
        spawnPosition = new Vector3(spawnPosition.x, spawnPosition.y, 0);

        Instantiate(naveEnemiga, spawnPosition, Quaternion.identity);
            
    }
}
