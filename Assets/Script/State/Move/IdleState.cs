using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : BaseMovementState
{
    public IdleState(Actor actor) : base(actor, EActionState.Idle)
    {
    }

    public override void EnterState(EActionState eState)
    {
        base.EnterState(eState);
        m_tk2DSpriteAnimator.Play("Idle");
        m_owner.IsJump = false;
    }

    public override void BreakState(EActionState eState)
    {
        base.BreakState(eState);
    }

    public override void OnUpdate()
    {
        base.OnUpdate();
    }
}
