using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Config;

public class SkillBase
{
    protected Actor m_actor;
    private uint skillId;
    protected SkillLoader.Data m_infoSkill;

    public uint SkillId
    {
        get
        {
            return skillId;
        }

        set
        {
            skillId = value;
        }
    }

    public virtual void Update()
    {

    }

    public virtual void Release()
    {

    }
}
