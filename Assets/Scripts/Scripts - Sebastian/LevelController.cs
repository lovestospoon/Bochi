﻿using UnityEngine;
using System.Collections;

public class LevelController : MonoBehaviour {

    public LevelState state;

    //fader vars
    public float fadeSpeed = 20f;
    private Fader[] _faders;

    //target vars
    private Target[] _targets;

    //private Player _player;

	// Use this for initialization
	void Start () {
        this._faders = GameObject.FindObjectsOfType<Fader>();
        this._targets = GameObject.FindObjectsOfType<Target>();
        this.SwitchToState(LevelState.LOADIN);
	}
	
	// Update is called once per frame
	void Update () {
        HandleStates();
	}

    void HandleStates()
    {
        switch (this.state)
        {
            case LevelState.LOADIN:
                this.OnLoadIn();
                break;
            case LevelState.IDLE:
                this.OnIdle();
                break;
            case LevelState.WAITING:
                this.OnWaiting();
                break;
            case LevelState.PAUSED:
                this.OnPaused();
                break;
            case LevelState.LOADOUT:
                this.OnLoadOut();
                break;
        }
    }


    void OnLoadIn() 
    {
        if (this.CheckForCompletedFade())
        {
            this.SwitchToState(LevelState.IDLE);
        }
    }

    void OnIdle() { }
    void OnWaiting() 
    {
        if (Input.GetMouseButtonDown(0))
        {
            this.ResetLevel();
        }    
    }
    void OnPaused() { }

    void OnLoadOut() 
    { 
        if (this.CheckForCompletedFade()) 
        {
            this.LoadNextLevel();
        }
    }

    public void SwitchToState(LevelState s)
    {
        this.state = s;
        switch (this.state)
        {
            case LevelState.LOADIN:
                this.SwitchToLoadIn();
                break;
            case LevelState.IDLE:
                this.SwitchToIdle();
                break;
            case LevelState.WAITING:
                this.SwitchToWaiting();
                break;
            case LevelState.PAUSED:
                this.SwitchToPaused();
                break;
            case LevelState.LOADOUT:
                this.SwitchToLoadOut();
                break;
        }
    }

    void SwitchToLoadIn() 
    {
        for (int i = 0; i < _faders.Length; i++)
        {
            this._faders[i].fadeSpeed = this.fadeSpeed;
            this._faders[i].SwitchToState(FadeState.IN);
        }
    }

    void SwitchToIdle() 
    {
        Debug.Log("LevelController is switching to idle.");
    }
    
    void SwitchToWaiting() { }
    void SwitchToPaused() { }
    void SwitchToLoadOut() { }


    bool CheckForCompletedFade()
    {
        for (int i = 0; i < _faders.Length; i++)
        {
            if (!_faders[i].state.Equals(FadeState.IDLE))
            {
                return false;
            }
        }
        return true;
    }


    public void CheckForWinCondition()
    {
        if (this.state.Equals(LevelState.WAITING))
        {
            
        }
    }


    void LoadNextLevel()
    {
        Application.LoadLevel((Application.loadedLevel + 1) % Application.levelCount);
    }

    void LoadStartMenu()
    {
        Application.LoadLevel(0);
    }

    void ResetLevel()
    {
        this.SwitchToLoadIn();
    }
}

public enum LevelState
{
    LOADIN, IDLE, WAITING, PAUSED, LOADOUT
}
