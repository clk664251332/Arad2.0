using UnityEngine;
using System;
using System.Collections.Generic;

namespace Game.Config
{
    [Serializable]
    [ConfigName("c_skill")]
    public partial class SkillLoader : ScriptableObjectBase
    {
        [Serializable]
        public partial class Data : ObjectBase
        {
            public uint Id; // 技能ID
            public string Remark; // 备注名称
            public string Profession; // 所属职业
            public string ActionName; // 动作名称
            public string NextActionName; // 下连动作名称
            public float MoveSpeed; // 动作位移速度
            public float MoveFriction; // 位移摩擦阻力
            public uint EarlyEndFramIndex; // 提前结束帧序号
            public uint AttackFramIndex; // 攻击判定帧序号
            public uint SkillType; // 技能类型1武器2特效3Buff
            public string FixedEffectId; // 技能固定特效Id
            public string SkillEffectId; // 技能特效
            public uint CreateSkillEffectFrame; // 释放技能特效帧Id
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
