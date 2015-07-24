﻿using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	void Start()
	{
		Time.timeScale = 1;
	}
	
	void Update () {
		if(Input.GetKeyDown (KeyCode.R))
		{
			Restart ();
		}
	}

	public static void Restart () 
	{
		Application.LoadLevel (Application.loadedLevel); 
	}

	public static void WinLevel () 
	{
		//SWITCH TO GAME WON STATE
		Debug.Log ("You Won!");

		//DO THIS ON SOME INPUT IN THE WIN GAME STATE
		if(Application.loadedLevel < Application.levelCount - 1)
		{
			Application.LoadLevel (Application.loadedLevel + 1);
		}else
		{
			Application.LoadLevel (0);
		}
	}
	
	public static void LoseLevel ()
	{
		//SWITCH TO GAME LOSE STATE
		Debug.Log ("You Lost :(\nPress 'R' to try again");
	}
}