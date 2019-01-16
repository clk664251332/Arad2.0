using UnityEngine;
using System;
using System.Collections.Generic;

namespace Game.Config
{
    [Serializable]
    [ConfigName("c_profession_attr")]
    public partial class ProfessionAttrLoader : ScriptableObjectBase
    {
        [Serializable]
        public partial class Data : ObjectBase
        {
            public uint Id; // Id
            public string Remark; // 备注
            public float WalkSpeed; // 走路速度
            public float RunSpeed; // 跑步速度
            public float AttackSpeed; // 攻击速度
            public float JumpSpeed; // 跳跃速度
            public float JumpGravity; // 跳跃重力
            public float HP; // 血量
            public float MP; // 蓝量
            public float MaxHP; // 最大血量
            public float MaxMP; // 最大蓝量
            public float HpRecoverSpeed; // 血量回复
            public float MpRecoverSpeed; // 蓝量回复
            public float Level; // 等级
            public float CurExp; // 当前经验
            public float UpLevelNeedExp; // 升级所需经验
            public float Gold; // 金币
            public float Strength; // 力量
            public float Endurance; // 体力
            public float Intelligence; // 智力
            public float Spirit; // 精神
            public float PhysicalAttack; // 物理攻击
            public float PhysicalDefence; // 物理防御
            public float MagicAttack; // 魔法攻击
            public float MagicDefence; // 魔法防御
            public float CriticalChance; // 暴击几率
            public float CriticalDamage; // 暴击伤害
        }

        public List<Data> datas = new List<Data>();

        private Dictionary<uint, Data> m_dicData = new Dictionary<uint, Data>();

        public override void FillDic()
        {
            base.FillDic();

            m_dicData.Clear();
            for (int i = 0, count = datas.Count; i < count; i++)
            {
                CommonHelper.FillDic<uint, Data>(datas[i].Id, datas[i], m_dicData);
            }
        }

        public override void ParseData()
        {
            base.ParseData();

            for (int i = 0, count = datas.Count; i < count; i++)
            {
                datas[i].ParseData();
            }
        }

        public override T GetData<T>(uint key)
        {
            Data data = null;
            if (m_dicData.TryGetValue(key, out data))
            {
                return data as T;
            }
            return default(T);
        }
    }
}
