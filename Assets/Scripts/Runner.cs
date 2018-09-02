using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CharacterType
{
	LEFT_CHARACTER,
	RIGHT_CHARACTER
}
public class Runner : MonoBehaviour {
	public enum State
	{
		IDLE,
		RUNNING,
		JUMPING_UP,
		JUMPING_DOWN
	}
	[SerializeField] CharacterType CharType;
	[SerializeField] Vector3 DirectionVector;
	[SerializeField] float Gravity = 8f;
	[SerializeField] float JumpHeight = 5f;
	[SerializeField] float Speed = 5f;

	Vector3 m_direction;
	State m_state = State.IDLE;
	// Use this for initialization
	void Awake () {
		m_direction = DirectionVector;
	}
	void SetState(State state)
	{
		if(m_state == state) return;

		if(state == State.JUMPING_UP)
			m_direction.y = 1f;
		else if(state == State.JUMPING_DOWN)
			m_direction.y = -1f;
		else
			m_direction.y = 0f;

		m_state = state;
	}

	bool IsState(State state)
	{
		return m_state == state;
	}
	// Update is called once per frame
	void Update () {
		float dt = Time.deltaTime;
		CheckInput();
		UpdateDirection();
		Vector3 pos = transform.position;
		pos += m_direction.normalized * dt * Speed;

		transform.position = pos;
	}

	void CheckInput()
	{
		KeyCode key = CharType == CharacterType.LEFT_CHARACTER ? KeyCode.LeftArrow : KeyCode.RightArrow;
		if(Input.GetKeyDown(key))
		{
			SetState(State.JUMPING_UP);
		}
	}
	void UpdateDirection()
	{
		Vector3 currentPos = transform.position;
		if(IsState(State.JUMPING_UP))
		{
			if(currentPos.y > JumpHeight)
				SetState(State.JUMPING_DOWN);
		}
		else if(IsState(State.JUMPING_DOWN))
		{
			if(currentPos.y <= 0f)
			{
				SetState(State.RUNNING);
				currentPos.y = 0f;
				transform.position = currentPos;
			}
		}
	}
}
