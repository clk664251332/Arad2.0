using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttrData
{
    private AttrAbility m_attrAbility;
    //private List<AttrValue> 
    //基础属性
    public AttrValue HP;
    public AttrValue MP;
    public AttrValue MaxHP;
    public AttrValue MaxMP;
    public AttrValue HpRecoverSpeed;
    public AttrValue MpRecoverSpeed;
    public AttrValue Level;
    public AttrValue CurExp;
    public AttrValue UpLevelNeedExp;
    public AttrValue Gold;
    //战斗属性
    public AttrValue Strength;
    public AttrValue Endurance;
    public AttrValue Intelligence;
    public AttrValue Spirit;
    public AttrValue PhysicalAttack;
    public AttrValue PhysicalDefence;
    public AttrValue MagicAttack;
    public AttrValue MagicDefence;
    public AttrValue CriticalChance;
    //移动控制属性
    public AttrValue WalkSpeed;
    public AttrValue RunSpeed;
    public AttrValue AttackSpeed;
    public AttrValue JumpSpeed;
    public AttrValue JumpGravity;

    public AttrData(AttrAbility attrAbility)
    {
        m_attrAbility = attrAbility;
        //基础属性
        HP = new AttrValue(EActorAttr.HP, m_attrAbility);
        MP = new AttrValue(EActorAttr.HP, m_attrAbility);
        MaxHP = new AttrValue(EActorAttr.HP, m_attrAbility);
        MaxMP = new AttrValue(EActorAttr.HP, m_attrAbility);
        HpRecoverSpeed = new AttrValue(EActorAttr.HP, m_attrAbility);
        MpRecoverSpeed = new AttrValue(EActorAttr.HP, m_attrAbility);
        Level = new AttrValue(EActorAttr.HP, m_attrAbility);
        CurExp = new AttrValue(EActorAttr.HP, m_attrAbility);
        UpLevelNeedExp = new AttrValue(EActorAttr.HP, m_attrAbility);
        Gold = new AttrValue(EActorAttr.HP, m_attrAbility);
        //战斗属性
        Strength = new AttrValue(EActorAttr.HP, m_attrAbility);
        Endurance = new AttrValue(EActorAttr.HP, m_attrAbility);
        Intelligence = new AttrValue(EActorAttr.HP, m_attrAbility);
        Spirit = new AttrValue(EActorAttr.HP, m_attrAbility);
        PhysicalAttack = new AttrValue(EActorAttr.HP, m_attrAbility);
        PhysicalDefence = new AttrValue(EActorAttr.HP, m_attrAbility);
        MagicAttack = new AttrValue(EActorAttr.HP, m_attrAbility);
        MagicDefence = new AttrValue(EActorAttr.HP, m_attrAbility);
        CriticalChance = new AttrValue(EActorAttr.HP, m_attrAbility);
        //移动控制属性
        WalkSpeed = new AttrValue(EActorAttr.HP, m_attrAbility);
        RunSpeed = new AttrValue(EActorAttr.HP, m_attrAbility);
        AttackSpeed = new AttrValue(EActorAttr.HP, m_attrAbility);
        JumpSpeed = new AttrValue(EActorAttr.HP, m_attrAbility);
        JumpGravity = new AttrValue(EActorAttr.HP, m_attrAbility);
    }

}
