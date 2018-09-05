using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
	public static GameManager Instance;
	void Awake()
	{
		Instance = this;
        RegisterEvents();
    }
    void RegisterEvents()
    {
        GameEvents.START_GAME += GameStart;
    }
	// Use this for initialization
	void GameStart () {
        StartNewRound();
	}
	void StartNewRound()
	{
        GameEvents.START_NEW_ROUND.Raise();
	}
	void OnMCDeath()
	{

	}
	void OnGameOver()
	{

	}
	// Update is called once per frame
	void Update () {
		
	}
}
