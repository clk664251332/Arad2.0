using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Config;

public class CharacterManager : SingletonObject<CharacterManager>
{
    protected List<Actor> m_lstCharacterList = new List<Actor>();
    //存储物体TransForm组件的ID与Actor的映射，便于后面查找
    public Dictionary<int, Actor> m_dicActors = new Dictionary<int, Actor>();

    public  void Initialize()
    {
        //角色的添加暂时先在这里
        if (string.IsNullOrEmpty(SingletonObject<Hero>.Instance.Name))
            CreateActor<Hero>(1001);
       CreateActor<Monster>(1001);
    }

    public Actor CreateActor<T>(uint playerId) where T : Actor, new()
    {
        Actor actor;

        Type t = typeof(T);
        if (t.Name.Equals("Hero"))
            actor = SingletonObject<Hero>.Instance as Actor;
        else
            actor = new T();

        var professionData = ConfigManager.Instance.GetData<ProfessionLoader, ProfessionLoader.Data>(playerId);

        actor.Id = professionData.Id;
        actor.Name = professionData.Name;
        actor.FashionConfigId = professionData.DefaultFashionId;
        actor.SkillConfigId = professionData.DefaultSkillId;
        actor.AttrConfigId = professionData.DefaultAttrId;
        m_lstCharacterList.Add(actor);
        //角色创建出来立刻进行初始化
        actor.Initialize();
        return actor;
    }

    public  void Update()
    {
        for (int i = 0; i < m_lstCharacterList.Count; i++)
        {
            m_lstCharacterList[i].Update();
        }
    }

    public void FixedUpdate()
    {
        for (int i = 0; i < m_lstCharacterList.Count; i++)
        {
            m_lstCharacterList[i].FixedUpdate();
        }
    }

    public void Release()
    {
        for (int i = 0; i < m_lstCharacterList.Count; i++)
        {
            m_lstCharacterList[i].Release();
        }

        m_lstCharacterList.Clear();
        m_dicActors.Clear();
    }

    public List<Actor> GetCharacterList()
    {
        return m_lstCharacterList;
    }
}
