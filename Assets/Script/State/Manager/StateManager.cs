using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Config;
using System;

public class BaseStateManager
{
    protected Actor m_owner;
    protected BaseState m_currState;
    protected List<BaseState> m_lstState = new List<BaseState>();

    public BaseStateManager(Actor actor)
    {
        m_owner = actor;
    }

    public void EnterState(EActionState eState)
    {
        if(m_currState != null)
        {
            if (m_currState.GetState() == eState)
                return;
        }
        
        EActionState eLastState = EActionState.None;

        if (m_currState != null)
        {
            eLastState = m_currState.GetState();
            m_currState.BreakState(eState);
        }

        for (int i = 0; i < m_lstState.Count; ++i)
        {
            if (m_lstState[i].GetState() == eState)
            {
                m_currState = m_lstState[i];
                m_lstState[i].EnterState(eLastState);
            }
        }
    }

    public void EnterState(EActionState eState, params object[] paramList)
    {
        if (m_currState != null)
        {
            if (m_currState.GetState() == eState)
                return;
        }

        EActionState eLastState = EActionState.None;

        if (m_currState != null)
        {
            eLastState = m_currState.GetState();
            m_currState.BreakState(eState);
        }

        for (int i = 0; i < m_lstState.Count; ++i)
        {
            if (m_lstState[i].GetState() == eState)
            {
                m_currState = m_lstState[i];
                m_lstState[i].EnterState(eLastState, paramList);
            }
        }
    }

    public void EnterState(string strStateName)
    {
        EActionState eState = (EActionState)Enum.Parse(typeof(EActionState), strStateName);
        EnterState(eState);
    }

    public BaseState GetState(EActionState eState)
    {
        for (int i = 0; i < m_lstState.Count; ++i)
        {
            if (m_lstState[i].GetState() == eState)
            {
                return m_lstState[i];
            }
        }

        return null;
    }

    public EActionState GetCurrActionState()
    {
        if (null == m_currState)
            return EActionState.None;

        return m_currState.GetState();
    }

    public BaseState GetCurrState()
    {
        return m_currState;
    }

    public void Update()
    {
        if (m_currState != null)
            m_currState.OnUpdate();
    }

    public void FixedUpdate()
    {
        if (m_currState != null)
            m_currState.OnFixedUpdate();
    }

    public void Release()
    {
        if (m_currState != null)
            m_currState.BreakState(EActionState.None);

        Reset();

        foreach (var stateItem in m_lstState)
        {
            stateItem.Release();
        }

        m_currState = null;
    }

    public void Reset()
    {
        for (int i = 0; i < m_lstState.Count; ++i)
        {
            m_lstState[i].Reset();
        }
    }
}
