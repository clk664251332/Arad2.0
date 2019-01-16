using UnityEngine;
using System;
using System.Collections.Generic;

namespace Game.Config
{
    [Serializable]
    [ConfigName("c_fashion")]
    public partial class FashionLoader : ScriptableObjectBase
    {
        [Serializable]
        public partial class Data : ObjectBase
        {
            public uint Id; // ID
            public string Remark; // 备注
            public uint Body; // 皮肤
            public uint Hair_a; // 头发a
            public uint Hair_b; // 头发b
            public uint Cap_a; // 帽子a
            public uint Cap_b; // 帽子b
            public uint Face_b; // 面部b
            public uint Face_c; // 面部c
            public uint Neck_c; // 项链c
            public uint Neck_d; // 项链d
            public uint Neck_x; // 项链x
            public uint Coat_a; // 上衣_a
            public uint Coat_b; // 上衣_b
            public uint Coat_c; // 上衣_c
            public uint Coat_d; // 上衣_d
            public uint Belt_a; // 腰带a
            public uint Belt_b; // 腰带b
            public uint Belt_c; // 腰带c
            public uint Belt_d; // 腰带d
            public uint Pants_a; // 下装_a
            public uint Pants_b; // 下装_b
            public uint Pants_c; // 下装_c
            public uint Pants_d; // 下装_d
            public uint Shoes_a; // 鞋_a
            public uint Shoes_b; // 鞋_b
            public uint Weapon_a; // 武器_a
            public uint Weapon_b; // 武器_b
            public uint Weapon_c; // 武器_c
            public uint Weapon_d; // 武器_d
            public uint Weapon_x; // 武器_x
            public uint Subweapon_a; // 副武器_a
            public uint Subweapon_b; // 副武器_b
            public uint Subweapon_c; // 副武器_c
            public uint Subweapon_d; // 副武器_d
            public uint Subweapon_x; // 副武器_x
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
