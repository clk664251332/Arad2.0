using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AttrValue
{
    private EActorAttr m_eActorAttr;
    private float m_lastValue;
    private float m_curValue;
    private bool m_bListen;//是否监听事件

    private AttrAbility m_attrAbility;

    public float Value
    {
        get
        {
            return m_curValue;
        }

        set
        {
            m_curValue = value;
        }
    }

    public AttrValue(EActorAttr eActorAttr, AttrAbility attrAbility, bool isListen = false)
    {
        m_eActorAttr = eActorAttr;
        m_attrAbility = attrAbility;
        m_bListen = isListen;
    }

    public void SetValue(float newValue)
    {
        if (newValue == m_curValue) return;

        m_lastValue = m_curValue;
        m_curValue = newValue;

        if (m_attrAbility != null && m_bListen)
        {
            m_attrAbility.m_owner.SendEvent(EEventType.AttrChange + (int)m_eActorAttr);
            //m_attrAbility.m_owner.SendEvent(EEventType.AttrChange);
        }
    }

    public void PlusValue(float plusValue)
    {
        float newValue = m_curValue + plusValue;
        SetValue(newValue);
    }
}
