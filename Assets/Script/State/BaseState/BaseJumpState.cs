using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseJumpState : BaseMovementState
{
    protected float m_fV0;
    protected float m_fGravity;
    protected float m_fOffset;

    protected Transform m_animationTrans;


    public BaseJumpState(Actor actor, EActionState eState) : base(actor, eState)
    {

    }

    public override void EnterState(EActionState eState)
    {
        base.EnterState(eState);

        m_owner.CanMove = true;
        m_owner.CanJump = false;
        m_owner.CanAttack = false;
        m_owner.CanSkill = false;
        m_owner.IsJump = true;

        if (m_animationTrans == null)
            m_animationTrans = m_owner.GetAbility<AnimationAbility>().m_animationTrans;
    }

    public override void BreakState(EActionState eState)
    {
        base.BreakState(eState);
    }

    public override void OnUpdate()
    {
        base.OnUpdate();
    }

    public override void OnFixedUpdate()
    {
        base.OnFixedUpdate();

        m_fV0 -= m_fGravity;
        m_fOffset += m_fV0;

        if (m_fOffset > 0)
            m_animationTrans.localPosition = new Vector2(m_animationTrans.localPosition.x, m_fOffset);
        else
            m_animationTrans.localPosition = new Vector2(m_animationTrans.localPosition.x, 0);
    }
}
