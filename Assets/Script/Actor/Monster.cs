using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : Actor
{
    public Monster() : base()
    {
        m_stateMgr = new PlayerStateManager(this as Actor);
    }

    public override void AddAbility()
    {
        base.AddAbility();
        m_AbilityManager.AddAbility<AIAbility>(this);
        m_AbilityManager.AddAbility<TalkAbility>(this);
    }

    public override void Initialize()
    {
        base.Initialize();
        m_stateMgr.EnterState(EActionState.Idle);
    }

    public override void Release()
    {
        base.Release();
    }

    public override void Update()
    {
        base.Update();
        m_stateMgr.Update();
    }

    public override string ToString()
    {
        return base.ToString() + " 状态---" + m_stateMgr.GetCurrActionState().ToString();
    }
}
