using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpAttackState : BaseBattleState
{
    protected float m_fV0;
    protected float m_fGravity;
    protected float m_fOffset;
    protected Transform m_animationTrans;

    public JumpAttackState(Actor actor) : base(actor, EActionState.JumpAttack)
    {
    }

    public override void EnterState(EActionState eState, params object[] paramList)
    {
        base.EnterState(eState);
        m_owner.CanMove = true;
        m_owner.CanJump = false;
        m_owner.CanAttack = false;
        m_owner.CanSkill = false;
        m_owner.IsJump = true;
        m_owner.CanJumpAttack = false;

        m_tk2DSpriteAnimator.Play("JumpAttack");

        if (paramList.Length > 0)
        {
            m_fV0 = (float)paramList.GetValue(0);
            m_fOffset = (float)paramList.GetValue(1);
        }
        m_fGravity = m_owner.GetAttr(EActorAttr.JumpGravity).Value;

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
        if (m_fOffset <= 0)
        {
            m_fOffset = 0;
            m_stateManager.EnterState(EActionState.Jump_Down);
        }
    }

    public override void OnFixedUpdate()
    {
        base.OnFixedUpdate();

        if (m_inputAbility != null)
            m_inputAbility.InputLogic();

        m_fV0 -= m_fGravity;
        m_fOffset += m_fV0;

        if (m_fOffset > 0)
            m_animationTrans.localPosition = new Vector2(m_animationTrans.localPosition.x, m_fOffset);
        else
            m_animationTrans.localPosition = new Vector2(m_animationTrans.localPosition.x, 0);
    }

    public override void OnAnimationComplete(tk2dSpriteAnimator animator, tk2dSpriteAnimationClip animationClip)
    {
        base.OnAnimationComplete(animator, animationClip);
        if (m_fOffset > 0)
        {
            if (m_fV0 < 0)
                m_stateManager.EnterState(EActionState.Jump_Fall, new object[] { m_fV0, m_fOffset });
            else
                m_stateManager.EnterState(EActionState.Jump_Up, new object[] { m_fV0, m_fOffset });
        }    
    }
}
