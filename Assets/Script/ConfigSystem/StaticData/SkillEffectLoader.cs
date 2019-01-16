using UnityEngine;
using System;
using System.Collections.Generic;

namespace Game.Config
{
    [Serializable]
    [ConfigName("c_skill_effect")]
    public partial class SkillEffectLoader : ScriptableObjectBase
    {
        [Serializable]
        public partial class Data : ObjectBase
        {
            public uint Id; // 特效Id
            public string Remark; // 备注名称
            public string AnimationName; // 动画名称
            public string PrefabName; // 预设名字
            public uint Number; // 数量
            public float CreatDeltaTime; // 产生时间间隔
            public string CreatPosOffset; // 产生位置间隔
            public string StartPosOffset; // 起始点坐标偏移
            public float Speed; // 速度
            public float LifeTime; // 存在时间
            public uint AutoDestory; // 是否碰撞自动销毁
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
