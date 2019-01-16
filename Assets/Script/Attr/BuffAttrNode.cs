using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffAttrNode : AttributeNode
{
    public BuffAttrNode(AttrAbility attrAbility) : base(attrAbility)
    {

    }
    public override void Initialize()
    {
        base.Initialize();
    }

    public void ChangeWalkSpeedTest()
    {
        Debug.Log("Buff：行走速度+200");
        SetAttrValue(EActorAttr.WalkSpeed, 200);
        m_attrAbility.ReCalculate(EActorAttr.WalkSpeed);
    }
}
