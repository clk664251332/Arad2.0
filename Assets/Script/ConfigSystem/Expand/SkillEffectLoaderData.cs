using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Config
{
    public partial class SkillEffectLoader : ScriptableObjectBase
    {
        public partial class Data : ObjectBase
        {
            public override void ParseData()
            {
                base.ParseData();
            }
        }

        public Vector2 GetStartPosOffset(uint uIndex)
        {
            string strTemp = this.GetData<SkillEffectLoader.Data>(uIndex).StartPosOffset;
            Vector2 startPosOffset = Vector2.zero;
            CommonHelper.TransToVector2(ref startPosOffset, strTemp, '~');
            return startPosOffset;
        }

        public Vector2 GetCreatePosOffset(uint uIndex)
        {
            string strTemp = this.GetData<SkillEffectLoader.Data>(uIndex).CreatPosOffset;
            Vector2 createPosOffset = Vector2.zero;
            CommonHelper.TransToVector2(ref createPosOffset, strTemp, '~');
            return createPosOffset;
        }
    }

}
