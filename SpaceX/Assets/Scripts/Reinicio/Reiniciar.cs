using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Reiniciar : MonoBehaviour
{ 

   public Canvas canvas;
    
    void Start()
    {
    canvas = GetComponent<Canvas>();
    canvas.enabled = false;

    }

// Update is called once per frame
    void Update()
    {
        
    }

    public void Retry()
    {
     
        SceneManager.LoadScene("Nivel1");
    }

    public void Back() {

        SceneManager.LoadScene("MenuPrincipal");
    }

}
