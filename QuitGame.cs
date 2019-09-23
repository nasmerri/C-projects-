using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitGame : MonoBehaviour
{
	void Start() 
	{

	}
	public void Update() 
	{
		if (Input.GetKeyDown(KeyCode.Escape)) //if statement that will collect user input if they press the esc key
		{
			Application.Quit();// this will close down the application 
			print("Has Quit Game");// this will print the following text in the console to demostate that the application has closed
		}
	}
}