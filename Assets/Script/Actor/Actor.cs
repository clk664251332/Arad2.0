using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actor : Entity
{
    private Transform m_transform = null;
    private Vector3 m_position = Vector3.zero;
    protected AbilityManager m_AbilityManager;
    protected BaseStateManager m_stateMgr;
    public ActorEventHandler m_actorEventHandler;
    private int m_direction = 1;
    private uint m_fashionConfigId;
    private uint m_skillConfigId;
    private uint m_attrConfigId;

    private bool m_bCanMove;
    private bool m_bCanJump;
    private bool m_bCanAttack;
    private bool m_bCanSkill;
    private bool m_bCanJumpAttack;

    private bool m_bIsRun = false;
    private bool m_bIsJump = false;

    public Bounds m_attackBounds;
    public bool CanMove
    {
        get
        {
            return m_bCanMove;
        }

        set
        {
            m_bCanMove = value;
        }
    }

    public bool CanJump
    {
        get
        {
            return m_bCanJump;
        }

        set
        {
            m_bCanJump = value;
        }
    }

    public bool CanAttack
    {
        get
        {
            return m_bCanAttack;
        }

        set
        {
            m_bCanAttack = value;
        }
    }

    public bool CanSkill
    {
        get
        {
            return m_bCanSkill;
        }

        set
        {
            m_bCanSkill = value;
        }
    }

    public bool IsRun
    {
        get
        {
            return m_bIsRun;
        }

        set
        {
            m_bIsRun = value;
        }
    }

    public bool IsJump
    {
        get
        {
            return m_bIsJump;
        }

        set
        {
            m_bIsJump = value;
        }
    }

    public Actor() : base()
    {
        //对象的创建要放在构造函数中去
        m_AbilityManager = new AbilityManager();
        //Ability对象也在构造函数中创建
        AddAbility();
        m_actorEventHandler = new ActorEventHandler();
    }

    public Vector3 Position
    {
        get
        {
            return m_position;
        }

        set
        {
            m_position = value;
        }
    }

    public Transform Transform
    {
        get
        {
            return m_transform;
        }

        set
        {
            m_transform = value;
        }
    }

    public int Direction
    {
        get
        {
            return m_direction;
        }

        set
        {
            m_direction = value;
        }
    }

    public uint FashionConfigId
    {
        get
        {
            return m_fashionConfigId;
        }

        set
        {
            m_fashionConfigId = value;
        }
    }

    public uint SkillConfigId
    {
        get
        {
            return m_skillConfigId;
        }

        set
        {
            m_skillConfigId = value;
        }
    }

    public uint AttrConfigId
    {
        get
        {
            return m_attrConfigId;
        }

        set
        {
            m_attrConfigId = value;
        }
    }

    public bool CanJumpAttack
    {
        get
        {
            return m_bCanJumpAttack;
        }

        set
        {
            m_bCanJumpAttack = value;
        }
    }


    /// <summary>
    /// 在场景中创建游戏对象，并把物体放到合适的位置
    /// </summary>
    protected void InitModel()
    {
        GameObject gameObject;

        if (m_transform == null)
        {
            gameObject = new GameObject();
            m_transform = gameObject.transform;
        }

        gameObject = m_transform.gameObject;
        gameObject.SetActive(true);
        gameObject.transform.position = Position;
        gameObject.name = Name;

        GameObject objGroup = GameObjectGroupHandler.GetActorDetailGroup(GetType());
        if (objGroup != null)
        {
            m_transform.parent = objGroup.transform;
        }

        CharacterManager.Instance.m_dicActors.Add(m_transform.GetInstanceID(), this);
    }

    public virtual void AddAbility()
    {
        m_AbilityManager.AddAbility<AttrAbility>(this);
        m_AbilityManager.AddAbility<AnimationAbility>(this);
        m_AbilityManager.AddAbility<SoundAbility>(this);
    }

    public AbilityManager GetAbilityManager()
    {
        return m_AbilityManager;
    }

    public T GetAbility<T>() where T : BaseAbility
    {
        if (m_AbilityManager != null)
        {
            return m_AbilityManager.GetAbility<T>();
        }

        return null;
    }

    public override void Initialize()
    {
        base.Initialize();
        InitModel();
        //必须先把物体创建出来，ability才能在物体上面创建组件
        m_AbilityManager.Initialize();
        m_AbilityManager.GetComponent();
    }

    public override void Update()
    {
        base.Update();
        m_AbilityManager.Update();
    }

    public override void Release()
    {
        base.Release();
        m_AbilityManager.Release();
    }

    public GameObject GetObject()
    {
        if (m_transform != null)
        {
            return m_transform.gameObject;
        }

        return null;
    }

    public void SendEvent(EEventType eEventType)
    {
        if (m_actorEventHandler != null)
            m_actorEventHandler.SendEvent(eEventType);
    }

    public AttrValue GetAttr(EActorAttr eActorAttr)
    {
        AttrAbility attrAbility = GetAbility<AttrAbility>();
        return attrAbility.GetAttr(eActorAttr);
    }

    public BaseStateManager GetStateMgr()
    {
        return m_stateMgr;
    }

    public void BeHit(Actor attackActor)
    {
        m_stateMgr.EnterState(EActionState.Behit);
    }

    public override string ToString()
    {
        return Name +":";
    }
}
