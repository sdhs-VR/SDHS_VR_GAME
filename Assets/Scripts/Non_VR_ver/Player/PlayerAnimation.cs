using UnityEngine;
using System.Collections;

public class PlayerAnimation : objectBase
{
    private Animator m_pPlayerAnimator = null;

    public enum PlayerState
    {
        IDLE = 0,
        WALK,
        RUN,
        LIGHTON,
        LIGHTOFF,
    }

    PlayerState m_CurrentState;

    protected override void OnAwake()
    {
        base.OnAwake();

        m_pPlayerAnimator = GetComponent<Animator>();

        m_CurrentState = PlayerState.IDLE;
    }

    public void PlayAnimation( PlayerState State )
    {
        m_CurrentState = State;
        m_pPlayerAnimator.SetInteger( "PlayerAni", ( int )State );
    }
    
}
