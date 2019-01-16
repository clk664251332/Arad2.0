using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : Actor
{
    protected SkillManager m_skillMgr;
    //protected BuffManager m_buffMgr;

    public Hero() : base()
    {
        m_stateMgr = new PlayerStateManager(this as Actor);
        m_skillMgr = new SkillManager(this as Actor);
    }

    public override void AddAbility()
    {
        base.AddAbility();
        m_AbilityManager.AddAbility<HeroInputAbility>(this);
    }

    public override void Initialize()
    {
        base.Initialize();
        m_stateMgr.EnterState(EActionState.Idle);
    }

    public override void Update()
    {
        base.Update();
        m_stateMgr.Update();
        m_skillMgr.Update();
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();
        m_stateMgr.FixedUpdate();
    }

    public override void Release()
    {
        base.Release();
        m_stateMgr.Release();
        m_skillMgr.Release();
    }

    public SkillManager GetSkillMgr()
    {
        return m_skillMgr;
    }

    public override string ToString()
    {
        return base.ToString() + " 状态---" + m_stateMgr.GetCurrActionState().ToString();
    }
}
