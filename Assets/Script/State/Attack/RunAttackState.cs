using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunAttackState : BaseBattleState
{
    public RunAttackState(Actor actor) : base(actor, EActionState.RunAttack)
    {

    }

    public override void EnterState(EActionState eState)
    {
        base.EnterState(eState);
        m_tk2DSpriteAnimator.Play("RunAttack");
    }

    public override void BreakState(EActionState eState)
    {
        base.BreakState(eState);
    }

    public override void OnUpdate()
    {
        base.OnUpdate();
    }

    public override void OnAnimationComplete(tk2dSpriteAnimator animator, tk2dSpriteAnimationClip animationClip) 
    {
        if (animationClip.name == "RunAttack")
        {
            m_stateManager.EnterState(EActionState.Idle);
        }
    }
}
