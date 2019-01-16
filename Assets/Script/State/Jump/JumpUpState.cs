using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpUpState : BaseJumpState
{
    public JumpUpState(Actor actor) : base(actor, EActionState.Jump_Up)
    {

    }

    public override void BreakState(EActionState eState)
    {
        base.BreakState(eState);
    }

    public override void EnterState(EActionState eState)
    {
        base.EnterState(eState);
        m_owner.CanJumpAttack = true;

        m_fV0 = m_owner.GetAttr(EActorAttr.JumpSpeed).Value;
        m_fGravity = m_owner.GetAttr(EActorAttr.JumpGravity).Value;
        m_fOffset = 0;
        m_tk2DSpriteAnimator.Play("Jump_Up");
    }

    public override void EnterState(EActionState eState, params object[] paramList)
    {
        base.EnterState(eState, paramList);

        m_tk2DSpriteAnimator.Play("Jump_Up");
        if (paramList.Length > 0)
        {
            m_fV0 = (float)paramList.GetValue(0);
            m_fOffset = (float)paramList.GetValue(1);
            m_owner.CanJumpAttack = false;
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

        if (m_fV0 < 0)
            m_stateManager.EnterState(EActionState.Jump_Fall, new object[] { m_fV0, m_fOffset });

        if(Input.GetKeyDown(KeyCode.X) && m_owner.CanJumpAttack)
            m_stateManager.EnterState(EActionState.JumpAttack, new object[] { m_fV0, m_fOffset });
    }

    public override void Release()
    {
        base.Release();
    }
}
