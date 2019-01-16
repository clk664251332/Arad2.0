using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack4State : BaseBattleState
{
    public Attack4State(Actor actor) : base(actor, EActionState.Attack4)
    {
    }

    public override void EnterState(EActionState eState)
    {
        base.EnterState(eState);
        //m_tk2DSpriteAnimator.ClipFps = m_owner.GetAttr(EActorAttr.AttackSpeed).Value;

        if (m_owner is Hero)
        {
            if (Input.GetAxisRaw("Horizontal") > 0)
            {
                m_owner.Direction = 1;
                m_fAttackMoveSpeed *= 4f;
            }
            else if (Input.GetAxisRaw("Horizontal") < 0)
            {
                m_owner.Direction = -1;
                m_fAttackMoveSpeed *= 4f;
            }
        }
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
