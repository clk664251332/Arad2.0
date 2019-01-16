using UnityEngine;
using System;
using System.Collections.Generic;

namespace Game.Config
{
    [Serializable]
    [ConfigName("c_profession_skill")]
    public partial class ProfessionSkillLoader : ScriptableObjectBase
    {
        [Serializable]
        public partial class Data : ObjectBase
        {
            public uint Id; // Id
            public string Remark; // 备注
            public uint Attack1Id; // 普攻1
            public uint Attack2Id; // 普攻2
            public uint Attack3Id; // 普攻3
            public uint Attack4Id; // 普攻4
            public uint RunAttackId; // 冲刺
            public uint JumpAttackId; // 跳斩
            public uint Skill1Id; // 技能1
            public uint Skill2Id; // 技能2
            public uint Skill3Id; // 技能3
            public uint Skill4Id; // 技能4
            public uint Skill5Id; // 技能5
            public uint Skill6Id; // 技能6
            public uint Skill7Id; // 技能7
            public uint Skill8Id; // 技能8
            public uint Skill9Id; // 技能9
            public uint Skill10Id; // 技能10
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
