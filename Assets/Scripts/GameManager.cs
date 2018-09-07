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
		GameEvents.MC_DEATH += OnMCDeath;
		GameEvents.END_ROUND += OnEndRound;
    }
	// Use this for initialization
	void GameStart () {
        StartNewRound();
	}
	void StartNewRound()
	{
        GameEvents.START_NEW_ROUND.Raise();
	}

	void OnEndRound()
	{
		StartNewRound();
	}
	void OnMCDeath()
	{
		CancelInvoke();
		Invoke("OnGameOver", 1f);
	}
	void OnGameOver()
	{
		GameEvents.GAME_OVER.Raise();
	}

}
