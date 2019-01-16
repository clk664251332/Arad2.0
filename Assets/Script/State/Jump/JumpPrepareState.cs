using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPrepareState : BaseJumpState
{
    public JumpPrepareState(Actor actor) : base(actor, EActionState.Jump_Prepare)
    {

    }

    public override void BreakState(EActionState eState)
    {
        base.BreakState(eState);
    }

    public override void EnterState(EActionState eState)
    {
        base.EnterState(eState);
        m_tk2DSpriteAnimator.Play("Jump_Prepare");
    }

    public override void OnAnimationComplete(tk2dSpriteAnimator animator, tk2dSpriteAnimationClip animationClip)
    {
        base.OnAnimationComplete(animator, animationClip);
        m_stateManager.EnterState(EActionState.Jump_Up);
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
