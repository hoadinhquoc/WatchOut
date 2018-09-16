using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
	public static GameManager Instance;
	int m_roundIndex = 0;
	void Awake()
	{
		Instance = this;
		Application.targetFrameRate = 60;
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
		m_roundIndex = 0;
        StartNewRound();
	}
	void StartNewRound()
	{
		GameEvents.SCORE_CHANGED(m_roundIndex);
        GameEvents.START_NEW_ROUND.Raise(m_roundIndex++);
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
