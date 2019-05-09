using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroll : MonoBehaviour
{

	//Velocidad del desplazamiento del fondo
	public float velocidad_fondo = 0.1f;

	private MeshRenderer mesh_Renderer;

	private float x_Scroll;

    void Start()
    {
        mesh_Renderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Scroll();
    }

//Función Scroll para que realice el desplazamiento
    void Scroll()
    {
    	x_Scroll = Time.time * velocidad_fondo; //Desplazamiento en X

    	Vector2 offset = new Vector2(x_Scroll, 0f);

    	mesh_Renderer.sharedMaterial.SetTextureOffset("_MainTex", offset);
    }
}
