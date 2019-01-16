using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Config;

public abstract class BaseBattleState : BaseState
{
    protected float m_fAttackMoveSpeed = 0;
    protected float m_fAttackMoveFriction = 0;

    private ProfessionSkillLoader.Data m_professionSkillLoaderData;
    protected SkillLoader.Data m_skillData;
    protected uint m_nSkillId;
    protected ESkillType m_eSkillType;

    private List<uint> m_lstSkillEffectId;
    private bool m_bCanHit;
    private bool m_bCanCreateEffect;
    public BaseBattleState(Actor actor, EActionState eState) : base(actor, eState)
    {
       
    }

    public override void EnterState(EActionState eLastState)
    {
        base.EnterState(eLastState);
        GetSkillData();
        m_eSkillType = ConfigManager.Instance.GetLoader<SkillLoader>().GetSKillType(m_nSkillId);

        m_fAttackMoveSpeed = m_skillData.MoveSpeed;
        m_fAttackMoveFriction = m_skillData.MoveFriction;

        m_owner.CanMove = false;
        m_owner.CanJump = false;
        m_owner.CanAttack = false;
        m_owner.CanSkill = false;

        m_inputAbility.MoveX(0);

        //播放动画
        m_tk2DSpriteAnimator.Play(m_skillData.ActionName);
        //暂时设定在Update中只造成一次伤害
        m_bCanHit = true;
        m_bCanCreateEffect = true;
        m_lstSkillEffectId = ConfigManager.Instance.GetLoader<SkillLoader>().GetSkillEffectIdList(m_nSkillId);
    }

    public override void OnUpdate()
    {
        base.OnUpdate();

        //连招检测
        if (m_skillData.NextActionName != "0")
        {
            if (m_tk2DSpriteAnimator.CurrentFrame >= m_skillData.EarlyEndFramIndex)
            {
                if (m_owner is Hero)
                {
                    if (Input.GetKey(KeyCode.X))
                        m_stateManager.EnterState(m_skillData.NextActionName);
                }
                else
                    m_stateManager.EnterState(m_skillData.NextActionName);
            }
        }
        //碰撞检测
        if (m_tk2DSpriteAnimator.CurrentFrame == m_skillData.AttackFramIndex && m_bCanHit && m_eSkillType == ESkillType.WeaponType)
        {
            var coliders = Physics2D.OverlapBoxAll(m_owner.m_attackBounds.center, m_owner.m_attackBounds.extents, 0);
            for (int i = 0; i < coliders.Length; i++)
            {
                int transId = coliders[i].transform.parent.parent.GetInstanceID();

                Actor actor;
                CharacterManager.Instance.m_dicActors.TryGetValue(transId, out actor);
                if (actor != null && actor is Hero == false)
                {
                    actor.BeHit(m_owner);
                }
            }

            m_bCanHit = false;
        }
        //创建技能特效
        if (m_lstSkillEffectId != null && m_lstSkillEffectId.Count > 0 && m_skillData.CreateSkillEffectFrame != 0 && m_bCanCreateEffect && m_eSkillType == ESkillType.EffectType)
        {
            if (m_tk2DSpriteAnimator.CurrentSpriteId == m_skillData.CreateSkillEffectFrame)
            {
                for (int i = 0; i < m_lstSkillEffectId.Count; i++)
                {
                    SkillEffectManager.Instance.CreatSkillEffect(m_lstSkillEffectId[i], m_owner);
                }
                m_bCanCreateEffect = false;
            }
        }
    }

    public override void BreakState(EActionState eNextState)
    {
        base.BreakState(eNextState);
        m_bCanHit = false;
    }

    public override void Reset()
    {
        base.Reset();
    }
    public override void OnFixedUpdate()
    {
        base.OnFixedUpdate();

        //动作位移
        if (m_fAttackMoveSpeed != 0 && m_fAttackMoveFriction != 0)
        {
            m_fAttackMoveSpeed = Mathf.Lerp(m_fAttackMoveSpeed, 0, Time.deltaTime * m_fAttackMoveFriction);
            m_inputAbility.MoveX(m_fAttackMoveSpeed);
        }
    }

    public override void Release()
    {
        base.Release();
    }

    public override void OnAnimationComplete(tk2dSpriteAnimator animator, tk2dSpriteAnimationClip animationClip)
    {
        base.OnAnimationComplete(animator, animationClip);

        if (animationClip.name == m_skillData.ActionName)
        {
            m_stateManager.EnterState(EActionState.Idle);
        }
    }

    private void GetSkillData()
    {
        if (m_professionSkillLoaderData == null)
            m_professionSkillLoaderData = ConfigManager.Instance.GetData<ProfessionSkillLoader, ProfessionSkillLoader.Data>(m_owner.SkillConfigId);

        uint skillId = 0;
        GetSkillIdByState(m_eState, out skillId);

        if (skillId != 0 && m_skillData == null)
        {
            m_skillData = ConfigManager.Instance.GetData<SkillLoader, SkillLoader.Data>(skillId);
            m_nSkillId = skillId;
        } 
    }

    private void GetSkillIdByState(EActionState eState, out uint skillId)
    {
        if (eState == EActionState.Attack1)
            skillId = m_professionSkillLoaderData.Attack1Id;
        else if (eState == EActionState.Attack2)
            skillId = m_professionSkillLoaderData.Attack2Id;
        else if (eState == EActionState.Attack3)
            skillId = m_professionSkillLoaderData.Attack3Id;
        else if (eState == EActionState.Attack4)
            skillId = m_professionSkillLoaderData.Attack4Id;
        else if (eState == EActionState.Skill1)
            skillId = m_professionSkillLoaderData.Skill1Id;
        else if (eState == EActionState.Skill2)
            skillId = m_professionSkillLoaderData.Skill2Id;
        else if (eState == EActionState.Skill3)
            skillId = m_professionSkillLoaderData.Skill3Id;
        else if (eState == EActionState.Skill4)
            skillId = m_professionSkillLoaderData.Skill4Id;
        else if (eState == EActionState.Skill5)
            skillId = m_professionSkillLoaderData.Skill5Id;
        else if (eState == EActionState.Skill6)
            skillId = m_professionSkillLoaderData.Skill6Id;
        else if (eState == EActionState.Skill7)
            skillId = m_professionSkillLoaderData.Skill7Id;
        else if (eState == EActionState.Skill8)
            skillId = m_professionSkillLoaderData.Skill8Id;
        else if (eState == EActionState.Skill9)
            skillId = m_professionSkillLoaderData.Skill9Id;
        else if (eState == EActionState.RunAttack)
            skillId = m_professionSkillLoaderData.RunAttackId;
        else if (eState == EActionState.JumpAttack)
            skillId = m_professionSkillLoaderData.JumpAttackId;
        else
            skillId = 0;
    }

    //创建技能特效
    public void CreatSkillEffect(uint effectId)
    {
        //Id--特效动画名字--创建特效物体对象--播放相应的动画
        //Id--特效数量、起始点、速度、存在时间、碰撞检测、
    }
}
