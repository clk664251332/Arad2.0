using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Config;

public class AnimationAbility : BaseAbility
{
    private tk2dSprite m_weaponSprite;
    private tk2dSpriteAnimator m_tk2dSpriteAnimator;
    public Transform m_animationTrans;

    private List<tk2dSprite> m_lstPartSprite = new List<tk2dSprite>();
    private Dictionary<EPartType, tk2dSprite> m_dicTypeWithSprite = new Dictionary<EPartType, tk2dSprite>();

    private uint fashionId = 1001;
    public tk2dSpriteAnimator GetTk2dSpriteAnimator()
    {
        return m_tk2dSpriteAnimator;
    }

    public override void Initialize()
    {
        base.Initialize();

        var playerData = ConfigManager.Instance.GetData<ProfessionLoader, ProfessionLoader.Data>(m_owner.Id);
        string animatorName = playerData.AnimatorName;

        GameObject loadGameObject = Resources.Load<GameObject>("Animator/" + animatorName);
        if (loadGameObject == null)
        {
            Debug.LogError("未找到资源!");
            return;
        }
        var go = GameObject.Instantiate<GameObject>(loadGameObject);
        go.transform.position = Vector3.zero;
        go.transform.parent = m_owner.Transform;
        go.name = "AnimationAbility";
        m_animationTrans = go.transform;

        m_tk2dSpriteAnimator = go.GetComponent<tk2dSpriteAnimator>();

        var fashionData = ConfigManager.Instance.GetData<FashionLoader, FashionLoader.Data>(m_owner.FashionConfigId);
        InitPart(fashionData);
    }

    public override void GetComponent()
    {
        base.GetComponent();
    }

    public override void Update()
    {
        base.Update();
        SetSpriteFlip();
        UpdatePartSprite();
        if (Input.GetKeyDown(KeyCode.L))
        {
            //ChangePart(0, EPartType.Coat_a);
            //ChangePart(0, EPartType.Coat_b);
            //ChangePart(0, EPartType.Coat_c);
            //ChangePart(0, EPartType.Coat_d);
            if (fashionId == 1001)
            {
                ChangeFashion(1002);
                fashionId = 1002;
            }else if(fashionId == 1002)
            {
                ChangeFashion(1001);
                fashionId = 1001;
            }
        }
    }

