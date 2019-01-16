using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseAbility
{
    public Actor m_owner;

    public void SetOwner(Actor actor)
    {
        m_owner = actor;
    }

    public virtual void Initialize()
    {

    }
    /// <summary>
    /// 在初始化之后调用，防止空指针；用于Abllity之间相互获得对象
    /// </summary>
    public virtual void GetComponent() { }

    public virtual void Update()
    {

    }

    public virtual void Release()
    {

    }
}
