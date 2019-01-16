using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpDownState : BaseJumpState
{
    public JumpDownState(Actor actor) : base(actor, EActionState.Jump_Down)
    {

    }

    public override void BreakState(EActionState eState)
    {
        base.BreakState(eState);
        m_animationTrans.localPosition = new Vector2(m_animationTrans.localPosition.x, 0);
    }

    public override void EnterState(EActionState eState)
    {
        base.EnterState(eState);
        m_owner.CanJumpAttack = false;
        m_tk2DSpriteAnimator.Play("Jump_Down");
    }

    public override void OnAnimationComplete(tk2dSpriteAnimator animator, tk2dSpriteAnimationClip animationClip)
    {
        base.OnAnimationComplete(animator, animationClip);
        m_stateManager.EnterState(EActionState.Idle);
    }

    public override void OnFixedUpdate()
    {
        base.OnFixedUpdate();
    }

    public override void OnUpdate()
    {
        base.OnUpdate();
    }

    public override void Release()
    {
        base.Release();
    }
}