    private void SetSpriteFlip()
    {
        if (m_owner.Direction == 1)
        {
            for (int i = 0; i < m_lstPartSprite.Count; i++)
            {
                m_lstPartSprite[i].FlipX = false;
            }
        }
        else
        {
            for (int i = 0; i < m_lstPartSprite.Count; i++)
            {
                m_lstPartSprite[i].FlipX = true;
            }
        }
    }
    /// <summary>
    /// 排序skin-0/coat-1/chest-2//hair-5/cap-6/pant-7/shoes-8/belt-9/weaponPart1-3/weaponPart2-4
    /// </summary>
    /// <param name="fashionData"></param>
    private void InitPart(FashionLoader.Data fashionData)
    {
        if (fashionData.Body != 0)
        {
            CreatPart(fashionData.Body, EPartType.Body, 0);
        }

        if (fashionData.Coat_a != 0)
        {
            CreatPart(fashionData.Coat_a, EPartType.Coat_a, 1);
        }

        if (fashionData.Coat_b != 0)
        {
            CreatPart(fashionData.Coat_b, EPartType.Coat_b, 1);
        }

        if (fashionData.Coat_c != 0)
        {
            CreatPart(fashionData.Coat_c, EPartType.Coat_c, 1);
        }

        if (fashionData.Coat_d != 0)
        {
            CreatPart(fashionData.Coat_d, EPartType.Coat_d, 1);
        }

        if (fashionData.Neck_c != 0)
        {
            CreatPart(fashionData.Neck_c, EPartType.Neck_c, 1);
        }

        if (fashionData.Neck_d != 0)
        {
            CreatPart(fashionData.Neck_d, EPartType.Neck_d, 1);
        }

        if (fashionData.Neck_x != 0)
        {
            CreatPart(fashionData.Neck_x, EPartType.Neck_x, 1);
        }

        if (fashionData.Hair_a != 0)
        {
            CreatPart(fashionData.Hair_a, EPartType.Hair_a, 1);
        }

        if (fashionData.Hair_b != 0)
        {
            CreatPart(fashionData.Hair_b, EPartType.Hair_b, 1);
        }

        if (fashionData.Cap_a != 0)
        {
            CreatPart(fashionData.Cap_a, EPartType.Cap_a, 2);
        }

        if (fashionData.Cap_b != 0)
        {
            CreatPart(fashionData.Cap_b, EPartType.Cap_b, 2);
        }

        if (fashionData.Pants_a != 0)
        {
            CreatPart(fashionData.Pants_a, EPartType.Pants_a, 2);
        }

        if (fashionData.Pants_b != 0)
        {
            CreatPart(fashionData.Pants_b, EPartType.Pants_b, 2);
        }

        if (fashionData.Pants_c != 0)
        {
            CreatPart(fashionData.Pants_c, EPartType.Pants_c, 2);
        }

        if (fashionData.Pants_d != 0)
        {
            CreatPart(fashionData.Pants_d, EPartType.Pants_d, 2);
        }

        if (fashionData.Shoes_a != 0)
        {
            CreatPart(fashionData.Shoes_a, EPartType.Shoes_a, 2);
        }

        if (fashionData.Shoes_b != 0)
        {
            CreatPart(fashionData.Shoes_b, EPartType.Shoes_b, 2);
        }

        if (fashionData.Belt_a != 0)
        {
            CreatPart(fashionData.Belt_a, EPartType.Belt_a, 2);
        }
        if (fashionData.Belt_b != 0)
        {
            CreatPart(fashionData.Belt_b, EPartType.Belt_b, 2);
        }

        if (fashionData.Belt_c != 0)
        {
            CreatPart(fashionData.Belt_c, EPartType.Belt_c, 2);
        }

        if (fashionData.Belt_d != 0)
        {
            CreatPart(fashionData.Belt_d, EPartType.Belt_d, 2);
        }

        if (fashionData.Weapon_a != 0)
        {
            m_weaponSprite = CreatPart(fashionData.Weapon_a, EPartType.Weapon_a, 2);
        }

        if (fashionData.Weapon_b != 0)
        {
            m_weaponSprite = CreatPart(fashionData.Weapon_b, EPartType.Weapon_b, 2);
        }

        if (fashionData.Weapon_c != 0)
        {
            CreatPart(fashionData.Weapon_c, EPartType.Weapon_c, 2);
        }

        if (fashionData.Weapon_d != 0)
        {
            CreatPart(fashionData.Weapon_d, EPartType.Weapon_d, 2);
        }

        if (fashionData.Subweapon_a != 0)
        {
            CreatPart(fashionData.Subweapon_a, EPartType.Subweapon_a, 2);
        }

        if (fashionData.Subweapon_b != 0)
        {
            CreatPart(fashionData.Subweapon_b, EPartType.Subweapon_b, 2);
        }

        if (fashionData.Subweapon_c != 0)
        {
            CreatPart(fashionData.Subweapon_c, EPartType.Subweapon_c, 2);
        }

        if (fashionData.Subweapon_d != 0)
        {
            CreatPart(fashionData.Subweapon_d, EPartType.Subweapon_d, 2);
        }

        GameObject effectObj = new GameObject("Effect");
        effectObj.transform.parent = m_animationTrans;
    }

    private void ChangePart(uint partId, EPartType ePartType)
    {
        tk2dSprite partSprite;
        if (m_dicTypeWithSprite.TryGetValue(ePartType, out partSprite))
        {
            if (partId == 0)
            {
                partSprite.gameObject.SetActive(false);
            }
            else
            {
                var partData = ConfigManager.Instance.GetData<PartLoader, PartLoader.Data>(partId);
                tk2dSpriteCollectionData tk2DSpriteCollectionData = tk2dSystem.LoadResourceByName<tk2dSpriteCollectionData>(partData.CollectionName);
                partSprite.gameObject.SetActive(true);
                partSprite.SetSprite(tk2DSpriteCollectionData, 0);
            }
        }
        else
        {
            if (partId != 0)
            {
                int sortLevel = 0;
                if (1 <= (int)ePartType && (int)ePartType <= 9)
                    sortLevel = 1;
                else if (ePartType == 0)
                    sortLevel = 0;
                else
                    sortLevel = 2;

                CreatPart(partId, ePartType, sortLevel);
            }
        }
    }

