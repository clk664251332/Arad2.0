using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//状态分类：站立/走/跑/跳/技能
//有些技能状态可以被其他动作强制打断
public abstract class BaseState
{
    protected Actor m_owner;
    protected EActionState m_eState;
    //protected float m_fStartTime = 0;
    //protected float m_fActionSpeed = 1.0f;
    protected tk2dSpriteAnimator m_tk2DSpriteAnimator;
    protected BaseStateManager m_stateManager;
    protected HeroInputAbility m_inputAbility;
    

    public BaseState(Actor actor, EActionState eState)
    {
        m_owner = actor;
        m_eState = eState;

        if (m_inputAbility == null)
        {
            m_inputAbility = m_owner.GetAbility<HeroInputAbility>();
        }
    }

    public virtual void Reset()
    {
        //m_fActionSpeed = 1.0f;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="eState">进入新状态后上一个状态</param>
    public virtual void EnterState(EActionState eState)
    {
        if (m_tk2DSpriteAnimator == null)
            m_tk2DSpriteAnimator = m_owner.GetAbility<AnimationAbility>().GetTk2dSpriteAnimator();

        if (m_stateManager == null)
            m_stateManager = m_owner.GetStateMgr();

        m_tk2DSpriteAnimator.AnimationCompleted = OnAnimationComplete;
    }

    public virtual void EnterState(EActionState eState, params object[] paramList)
    {
        EnterState(eState);
    }

    public virtual void OnUpdate()
    {

    }

    public virtual void OnFixedUpdate()
    {

    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="eState">退出后下一个状态</param>
    public virtual void BreakState(EActionState eState)
    {

    }

    public virtual void Release()
    {

    }

    public EActionState GetState()
    {
        return m_eState;
    }

    public virtual void OnAnimationComplete(tk2dSpriteAnimator animator, tk2dSpriteAnimationClip animationClip)
    {

    }
}
