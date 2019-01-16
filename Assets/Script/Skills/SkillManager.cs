using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Config;

public class SkillManager
{
    private List<SkillBase> m_dicSkill = new List<SkillBase>();
    private Actor m_owner;

    public SkillManager(Actor actor)
    {
        m_owner = actor;
    }

    public SkillBase CreateSkill(uint skillId)
    {
        SkillLoader.Data skillLoader = ConfigManager.Instance.GetData<SkillLoader, SkillLoader.Data>(skillId);
        //后面继续完善技能配置系统
        SkillBase skillBase = ReflectionHelper.CreatClassByName<SkillBase>("skill1", new object[2] { m_owner, skillId });
        if (skillBase == null) return null;

        m_dicSkill.Add(skillBase);
        return skillBase;
    }

    public SkillBase GetSkillBySkillId(uint skillId)
    {
        for (int i = 0; i < m_dicSkill.Count; ++i)
        {
            if (m_dicSkill[i].SkillId == skillId)
                return m_dicSkill[i];
        }

        return CreateSkill(skillId);
    }

    public void Update()
    {
        for (int i = 0; i < m_dicSkill.Count; ++i)
        {
            m_dicSkill[i].Update();
        }
    }

    public void Release()
    {
        for (int i = 0; i < m_dicSkill.Count; ++i)
        {
            m_dicSkill[i].Release();
        }

        m_dicSkill.Clear();
    }
}
