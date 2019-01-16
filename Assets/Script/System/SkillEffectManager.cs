using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillEffectManager : SingletonObject<SkillEffectManager>
{
    private List<SkillEffectCreator> m_lstSkillEffects = new List<SkillEffectCreator>();
    private Dictionary<uint, SkillEffectCreator> m_dicSkillEffects = new Dictionary<uint, SkillEffectCreator>();

    public void CreatSkillEffect(uint id, Actor owner)
    {
        //如果该特效已经存在，就拿出来显示重新用
        if (m_dicSkillEffects.ContainsKey(id))
        {
            SkillEffectCreator getSkillEffect;
            m_dicSkillEffects.TryGetValue(id, out getSkillEffect);
            getSkillEffect.CreateSkillEffect();
        }
        else
        {
            SkillEffectCreator skillEffect = new SkillEffectCreator(id, owner);
            skillEffect.CreateSkillEffect();
            m_lstSkillEffects.Add(skillEffect);
            m_dicSkillEffects.Add(id, skillEffect);
        }
    }

    public void Update()
    {
        for (int i = 0; i < m_lstSkillEffects.Count; i++)
        {
            m_lstSkillEffects[i].Update();
        }
    }

    public void Release()
    {
        for (int i = 0; i < m_lstSkillEffects.Count; i++)
        {
            m_lstSkillEffects[i].Release();
        }
    }
}
