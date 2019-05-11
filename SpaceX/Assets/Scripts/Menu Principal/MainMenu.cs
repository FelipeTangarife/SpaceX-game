using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //Función para botón de "Play"
	public void PlayGame()
	{
		SceneManager.LoadScene(1);
	}

	//Función para botón de "Exit"
	public void QuitGame()
	{
		Debug.Log("SALIR!");
		Application.Quit();
	}
}
