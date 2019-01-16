using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpFallState : BaseJumpState
{
    public JumpFallState(Actor actor) : base(actor, EActionState.Jump_Fall)
    {

    }

    public override void BreakState(EActionState eState)
    {
        base.BreakState(eState);
    }

    public override void EnterState(EActionState eState)
    {
        base.EnterState(eState);
        m_tk2DSpriteAnimator.Play("Jump_Fall");
    }

    public override void EnterState(EActionState eState, params object[] paramList)
    {
        base.EnterState(eState, paramList);
        m_tk2DSpriteAnimator.Play("Jump_Fall");
        if (paramList.Length > 0)
        {
            m_fV0 = (float)paramList.GetValue(0);
            m_fOffset = (float)paramList.GetValue(1);
        }
        m_fGravity = m_owner.GetAttr(EActorAttr.JumpGravity).Value;
    }
    public override void OnAnimationComplete(tk2dSpriteAnimator animator, tk2dSpriteAnimationClip animationClip)
    {
        base.OnAnimationComplete(animator, animationClip);
    }

    public override void OnFixedUpdate()
    {
        base.OnFixedUpdate();
    }

    public override void OnUpdate()
    {
        base.OnUpdate();
        //到达起始点，则改变状态
        if (m_fOffset <= 0)
        {
            m_fOffset = 0;
            m_stateManager.EnterState(EActionState.Jump_Down);
        }

        if (Input.GetKeyDown(KeyCode.X) && m_owner.CanJumpAttack)
            m_stateManager.EnterState(EActionState.JumpAttack, new object[] { m_fV0, m_fOffset });
    }

    public override void Release()
    {
        base.Release();
    }
}
