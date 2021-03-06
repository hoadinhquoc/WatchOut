﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameEvents {
	public static Action START_GAME;
    public static Action<int> START_NEW_ROUND;
	public static Action END_ROUND;
	public static Action GAME_OVER;
	public static Action UPDATE_GAME_SETTING;
	public static Action STAGE_CHANGED;

	public static Action<int> INSCREASE_SCORE;
	public static Action<int> SCORE_CHANGED;
	public static Action MC_BORN;
	public static Action MC_DEATH;
}

public static class ActionExt
{
	public static void Raise(this Action action)
	{
		if (action != null)
			action.Invoke();
	}
	public static void Raise<T1>(this Action<T1> action, T1 value1)
	{
		if (action != null)
			action.Invoke(value1);
	}

	public static void Raise<T1, T2>(this Action<T1, T2> action, T1 value1, T2 value2)
	{
		if (action != null)
			action.Invoke(value1, value2);
	}

	public static void Raise<T1, T2, T3>(this Action<T1, T2, T3> action, T1 value1, T2 value2, T3 value3)
	{
		if (action != null)
			action.Invoke(value1, value2, value3);
	}
}
