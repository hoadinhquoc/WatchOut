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
	[SerializeField] float Gravity = 8f;
	[SerializeField] float JumpHeight = 5f;
	[SerializeField] float Speed = 5f;
	[SerializeField] float OffsetJumpSpeed = 15f;
	[SerializeField] bool CanJump = true;
	Vector3 m_direction;
	State m_state = State.IDLE;
	// Use this for initialization
	void Awake () {
		SetupDirection();
	}
    public void SetupCharacter(CharacterType type, float positionX, float speed)
    {
        CharType = type;
		Speed = speed;
        Vector3 currentPos = transform.position;
        currentPos.x = positionX;
		currentPos.y = 0f;
        transform.position = currentPos;
        SetupDirection();
		CanJump = true;
        SetState(State.RUNNING);
    }
	void SetupDirection()
	{	
		if(CharType == CharacterType.LEFT_CHARACTER)
			m_direction = Vector3.right;
		else
			m_direction = Vector3.left;
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

        if (IsState(State.IDLE)) return;

		CheckInput();
		UpdateDirection();
		Vector3 pos = transform.position;
		pos += m_direction.normalized * dt * (IsState(State.RUNNING) ? Speed : Speed + OffsetJumpSpeed);

		transform.position = pos;
	}

	void CheckInput()
	{
		if(!CanJump) return;

		KeyCode key = CharType == CharacterType.LEFT_CHARACTER ? KeyCode.LeftArrow : KeyCode.RightArrow;

		if(Input.GetMouseButtonDown(0))
		{
			CanJump = false;
			Vector2 mousePosition = Input.mousePosition;
			CharacterType jumpChar = mousePosition.x > (Screen.width/2f) ? CharacterType.RIGHT_CHARACTER : CharacterType.LEFT_CHARACTER;
			if(CharType == jumpChar)
			{
				SetState(State.JUMPING_UP);
			}

		}
		
		if(Input.GetKeyDown(key))
		{
			CanJump = false;
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

	public void OnChildTriggerEnter(Collider col)
	{
		if(col.gameObject.CompareTag("MC"))
		{
			GameEvents.MC_DEATH.Raise();
			SetState(State.IDLE);
		}
	}
}
