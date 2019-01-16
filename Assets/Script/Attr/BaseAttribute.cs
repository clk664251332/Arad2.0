using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseAttribute
{
    private BaseAttribute m_Parent;

    public abstract void Calculate();

    protected void SetParent(AttributeNode child)
    {
        //child.m_Parent = this.m_Parent;
    }

    public BaseAttribute GetParent()
    {
        return this.m_Parent;
    }
}
