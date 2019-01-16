using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseMovementState : BaseState
{
    public BaseMovementState(Actor actor, EActionState eState) : base(actor, eState)
    {
        
    }

    public override void EnterState(EActionState eState)
    {
        base.EnterState(eState);

        //这里先进行预设，后面最好根据配置表在具体的状态中来设置这些状态。
        m_owner.CanMove = true;
        m_owner.CanJump = true;
        m_owner.CanAttack = true;
        m_owner.CanSkill = true;
    }

    public override void OnUpdate()
    {
        base.OnUpdate();
        if(m_owner is Hero)
        {
            if (Input.GetKey(KeyCode.X) && m_owner.CanAttack && m_owner.IsRun == false)
            {
                m_stateManager.EnterState(EActionState.Attack1);
            }
            if (Input.GetKeyDown(KeyCode.C) && m_owner.CanJump == true)
            {
                m_stateManager.EnterState(EActionState.Jump_Prepare);
            }
            if (Input.GetKeyDown(KeyCode.Z) && m_owner.CanSkill)
            {
                m_stateManager.EnterState(EActionState.Skill1);
            }
            if (Input.GetKeyDown(KeyCode.S) && m_owner.CanSkill)
            {
                m_stateManager.EnterState(EActionState.Skill2);
            }
            if (Input.GetKeyDown(KeyCode.D) && m_owner.CanSkill)
            {
                m_stateManager.EnterState(EActionState.Skill3);
            }
        }
    }

    public override void OnFixedUpdate()
    {
        base.OnFixedUpdate();
        if (m_inputAbility != null)
            m_inputAbility.InputLogic();
    }

    public override void BreakState(EActionState eState)
    {
        base.BreakState(eState);
    }

    public override void Reset()
    {
        base.Reset();
    }

    public override void Release()
    {
        base.Release();
    }
}