    private void ChangeFashion(uint fashionId)
    {
        var fashionData = ConfigManager.Instance.GetData<FashionLoader, FashionLoader.Data>(fashionId);
        ChangePart(fashionData.Body, EPartType.Body);
        ChangePart(fashionData.Belt_a, EPartType.Belt_a);
        ChangePart(fashionData.Belt_b, EPartType.Belt_b);
        ChangePart(fashionData.Belt_c, EPartType.Belt_c);
        ChangePart(fashionData.Belt_d, EPartType.Belt_d);
        ChangePart(fashionData.Cap_a, EPartType.Cap_a);
        ChangePart(fashionData.Cap_b, EPartType.Cap_b);
        ChangePart(fashionData.Coat_a, EPartType.Coat_a);
        ChangePart(fashionData.Coat_b, EPartType.Coat_b);
        ChangePart(fashionData.Coat_c, EPartType.Coat_c);
        ChangePart(fashionData.Coat_d, EPartType.Coat_d);
        ChangePart(fashionData.Face_b, EPartType.Face_b);
        ChangePart(fashionData.Face_c, EPartType.Face_c);
        ChangePart(fashionData.Hair_a, EPartType.Hair_a);
        ChangePart(fashionData.Hair_b, EPartType.Hair_b);
        ChangePart(fashionData.Neck_c, EPartType.Neck_c);
        ChangePart(fashionData.Neck_d, EPartType.Neck_d);
        ChangePart(fashionData.Neck_x, EPartType.Neck_x);
        ChangePart(fashionData.Pants_a, EPartType.Pants_a);
        ChangePart(fashionData.Pants_b, EPartType.Pants_b);
        ChangePart(fashionData.Pants_c, EPartType.Pants_c);
        ChangePart(fashionData.Pants_d, EPartType.Pants_d);
        ChangePart(fashionData.Shoes_a, EPartType.Shoes_a);
        ChangePart(fashionData.Shoes_b, EPartType.Shoes_b);
        ChangePart(fashionData.Subweapon_a, EPartType.Subweapon_a);
        ChangePart(fashionData.Subweapon_b, EPartType.Subweapon_b);
        ChangePart(fashionData.Subweapon_c, EPartType.Subweapon_c);
        ChangePart(fashionData.Subweapon_d, EPartType.Subweapon_d);
        ChangePart(fashionData.Subweapon_x, EPartType.Subweapon_x);
        ChangePart(fashionData.Weapon_a, EPartType.Weapon_a);
        ChangePart(fashionData.Weapon_b, EPartType.Weapon_b);
        ChangePart(fashionData.Weapon_c, EPartType.Weapon_c);
        ChangePart(fashionData.Weapon_d, EPartType.Weapon_d);
        ChangePart(fashionData.Weapon_x, EPartType.Weapon_x);
    }

    private tk2dSprite CreatPart(uint partId, EPartType ePartType, int sortLevel)
    {
        if (partId == 0) return null;
        var partData = ConfigManager.Instance.GetData<PartLoader, PartLoader.Data>(partId);

        GameObject partObj = new GameObject(ePartType.ToString());
        partObj.transform.parent = m_animationTrans;
        partObj.transform.position = Vector3.zero;

        var partSprite = Common.GetOrAddComponent<tk2dSprite>(partObj);
        tk2dSpriteCollectionData tk2DSpriteCollectionData = tk2dSystem.LoadResourceByName<tk2dSpriteCollectionData>(partData.CollectionName);
        partSprite.SetSprite(tk2DSpriteCollectionData, 0);
        partSprite.SortingLevel = sortLevel;

        m_lstPartSprite.Add(partSprite);
        m_dicTypeWithSprite.Add(ePartType, partSprite);
        return partSprite;
    }

    private void UpdatePartSprite()
    {
        for (int i = 0; i < m_lstPartSprite.Count; i++)
        {
            m_lstPartSprite[i].SetSprite(m_tk2dSpriteAnimator.CurrentSpriteId);

            m_lstPartSprite[i].SortingOrder = 600 - (int)m_owner.Transform.position.y + m_lstPartSprite[i].SortingLevel;

            var bounds = m_weaponSprite.GetBounds();
            Bounds newbounds = new Bounds(bounds.center + m_owner.Transform.position, bounds.extents * 4);
            m_owner.m_attackBounds = newbounds;
        }
    }

    public override void Release()
    {
        base.Release();
        //foreach(var sprite in m_lstPartSprite)
        //{
        //    sprite = null;
        //}
        GameObject.Destroy(m_animationTrans.gameObject);
    }
}
