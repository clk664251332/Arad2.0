using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Config;

public class SkillEffectCreator
{
    private Actor m_owner;
    private SkillEffectLoader.Data m_skillEffectData;
    private Vector2 m_startPosOffset;
    private Vector2 m_createPosOffset;
    private GameObject m_loadObj;
    private Transform m_rootTrans;
    private List<SkillEffect> m_lstSkillList = new List<SkillEffect>();

    public SkillEffectCreator(uint id, Actor owner)
    {
        m_owner = owner;
        m_skillEffectData = ConfigManager.Instance.GetData<SkillEffectLoader, SkillEffectLoader.Data>(id);
        m_startPosOffset = ConfigManager.Instance.GetLoader<SkillEffectLoader>().GetStartPosOffset(id);
        m_createPosOffset = ConfigManager.Instance.GetLoader<SkillEffectLoader>().GetCreatePosOffset(id);
        m_loadObj = Resources.Load<GameObject>("Animator/" + m_skillEffectData.PrefabName);
        GameObject go = new GameObject("SkillEffect_" + id);
        m_rootTrans = go.transform;
    }

    public void CreateSkillEffect()
    {
        uint count = m_skillEffectData.Number;
        if (count <= 0) return;

        bool hasInit = count == m_lstSkillList.Count;

        float startShowTime = 0;
        Vector2 startPos = (Vector2)m_owner.Transform.position + m_startPosOffset;

        for (int i = 0; i < count; i++)
        {
            if (!hasInit)
            {
                SkillEffect skillEffect = new SkillEffect(m_skillEffectData);
                m_lstSkillList.Add(skillEffect);
                skillEffect.Initialize(startShowTime, startPos, m_owner.Direction, m_loadObj, m_rootTrans, m_owner);
            }
            else
            {
                m_lstSkillList[i].Initialize(startShowTime, startPos, m_owner.Direction, m_loadObj, m_rootTrans, m_owner);
            }

            startShowTime += m_skillEffectData.CreatDeltaTime;
            startPos += m_createPosOffset;
        }
    }

    public void Update()
    {
        for (int i = 0; i < m_lstSkillList.Count; i++)
        {
            m_lstSkillList[i].Update();
        }
    }

    public void Release()
    {
        for (int i = 0; i < m_lstSkillList.Count; i++)
        {
            m_lstSkillList[i].Release();
        }
    }
}

public class SkillEffect
{
    private SkillEffectLoader.Data m_skillEffectData;
    private tk2dSprite m_tk2DSprite;
    private GameObject m_effectObj;
    private Rigidbody2D m_rig2d;
    private Vector2 m_velocity;
    private float m_createTimeSave;
    private float m_showTimeSave = -1;
    private tk2dSpriteAnimator m_tk2DSpriteAnimator;
    private float m_delayShowTimeDelta;
    private Actor m_owner;
    //private int m_hitCount;
    private bool m_bCanHit;

    public SkillEffect(SkillEffectLoader.Data skillEffectData)
    {
        m_skillEffectData = skillEffectData;
    }

    public void Initialize(float showTimeDelta, Vector2 startPos, int direction, GameObject loadObj, Transform rootTrans, Actor owner)
    {
        if (m_effectObj == null)
        {
            m_effectObj = Object.Instantiate(loadObj, startPos, Quaternion.identity);
            m_effectObj.transform.parent = rootTrans;
        }
        if (m_tk2DSpriteAnimator == null)
        {
            m_tk2DSpriteAnimator = Common.GetOrAddComponent<tk2dSpriteAnimator>(m_effectObj);
        }
        if (m_tk2DSprite == null)
        {
            m_tk2DSprite = Common.GetOrAddComponent<tk2dSprite>(m_effectObj);
        }
        if (m_rig2d == null)
        {
            m_rig2d = Common.GetOrAddComponent<Rigidbody2D>(m_effectObj);
            m_rig2d.gravityScale = 0;
            m_rig2d.bodyType = RigidbodyType2D.Kinematic;
        }

        m_owner = owner;
        m_tk2DSprite.FlipX = direction == 1 ? false : true;
        m_tk2DSpriteAnimator.Play(m_skillEffectData.AnimationName);
        m_velocity = new Vector2(direction * m_skillEffectData.Speed, 0);
        m_createTimeSave = Time.time;
        m_delayShowTimeDelta = showTimeDelta;
        m_showTimeSave = m_createTimeSave + m_delayShowTimeDelta;
        m_effectObj.transform.position = startPos;
        m_bCanHit = true;
        m_effectObj.SetActive(false);
    }

    public void Update()
    {
        m_tk2DSprite.SortingOrder = 600 - (int)m_effectObj.transform.position.y + 4;

        if (Time.time - m_createTimeSave >= m_delayShowTimeDelta)
        {
            m_effectObj.SetActive(true);
            m_rig2d.velocity = m_velocity;

            //检测碰撞
            if (m_bCanHit)
            {
                var coliders = Physics2D.OverlapBoxAll(m_tk2DSprite.GetBounds().center + m_effectObj.transform.position, m_tk2DSprite.GetBounds().extents, 0);
                for (int i = 0; i < coliders.Length; i++)
                {
                    int transId = coliders[i].transform.parent.parent.GetInstanceID();

                    Actor actor;
                    CharacterManager.Instance.m_dicActors.TryGetValue(transId, out actor);
                    if (actor != null && actor is Hero == false)
                    {
                        actor.BeHit(m_owner);
                        m_bCanHit = false;
                        //m_hitCount++;
                        if (m_skillEffectData.AutoDestory == 1)
                            m_effectObj.SetActive(false);
                    }
                }
            }
        }

        if (m_skillEffectData.LifeTime != 0 && m_showTimeSave != -1 && Time.time - m_showTimeSave > m_skillEffectData.LifeTime)
        {
            m_effectObj.SetActive(false);
        }    
    }

    public void Release()
    {

    }
}
