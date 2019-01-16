using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateManager : BaseStateManager
{
    public PlayerStateManager(Actor actor) : base(actor)
    {
        m_lstState.Add(new IdleState(actor));
        m_lstState.Add(new JumpPrepareState(actor));
        m_lstState.Add(new JumpUpState(actor));
        m_lstState.Add(new JumpFallState(actor));
        m_lstState.Add(new JumpDownState(actor));
        m_lstState.Add(new RunState(actor));
        m_lstState.Add(new WalkState(actor));
        m_lstState.Add(new Skill1State(actor));
        m_lstState.Add(new Skill2State(actor));
        m_lstState.Add(new Skill3State(actor));
        m_lstState.Add(new RunAttackState(actor));
        m_lstState.Add(new Attack1State(actor));
        m_lstState.Add(new Attack2State(actor));
        m_lstState.Add(new Attack3State(actor));
        m_lstState.Add(new Attack4State(actor));
        m_lstState.Add(new BeHitState(actor));
        m_lstState.Add(new JumpAttackState(actor));
    }
}
