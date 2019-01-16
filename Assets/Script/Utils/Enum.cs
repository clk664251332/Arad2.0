using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EActionState
{
    None,
    Idle,
    Walk,
    Run,
    Jump_Prepare,
    Jump_Up,
    Jump_Fall,
    Jump_Down,
    Attack1,
    Attack2,
    Attack3,
    Attack4,
    RunAttack,//冲刺斩
    JumpAttack,//跳斩
    Skill1,
    Skill2,
    Skill3,
    Skill4,
    Skill5,
    Skill6,
    Skill7,
    Skill8,
    Skill9,
    Behit,
    HitDown,//倒地
    BeatFly,//击飞
    Floating,//浮空
    Stun,//麻痹
    Die,//死亡
}

public enum EEventType
{
    AttrChange = 100,
}

public enum EActorAttr
{
    AttrBegin,
    //移动控制属性
    WalkSpeed,
    RunSpeed,
    AttackSpeed,
    JumpSpeed,
    JumpGravity,

    //基础属性
    HP,
    MP,
    MaxHP,
    MaxMP,
    HpRecoverSpeed,
    MpRecoverSpeed,
    Level,
    CurExp,
    UpLevelNeedExp,
    Gold,

    //战斗属性
    Strength,       //力量
    Endurance,      //体力
    Intelligence,   //智力
    Spirit,         //精神
    PhysicalAttack, //物理攻击
    PhysicalDefence,//物理防御
    MagicAttack,    //魔法攻击
    MagicDefence,   //魔法防御
    CriticalChance, //暴击几率
    CriticalDamage, //暴击伤害

    AttrEnd
}

public enum ESkillType
{
    None,
    WeaponType,//根据武器判定造成伤害
    EffectType,//根据特效判定造成伤害
    BuffType,//增加Buff的技能
}

public enum EPartType
{
    //0
    Body,
    //1
    Hair_a,
    Hair_b,
    Neck_c,
    Neck_d,
    Neck_x,
    Coat_a,
    Coat_b,
    Coat_c,
    Coat_d,
    //2
    Cap_a,
    Cap_b,
    Face_b,
    Face_c,
    Belt_a,
    Belt_b,
    Belt_c,
    Belt_d,
    Pants_a,
    Pants_b,
    Pants_c,
    Pants_d,
    Shoes_a,
    Shoes_b,
    Weapon_a,
    Weapon_b,
    Weapon_c,
    Weapon_d,
    Weapon_x,
    Subweapon_a,
    Subweapon_b,
    Subweapon_c,
    Subweapon_d,
    Subweapon_x,
    End,
}

