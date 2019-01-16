using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill1State : BaseSkillState
{
    public Skill1State(Actor actor) : base(actor, EActionState.Skill1)
    {

    }

    public override void EnterState(EActionState eState)
    {
        base.EnterState(eState);
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
        base.OnAnimationComplete(animator, animationClip);
    }
}
