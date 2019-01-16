using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttributeNode
{
    private AttributeNode m_Parent;
    private List<AttributeNode> m_childNodeList = new List<AttributeNode>();
    protected AttrAbility m_attrAbility;
    public List<AttrValue> m_lstValues = new List<AttrValue>();

    public AttributeNode(AttrAbility attrAbility, bool bListen = false)
    {
        m_attrAbility = attrAbility;
        for (int i = 0; i < (int)EActorAttr.AttrEnd; i++)
        {
            AttrValue attrValue = new AttrValue((EActorAttr)i, attrAbility, bListen);
            m_lstValues.Add(attrValue);
        }
    }

    public virtual void Initialize()
    {

    }

    public void Calculate()
    {
        foreach (AttributeNode childNode in m_childNodeList)
        {
            if (childNode.GetChildNodeCount() > 0)
            {
                ResetValue();
                childNode.Calculate();
            }

            for (int i = 0; i < (int)EActorAttr.AttrEnd; i++)
            {
                m_lstValues[i].PlusValue(childNode.m_lstValues[i].Value);
            }
        }
    }

    public void Calculate(EActorAttr eActorAttr)
    {
        if (GetParent() == null) ResetValue(eActorAttr);

        foreach (AttributeNode childNode in m_childNodeList)
        {
            if (childNode.GetChildNodeCount() > 0)
            {
                ResetValue(eActorAttr);
                childNode.Calculate(eActorAttr);
            }

            for (int i = 0; i < (int)EActorAttr.AttrEnd; i++)
            {
                if ((int)eActorAttr == i)
                    m_lstValues[i].PlusValue(childNode.m_lstValues[i].Value);
            }
        }
    }

    public void SetAttrValue(EActorAttr eActorAttr, float value)
    {
        m_lstValues[(int)eActorAttr].SetValue(value);
    }

    public void ResetValue()
    {
        for (int i = 0; i < (int)EActorAttr.AttrEnd; i++)
        {
            m_lstValues[i].SetValue(0);
        }
    }

    public void ResetValue(EActorAttr eActorAttr)
    {
        for (int i = 0; i < (int)EActorAttr.AttrEnd; i++)
        {
            if ((int)eActorAttr == i)
                m_lstValues[i].SetValue(0);
        }
    }

    public void SetParent(AttributeNode parent)
    {
        m_Parent = parent;
    }

    public AttributeNode GetParent()
    {
        return m_Parent;
    }

    public int GetChildNodeCount()
    {
        return m_childNodeList.Count;
    }

    public void AddChildNode(AttributeNode childNode)
    {
        childNode.SetParent(this);
        m_childNodeList.Add(childNode);
    }
    public void RemoveChildNode(AttributeNode childNode)
    {
        m_childNodeList.Remove(childNode);
    }
}
