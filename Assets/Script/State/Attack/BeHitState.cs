using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeHitState : BaseState
{
    public BeHitState(Actor actor) : base(actor, EActionState.Behit)
    {

    }

    public override void EnterState(EActionState eState)
    {
        base.EnterState(eState);
        int randomIndex = Random.Range(1, 3);
        m_tk2DSpriteAnimator.Play("Behit" + randomIndex.ToString());
    }

    public override void BreakState(EActionState eState)
    {
        base.BreakState(eState);
    }

    public override void OnAnimationComplete(tk2dSpriteAnimator animator, tk2dSpriteAnimationClip animationClip)
    {
        base.OnAnimationComplete(animator, animationClip);
        m_stateManager.EnterState(EActionState.Idle);
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
