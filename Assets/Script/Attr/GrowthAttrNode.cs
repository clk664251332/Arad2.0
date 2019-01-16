using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Config;

public class GrowthAttrNode : AttributeNode
{
    private ProfessionAttrLoader.Data professionAttrLoaderData;
    public GrowthAttrNode(AttrAbility attrAbility) : base(attrAbility)
    {

    }

    public override void Initialize()
    {
        base.Initialize();
        //从配置表中加载初始属性
        professionAttrLoaderData = ConfigManager.Instance.GetData<ProfessionAttrLoader, ProfessionAttrLoader.Data>(m_attrAbility.m_owner.AttrConfigId);

        SetAttrValue(EActorAttr.WalkSpeed, professionAttrLoaderData.WalkSpeed);
        SetAttrValue(EActorAttr.RunSpeed, professionAttrLoaderData.RunSpeed);
        SetAttrValue(EActorAttr.AttackSpeed, professionAttrLoaderData.AttackSpeed);
        SetAttrValue(EActorAttr.JumpSpeed, professionAttrLoaderData.JumpSpeed);
        SetAttrValue(EActorAttr.JumpGravity, professionAttrLoaderData.JumpGravity);

        SetAttrValue(EActorAttr.HP, professionAttrLoaderData.HP);
        SetAttrValue(EActorAttr.MP, professionAttrLoaderData.MP);
        SetAttrValue(EActorAttr.MaxHP, professionAttrLoaderData.MaxHP);
        SetAttrValue(EActorAttr.MaxMP, professionAttrLoaderData.MaxMP);
        SetAttrValue(EActorAttr.HpRecoverSpeed, professionAttrLoaderData.HpRecoverSpeed);
        SetAttrValue(EActorAttr.MpRecoverSpeed, professionAttrLoaderData.MpRecoverSpeed);
        SetAttrValue(EActorAttr.Level, professionAttrLoaderData.Level);
        SetAttrValue(EActorAttr.CurExp, professionAttrLoaderData.CurExp);
        SetAttrValue(EActorAttr.UpLevelNeedExp, professionAttrLoaderData.UpLevelNeedExp);
        SetAttrValue(EActorAttr.Gold, professionAttrLoaderData.Gold);

        SetAttrValue(EActorAttr.Strength, professionAttrLoaderData.Strength);
        SetAttrValue(EActorAttr.Endurance, professionAttrLoaderData.Endurance);
        SetAttrValue(EActorAttr.Intelligence, professionAttrLoaderData.Intelligence);
        SetAttrValue(EActorAttr.Spirit, professionAttrLoaderData.Spirit);
        SetAttrValue(EActorAttr.PhysicalAttack, professionAttrLoaderData.PhysicalAttack);
        SetAttrValue(EActorAttr.PhysicalDefence, professionAttrLoaderData.PhysicalDefence);
        SetAttrValue(EActorAttr.MagicAttack, professionAttrLoaderData.MagicAttack);
        SetAttrValue(EActorAttr.MagicDefence, professionAttrLoaderData.MagicDefence);
        SetAttrValue(EActorAttr.CriticalChance, professionAttrLoaderData.CriticalChance);
        SetAttrValue(EActorAttr.CriticalDamage, professionAttrLoaderData.CriticalDamage);
    }


}
