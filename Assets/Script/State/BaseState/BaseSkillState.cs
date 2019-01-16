using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Config;

public class BaseSkillState : BaseBattleState
{
    List<GameObject> m_lstEffectObj = new List<GameObject>();
    List<tk2dSprite> m_lstEffectSprite = new List<tk2dSprite>();
    List<int> m_lstStartFramName = new List<int>();
    List<int> m_lstEndFramName = new List<int>();

    SkillLoader m_skillLoader;
    List<uint> m_lstFixedEffectId;
    private bool m_bHasInit = false;
    public BaseSkillState(Actor actor, EActionState eActionState) : base(actor, eActionState)
    {

    }

    public override void EnterState(EActionState eState)
    {
        base.EnterState(eState);

        if (m_bHasInit) return;

        if(m_skillLoader == null)
        {
            m_skillLoader = ConfigManager.Instance.GetLoader<SkillLoader>();
        }

        if (m_lstFixedEffectId == null)
        {
            m_lstFixedEffectId = m_skillLoader.GetFixedEffectIdList(m_skillData.Id);
        }

        if (m_lstFixedEffectId != null && m_lstFixedEffectId.Count > 0)
        {
            for (int i = 0; i < m_lstFixedEffectId.Count; i++)
            {
                var fixedEffectLoaderData = ConfigManager.Instance.GetData<FixedEffectLoader, FixedEffectLoader.Data>(m_lstFixedEffectId[i]);

                GameObject m_effectObj = new GameObject("effect_" + m_skillData.ActionName + "_" + fixedEffectLoaderData.Id);
                m_effectObj.transform.parent = m_tk2DSpriteAnimator.transform.Find("Effect");
                m_effectObj.transform.localPosition = Vector3.zero;
                tk2dSprite m_effectSprite = Common.GetOrAddComponent<tk2dSprite>(m_effectObj);
                tk2dSpriteCollectionData tk2DSpriteCollectionData = tk2dSystem.LoadResourceByName<tk2dSpriteCollectionData>(fixedEffectLoaderData.CollectionName);
                m_effectSprite.SetSprite(tk2DSpriteCollectionData, 0);
                m_effectSprite.SortingLevel = 3;
                m_effectObj.SetActive(false);
                m_lstEffectObj.Add(m_effectObj);
                m_lstEffectSprite.Add(m_effectSprite);
                m_lstStartFramName.Add(int.Parse(fixedEffectLoaderData.StartFrameName));
                m_lstEndFramName.Add(int.Parse(fixedEffectLoaderData.EndFrameName));
            }
        }
        m_bHasInit = true;
    }

    public override void BreakState(EActionState eState)
    {
        base.BreakState(eState);
    }

    public override void OnUpdate()
    {
        base.OnUpdate();
        //可以在这里进行特效图片的同步，找到显示特效的物体与组件，设置组件的图集，然后同步
        //if(开始图片<当前图片名字<结束)
        //显示特效物体
        //m_tk2DSpriteAnimator
        int CurSpriteId = m_tk2DSpriteAnimator.CurrentSpriteId;

        for (int i = 0; i < m_lstEffectObj.Count; i++)
        {
            if (m_lstStartFramName[i] <= CurSpriteId && CurSpriteId <= m_lstEndFramName[i])
                m_lstEffectObj[i].SetActive(true);
            else
                m_lstEffectObj[i].SetActive(false);
        }

        for (int i = 0; i < m_lstEffectSprite.Count; i++)
        {
            if (m_lstStartFramName[i] <= CurSpriteId && CurSpriteId <= m_lstEndFramName[i])
            {
                m_lstEffectSprite[i].SetSprite(CurSpriteId.ToString());
                m_lstEffectSprite[i].SortingOrder = 600 - (int)m_owner.Transform.position.y + m_lstEffectSprite[i].SortingLevel;
                m_lstEffectSprite[i].FlipX = m_owner.Direction == 1 ? false : true;
            }
        }
    }

    public override void OnAnimationComplete(tk2dSpriteAnimator animator, tk2dSpriteAnimationClip animationClip)
    {
        base.OnAnimationComplete(animator, animationClip);
        m_stateManager.EnterState(EActionState.Idle);

        for (int i = 0; i < m_lstEffectObj.Count; i++)
        {
            m_lstEffectObj[i].SetActive(false);
        }
    }

    public override void Release()
    {
        base.Release();
        for (int i = 0; i < m_lstEffectObj.Count; i++)
        {
            GameObject.DestroyImmediate(m_lstEffectObj[i]);
        }

        m_lstEffectObj.Clear();
        m_lstEffectSprite.Clear();
        if (m_lstFixedEffectId != null)
            m_lstFixedEffectId.Clear();
        m_lstStartFramName.Clear();
        m_lstEndFramName.Clear();
    }
}
