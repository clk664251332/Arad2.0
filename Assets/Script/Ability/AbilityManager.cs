using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityManager
{
    public List<BaseAbility> m_listAbilityList = null;

    public AbilityManager()
    {
        m_listAbilityList = new List<BaseAbility>();
    }

    public T AddAbility<T>(Actor actor) where T : BaseAbility, new()
    {
        BaseAbility abilitty = new T();
        abilitty.SetOwner(actor);
        m_listAbilityList.Add(abilitty);
        return abilitty as T;
    }

    public T GetAbility<T>() where T : BaseAbility
    {
        foreach (var ability in m_listAbilityList)
        {
            if (ability is T)
                return ability as T;
        }

        return null;
    }

    //初始化还是不能与构造函数在一起运行
    public void Initialize()
    {
        for (int i = 0; i < m_listAbilityList.Count; i++)
        {
            m_listAbilityList[i].Initialize();
        }
    }
    //用于Ability创建完组件之后，其他Ability相互获得组件
    public void GetComponent()
    {
        for (int i = 0; i < m_listAbilityList.Count; i++)
        {
            m_listAbilityList[i].GetComponent();
        }
    }

    public void Update()
    {
        for (int i = 0; i < m_listAbilityList.Count; i++)
        {
            m_listAbilityList[i].Update();
        }
    }

    public void Release()
    {
        for (int i = 0; i < m_listAbilityList.Count; i++)
        {
            m_listAbilityList[i].Release();
        }

        m_listAbilityList.Clear();
    }
}
