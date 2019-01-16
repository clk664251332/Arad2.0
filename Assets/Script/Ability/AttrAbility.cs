using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttrAbility : BaseAbility
{
    private AttributeNode m_attributeAll; //最终属性
    private AttributeNode m_attributeGrowth;//级别的属性加成，也可视为基础属性
    private AttributeNode m_attributeEquip;//装备的属性加成
    private AttributeNode m_attributeBuff;//Buff的属性加成

    public override void GetComponent()
    {
        base.GetComponent();
    }

    public override void Initialize()
    {
        base.Initialize();

        m_attributeAll = new AttributeNode(this, true);//最终结果属性进行事件监听
        m_attributeGrowth = new GrowthAttrNode(this);
        m_attributeEquip = new EquipAttrNode(this);
        m_attributeBuff = new BuffAttrNode(this);
        //添加子节点
        m_attributeAll.AddChildNode(m_attributeGrowth);
        m_attributeAll.AddChildNode(m_attributeEquip);
        m_attributeAll.AddChildNode(m_attributeBuff);
        //各个分支属性的初始化
        m_attributeGrowth.Initialize();
        m_attributeEquip.Initialize();
        m_attributeBuff.Initialize();
        //计算
        m_attributeAll.Calculate();
    }

    public override void Release()
    {
        base.Release();
    }

    public override void Update()
    {
        base.Update();
        if (Input.GetKeyDown(KeyCode.P))
        {
            for (int i = 0; i < (int)EActorAttr.AttrEnd; i++)
            {
                var attrValue = m_attributeAll.m_lstValues[i];
                Debug.Log("类型：" + ((EActorAttr)i).ToString() + " 值：" + attrValue.Value);
            }
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            var buff = m_attributeBuff as BuffAttrNode;
            buff.ChangeWalkSpeedTest();
        }
    }

    public AttrValue GetAttr(EActorAttr eActorAttr)
    {
        for (int i = 0; i < (int)EActorAttr.AttrEnd; i++)
        {
            if ((int)eActorAttr == i)
                return m_attributeAll.m_lstValues[i];
        }
        return null;
    }

    //重新计算某个属性，会触发该属性的变化事件
    public void ReCalculate(EActorAttr eActorAttr)
    {
        m_attributeAll.Calculate(eActorAttr);
    }

    public void ReCalculateAll()
    {
        m_attributeAll.Calculate();
    }
}
