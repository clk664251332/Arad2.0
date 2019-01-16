using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunState : BaseMovementState
{
    public RunState(Actor actor) : base(actor, EActionState.Run)
    {
    }

    public override void EnterState(EActionState eState)
    {
        base.EnterState(eState);
        m_owner.IsRun = true;
        m_tk2DSpriteAnimator.Play("Run");
    }

    public override void BreakState(EActionState eState)
    {
        base.BreakState(eState);
        m_owner.IsRun = false;
    }

    public override void OnUpdate()
    {
        base.OnUpdate();
        if (m_owner is Hero && Input.GetKeyDown(KeyCode.X))
        {
            m_stateManager.EnterState(EActionState.RunAttack);
        }
    }
}
