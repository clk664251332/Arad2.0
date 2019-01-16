using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Config
{
    public partial class SkillLoader : ScriptableObjectBase
    {
        public partial class Data : ObjectBase
        {
            public override void ParseData()
            {
                base.ParseData();
            }
        }

        public List<uint> GetFixedEffectIdList(uint uIndex)
        {
            string strTemp = this.GetData<SkillLoader.Data>(uIndex).FixedEffectId;
            List<uint> listTemp = new List<uint>();

            CommonHelper.TransStrToUintList(listTemp, strTemp, '~');
            if (listTemp.Count == 1 && listTemp[0] == 0)
                return null;
            return listTemp;
        }

        public List<uint> GetSkillEffectIdList(uint uIndex)
        {
            string strTemp = this.GetData<SkillLoader.Data>(uIndex).SkillEffectId;
            List<uint> listTemp = new List<uint>();

            CommonHelper.TransStrToUintList(listTemp, strTemp, '~');
            if (listTemp.Count == 1 && listTemp[0] == 0)
                return null;
            return listTemp;
        }

        public ESkillType GetSKillType(uint uIndex)
        {
            uint nTemp = this.GetData<SkillLoader.Data>(uIndex).SkillType;
            return (ESkillType)nTemp;
        }
    }

}
