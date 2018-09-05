using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MCController : MonoBehaviour {
	[SerializeField] Runner BigRunner;
	[SerializeField] Runner SmallRunner;

    [SerializeField] float LeftPositionX = -10f;
    [SerializeField] float RightPositionX = 10f;
    // Use this for initialization
    void Awake()
	{
        GameEvents.START_NEW_ROUND += OnStartNewRound;
	}
	void OnStartNewRound () {
		
        if(Time.frameCount % 2 == 0)
        {
            BigRunner.SetupCharacter(CharacterType.RIGHT_CHARACTER, RightPositionX);
            SmallRunner.SetupCharacter(CharacterType.LEFT_CHARACTER, LeftPositionX);
        }
        else
        {
            SmallRunner.SetupCharacter(CharacterType.RIGHT_CHARACTER, RightPositionX);
            BigRunner.SetupCharacter(CharacterType.LEFT_CHARACTER, LeftPositionX);
        }

	}
	
}
