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
        InitPart(fashionData, go.transform);
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
    }

    private void SetSpriteFlip()
    {
        if (m_owner.Direction == 1)
        {
            for(int i=0;i< m_lstPartSprite.Count; i++)
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
    /// <param name="rootTrans"></param>
    private void InitPart(FashionLoader.Data fashionData, Transform rootTrans)
    {
        if (fashionData.Body != 0)
        {
            var partData = ConfigManager.Instance.GetData<PartLoader, PartLoader.Data>(fashionData.Body);

            GameObject skinObj = new GameObject("Body");
            skinObj.transform.parent = rootTrans;

            var skinSprite = Common.GetOrAddComponent<tk2dSprite>(skinObj);
            tk2dSpriteCollectionData tk2DSpriteCollectionData = tk2dSystem.LoadResourceByName<tk2dSpriteCollectionData>(partData.CollectionName);
            skinSprite.SetSprite(tk2DSpriteCollectionData, 0);
            //skinSprite.SortingOrder = 0;
            skinSprite.SortingLevel = 0;

            m_lstPartSprite.Add(skinSprite);
        }

        if (fashionData.Coat_a != 0)
        {
            var partData = ConfigManager.Instance.GetData<PartLoader, PartLoader.Data>(fashionData.Coat_a);

            GameObject coat_aObj = new GameObject("Coat_a");
            coat_aObj.transform.parent = rootTrans;

            var coat_aSprite = Common.GetOrAddComponent<tk2dSprite>(coat_aObj);
            tk2dSpriteCollectionData tk2DSpriteCollectionData = tk2dSystem.LoadResourceByName<tk2dSpriteCollectionData>(partData.CollectionName);
            coat_aSprite.SetSprite(tk2DSpriteCollectionData, 0);
            //coat_1Sprite.SortingOrder = 1;
            coat_aSprite.SortingLevel = 1;

            m_lstPartSprite.Add(coat_aSprite);
        }

        if (fashionData.Coat_b != 0)
        {
            var partData = ConfigManager.Instance.GetData<PartLoader, PartLoader.Data>(fashionData.Coat_b);

            GameObject coat_2Obj = new GameObject("Coat_b");
            coat_2Obj.transform.parent = rootTrans;

            var coat_2Sprite = Common.GetOrAddComponent<tk2dSprite>(coat_2Obj);
            tk2dSpriteCollectionData tk2DSpriteCollectionData = tk2dSystem.LoadResourceByName<tk2dSpriteCollectionData>(partData.CollectionName);
            coat_2Sprite.SetSprite(tk2DSpriteCollectionData, 0);
            //coat_2Sprite.SortingOrder = 1;
            coat_2Sprite.SortingLevel = 1;

            m_lstPartSprite.Add(coat_2Sprite);
        }

        if (fashionData.Coat_c != 0)
        {
            var partData = ConfigManager.Instance.GetData<PartLoader, PartLoader.Data>(fashionData.Coat_c);

            GameObject coat_2Obj = new GameObject("Coat_c");
            coat_2Obj.transform.parent = rootTrans;

            var coat_2Sprite = Common.GetOrAddComponent<tk2dSprite>(coat_2Obj);
            tk2dSpriteCollectionData tk2DSpriteCollectionData = tk2dSystem.LoadResourceByName<tk2dSpriteCollectionData>(partData.CollectionName);
            coat_2Sprite.SetSprite(tk2DSpriteCollectionData, 0);
            //coat_2Sprite.SortingOrder = 1;
            coat_2Sprite.SortingLevel = 1;

            m_lstPartSprite.Add(coat_2Sprite);
        }
        if (fashionData.Coat_b != 0)
        {
            var partData = ConfigManager.Instance.GetData<PartLoader, PartLoader.Data>(fashionData.Coat_b);

            GameObject coat_2Obj = new GameObject("Coat_b");
            coat_2Obj.transform.parent = rootTrans;

            var coat_2Sprite = Common.GetOrAddComponent<tk2dSprite>(coat_2Obj);
            tk2dSpriteCollectionData tk2DSpriteCollectionData = tk2dSystem.LoadResourceByName<tk2dSpriteCollectionData>(partData.CollectionName);
            coat_2Sprite.SetSprite(tk2DSpriteCollectionData, 0);
            //coat_2Sprite.SortingOrder = 1;
            coat_2Sprite.SortingLevel = 1;

            m_lstPartSprite.Add(coat_2Sprite);
        }
        if (fashionData.Neck_c != 0)
        {
            var partData = ConfigManager.Instance.GetData<PartLoader, PartLoader.Data>(fashionData.Neck_c);

            GameObject chestObj = new GameObject("Neck_c");
            chestObj.transform.parent = rootTrans;

            var chestSprite = Common.GetOrAddComponent<tk2dSprite>(chestObj);
            tk2dSpriteCollectionData tk2DSpriteCollectionData = tk2dSystem.LoadResourceByName<tk2dSpriteCollectionData>(partData.CollectionName);
            chestSprite.SetSprite(tk2DSpriteCollectionData, 0);
            //chestSprite.SortingOrder = 2;
            chestSprite.SortingLevel = 1;

            m_lstPartSprite.Add(chestSprite);
        }
        if (fashionData.Neck_d != 0)
        {
            var partData = ConfigManager.Instance.GetData<PartLoader, PartLoader.Data>(fashionData.Neck_d);

            GameObject chestObj = new GameObject("Neck_d");
            chestObj.transform.parent = rootTrans;

            var chestSprite = Common.GetOrAddComponent<tk2dSprite>(chestObj);
            tk2dSpriteCollectionData tk2DSpriteCollectionData = tk2dSystem.LoadResourceByName<tk2dSpriteCollectionData>(partData.CollectionName);
            chestSprite.SetSprite(tk2DSpriteCollectionData, 0);
            //chestSprite.SortingOrder = 2;
            chestSprite.SortingLevel = 1;

            m_lstPartSprite.Add(chestSprite);
        }
        if (fashionData.Neck_x != 0)
        {
            var partData = ConfigManager.Instance.GetData<PartLoader, PartLoader.Data>(fashionData.Neck_x);

            GameObject chestObj = new GameObject("Neck_x");
            chestObj.transform.parent = rootTrans;

            var chestSprite = Common.GetOrAddComponent<tk2dSprite>(chestObj);
            tk2dSpriteCollectionData tk2DSpriteCollectionData = tk2dSystem.LoadResourceByName<tk2dSpriteCollectionData>(partData.CollectionName);
            chestSprite.SetSprite(tk2DSpriteCollectionData, 0);
            //chestSprite.SortingOrder = 2;
            chestSprite.SortingLevel = 1;

            m_lstPartSprite.Add(chestSprite);
        }
        if (fashionData.Hair_a != 0)
        {
            var partData = ConfigManager.Instance.GetData<PartLoader, PartLoader.Data>(fashionData.Hair_a);

            GameObject hairObj = new GameObject("Hair_a");
            hairObj.transform.parent = rootTrans;

            var hairSprite = Common.GetOrAddComponent<tk2dSprite>(hairObj);
            tk2dSpriteCollectionData tk2DSpriteCollectionData = tk2dSystem.LoadResourceByName<tk2dSpriteCollectionData>(partData.CollectionName);
            hairSprite.SetSprite(tk2DSpriteCollectionData, 0);
            //hairSprite.SortingOrder = 3;
            hairSprite.SortingLevel = 1;

            m_lstPartSprite.Add(hairSprite);
        }
        if (fashionData.Hair_b != 0)
        {
            var partData = ConfigManager.Instance.GetData<PartLoader, PartLoader.Data>(fashionData.Hair_b);

            GameObject hairObj = new GameObject("Hair_b");
            hairObj.transform.parent = rootTrans;

            var hairSprite = Common.GetOrAddComponent<tk2dSprite>(hairObj);
            tk2dSpriteCollectionData tk2DSpriteCollectionData = tk2dSystem.LoadResourceByName<tk2dSpriteCollectionData>(partData.CollectionName);
            hairSprite.SetSprite(tk2DSpriteCollectionData, 0);
            //hairSprite.SortingOrder = 3;
            hairSprite.SortingLevel = 1;

            m_lstPartSprite.Add(hairSprite);
        }
        if (fashionData.Cap_a != 0)
        {
            var partData = ConfigManager.Instance.GetData<PartLoader, PartLoader.Data>(fashionData.Cap_a);

            GameObject capObj = new GameObject("Cap_a");
            capObj.transform.parent = rootTrans;

            var capSprite = Common.GetOrAddComponent<tk2dSprite>(capObj);
            tk2dSpriteCollectionData tk2DSpriteCollectionData = tk2dSystem.LoadResourceByName<tk2dSpriteCollectionData>(partData.CollectionName);
            capSprite.SetSprite(tk2DSpriteCollectionData, 0);
            //capSprite.SortingOrder = 4;
            capSprite.SortingLevel = 2;

            m_lstPartSprite.Add(capSprite);
        }

        if (fashionData.Cap_b != 0)
        {
            var partData = ConfigManager.Instance.GetData<PartLoader, PartLoader.Data>(fashionData.Cap_b);

            GameObject capObj = new GameObject("Cap_b");
            capObj.transform.parent = rootTrans;

            var capSprite = Common.GetOrAddComponent<tk2dSprite>(capObj);
            tk2dSpriteCollectionData tk2DSpriteCollectionData = tk2dSystem.LoadResourceByName<tk2dSpriteCollectionData>(partData.CollectionName);
            capSprite.SetSprite(tk2DSpriteCollectionData, 0);
            //capSprite.SortingOrder = 4;
            capSprite.SortingLevel = 2;

            m_lstPartSprite.Add(capSprite);
        }

        if (fashionData.Pants_a != 0)
        {
            var partData = ConfigManager.Instance.GetData<PartLoader, PartLoader.Data>(fashionData.Pants_a);

            GameObject pant_1Obj = new GameObject("Pants_a");
            pant_1Obj.transform.parent = rootTrans;

            var pant_1Sprite = Common.GetOrAddComponent<tk2dSprite>(pant_1Obj);
            tk2dSpriteCollectionData tk2DSpriteCollectionData = tk2dSystem.LoadResourceByName<tk2dSpriteCollectionData>(partData.CollectionName);
            pant_1Sprite.SetSprite(tk2DSpriteCollectionData, 0);
            //pant_1Sprite.SortingOrder = 5;
            pant_1Sprite.SortingLevel = 1;

            m_lstPartSprite.Add(pant_1Sprite);
        }
        if (fashionData.Pants_b != 0)
        {
            var partData = ConfigManager.Instance.GetData<PartLoader, PartLoader.Data>(fashionData.Pants_b);

            GameObject pant_1Obj = new GameObject("Pants_b");
            pant_1Obj.transform.parent = rootTrans;

            var pant_1Sprite = Common.GetOrAddComponent<tk2dSprite>(pant_1Obj);
            tk2dSpriteCollectionData tk2DSpriteCollectionData = tk2dSystem.LoadResourceByName<tk2dSpriteCollectionData>(partData.CollectionName);
            pant_1Sprite.SetSprite(tk2DSpriteCollectionData, 0);
            //pant_1Sprite.SortingOrder = 5;
            pant_1Sprite.SortingLevel = 1;

            m_lstPartSprite.Add(pant_1Sprite);
        }
        if (fashionData.Pants_c != 0)
        {
            var partData = ConfigManager.Instance.GetData<PartLoader, PartLoader.Data>(fashionData.Pants_c);

            GameObject pant_1Obj = new GameObject("Pants_c");
            pant_1Obj.transform.parent = rootTrans;

            var pant_1Sprite = Common.GetOrAddComponent<tk2dSprite>(pant_1Obj);
            tk2dSpriteCollectionData tk2DSpriteCollectionData = tk2dSystem.LoadResourceByName<tk2dSpriteCollectionData>(partData.CollectionName);
            pant_1Sprite.SetSprite(tk2DSpriteCollectionData, 0);
            //pant_1Sprite.SortingOrder = 5;
            pant_1Sprite.SortingLevel = 1;

            m_lstPartSprite.Add(pant_1Sprite);
        }
        if (fashionData.Pants_d != 0)
        {
            var partData = ConfigManager.Instance.GetData<PartLoader, PartLoader.Data>(fashionData.Pants_d);

            GameObject pant_2Obj = new GameObject("Pants_d");
            pant_2Obj.transform.parent = rootTrans;

            var pant_2Sprite = Common.GetOrAddComponent<tk2dSprite>(pant_2Obj);
            tk2dSpriteCollectionData tk2DSpriteCollectionData = tk2dSystem.LoadResourceByName<tk2dSpriteCollectionData>(partData.CollectionName);
            pant_2Sprite.SetSprite(tk2DSpriteCollectionData, 0);
            //pant_2Sprite.SortingOrder = 5;
            pant_2Sprite.SortingLevel = 1;

            m_lstPartSprite.Add(pant_2Sprite);
        }

        if (fashionData.Shoes_a != 0)
        {
            var partData = ConfigManager.Instance.GetData<PartLoader, PartLoader.Data>(fashionData.Shoes_a);

            GameObject shoes_1Obj = new GameObject("Shoes_a");
            shoes_1Obj.transform.parent = rootTrans;

            var shoes_1Sprite = Common.GetOrAddComponent<tk2dSprite>(shoes_1Obj);
            tk2dSpriteCollectionData tk2DSpriteCollectionData = tk2dSystem.LoadResourceByName<tk2dSpriteCollectionData>(partData.CollectionName);
            shoes_1Sprite.SetSprite(tk2DSpriteCollectionData, 0);
            //shoes_1Sprite.SortingOrder = 6;
            shoes_1Sprite.SortingLevel = 1;

            m_lstPartSprite.Add(shoes_1Sprite);
        }

        if (fashionData.Shoes_b != 0)
        {
            var partData = ConfigManager.Instance.GetData<PartLoader, PartLoader.Data>(fashionData.Shoes_b);

            GameObject shoes_2Obj = new GameObject("Shoes_b");
            shoes_2Obj.transform.parent = rootTrans;

            var shoes_2Sprite = Common.GetOrAddComponent<tk2dSprite>(shoes_2Obj);
            tk2dSpriteCollectionData tk2DSpriteCollectionData = tk2dSystem.LoadResourceByName<tk2dSpriteCollectionData>(partData.CollectionName);
            shoes_2Sprite.SetSprite(tk2DSpriteCollectionData, 0);
            //shoes_2Sprite.SortingOrder = 6;
            shoes_2Sprite.SortingLevel = 1;

            m_lstPartSprite.Add(shoes_2Sprite);
        }

        if (fashionData.Belt_a != 0)
        {
            var partData = ConfigManager.Instance.GetData<PartLoader, PartLoader.Data>(fashionData.Belt_a);

            GameObject beltObj = new GameObject("Belt_a");
            beltObj.transform.parent = rootTrans;

            var beltSprite = Common.GetOrAddComponent<tk2dSprite>(beltObj);
            tk2dSpriteCollectionData tk2DSpriteCollectionData = tk2dSystem.LoadResourceByName<tk2dSpriteCollectionData>(partData.CollectionName);
            beltSprite.SetSprite(tk2DSpriteCollectionData, 0);
            //beltSprite.SortingOrder = 7;
            beltSprite.SortingLevel = 2;

            m_lstPartSprite.Add(beltSprite);
        }
        if (fashionData.Belt_b != 0)
        {
            var partData = ConfigManager.Instance.GetData<PartLoader, PartLoader.Data>(fashionData.Belt_b);

            GameObject beltObj = new GameObject("Belt_b");
            beltObj.transform.parent = rootTrans;

            var beltSprite = Common.GetOrAddComponent<tk2dSprite>(beltObj);
            tk2dSpriteCollectionData tk2DSpriteCollectionData = tk2dSystem.LoadResourceByName<tk2dSpriteCollectionData>(partData.CollectionName);
            beltSprite.SetSprite(tk2DSpriteCollectionData, 0);
            //beltSprite.SortingOrder = 7;
            beltSprite.SortingLevel = 2;

            m_lstPartSprite.Add(beltSprite);
        }
        if (fashionData.Belt_c != 0)
        {
            var partData = ConfigManager.Instance.GetData<PartLoader, PartLoader.Data>(fashionData.Belt_c);

            GameObject beltObj = new GameObject("Belt_c");
            beltObj.transform.parent = rootTrans;

            var beltSprite = Common.GetOrAddComponent<tk2dSprite>(beltObj);
            tk2dSpriteCollectionData tk2DSpriteCollectionData = tk2dSystem.LoadResourceByName<tk2dSpriteCollectionData>(partData.CollectionName);
            beltSprite.SetSprite(tk2DSpriteCollectionData, 0);
            //beltSprite.SortingOrder = 7;
            beltSprite.SortingLevel = 2;

            m_lstPartSprite.Add(beltSprite);
        }
        if (fashionData.Belt_d != 0)
        {
            var partData = ConfigManager.Instance.GetData<PartLoader, PartLoader.Data>(fashionData.Belt_d);

            GameObject beltObj = new GameObject("Belt_d");
            beltObj.transform.parent = rootTrans;

            var beltSprite = Common.GetOrAddComponent<tk2dSprite>(beltObj);
            tk2dSpriteCollectionData tk2DSpriteCollectionData = tk2dSystem.LoadResourceByName<tk2dSpriteCollectionData>(partData.CollectionName);
            beltSprite.SetSprite(tk2DSpriteCollectionData, 0);
            //beltSprite.SortingOrder = 7;
            beltSprite.SortingLevel = 2;

            m_lstPartSprite.Add(beltSprite);
        }
        if (fashionData.Weapon_a != 0)
        {
            var partData = ConfigManager.Instance.GetData<PartLoader, PartLoader.Data>(fashionData.Weapon_a);

            GameObject weapon_1Obj = new GameObject("Weapon_a");
            weapon_1Obj.transform.parent = rootTrans;

            var weapon_1Sprite = Common.GetOrAddComponent<tk2dSprite>(weapon_1Obj);
            tk2dSpriteCollectionData tk2DSpriteCollectionData = tk2dSystem.LoadResourceByName<tk2dSpriteCollectionData>(partData.CollectionName);
            weapon_1Sprite.SetSprite(tk2DSpriteCollectionData, 0);
            //weapon_1Sprite.SortingOrder = 8;
            weapon_1Sprite.SortingLevel = 2;

            m_weaponSprite = weapon_1Sprite;
            m_lstPartSprite.Add(weapon_1Sprite);
        }

        if (fashionData.Weapon_b != 0)
        {
            var partData = ConfigManager.Instance.GetData<PartLoader, PartLoader.Data>(fashionData.Weapon_b);

            GameObject weapon_2Obj = new GameObject("Weapon_b");
            weapon_2Obj.transform.parent = rootTrans;

            var weapon_2Sprite = Common.GetOrAddComponent<tk2dSprite>(weapon_2Obj);
            tk2dSpriteCollectionData tk2DSpriteCollectionData = tk2dSystem.LoadResourceByName<tk2dSpriteCollectionData>(partData.CollectionName);
            weapon_2Sprite.SetSprite(tk2DSpriteCollectionData, 0);
            //weapon_2Sprite.SortingOrder = 8;
            weapon_2Sprite.SortingLevel = 2;

            m_weaponSprite = weapon_2Sprite;
            m_lstPartSprite.Add(weapon_2Sprite);
        }

        if (fashionData.Weapon_c != 0)
        {
            var partData = ConfigManager.Instance.GetData<PartLoader, PartLoader.Data>(fashionData.Weapon_c);

            GameObject weapon_2Obj = new GameObject("Weapon_c");
            weapon_2Obj.transform.parent = rootTrans;

            var weapon_2Sprite = Common.GetOrAddComponent<tk2dSprite>(weapon_2Obj);
            tk2dSpriteCollectionData tk2DSpriteCollectionData = tk2dSystem.LoadResourceByName<tk2dSpriteCollectionData>(partData.CollectionName);
            weapon_2Sprite.SetSprite(tk2DSpriteCollectionData, 0);
            //weapon_2Sprite.SortingOrder = 8;
            weapon_2Sprite.SortingLevel = 2;

            m_lstPartSprite.Add(weapon_2Sprite);
        }
        if (fashionData.Weapon_d != 0)
        {
            var partData = ConfigManager.Instance.GetData<PartLoader, PartLoader.Data>(fashionData.Weapon_d);

            GameObject weapon_2Obj = new GameObject("Weapon_d");
            weapon_2Obj.transform.parent = rootTrans;

            var weapon_2Sprite = Common.GetOrAddComponent<tk2dSprite>(weapon_2Obj);
            tk2dSpriteCollectionData tk2DSpriteCollectionData = tk2dSystem.LoadResourceByName<tk2dSpriteCollectionData>(partData.CollectionName);
            weapon_2Sprite.SetSprite(tk2DSpriteCollectionData, 0);
            //weapon_2Sprite.SortingOrder = 8;
            weapon_2Sprite.SortingLevel = 2;

            m_lstPartSprite.Add(weapon_2Sprite);
        }

        if (fashionData.Subweapon_a != 0)
        {
            var partData = ConfigManager.Instance.GetData<PartLoader, PartLoader.Data>(fashionData.Subweapon_a);

            GameObject weapon_2Obj = new GameObject("Subweapon_a");
            weapon_2Obj.transform.parent = rootTrans;

            var weapon_2Sprite = Common.GetOrAddComponent<tk2dSprite>(weapon_2Obj);
            tk2dSpriteCollectionData tk2DSpriteCollectionData = tk2dSystem.LoadResourceByName<tk2dSpriteCollectionData>(partData.CollectionName);
            weapon_2Sprite.SetSprite(tk2DSpriteCollectionData, 0);
            //weapon_2Sprite.SortingOrder = 8;
            weapon_2Sprite.SortingLevel = 2;

            m_lstPartSprite.Add(weapon_2Sprite);
        }
        if (fashionData.Subweapon_b != 0)
        {
            var partData = ConfigManager.Instance.GetData<PartLoader, PartLoader.Data>(fashionData.Subweapon_b);

            GameObject weapon_2Obj = new GameObject("Subweapon_b");
            weapon_2Obj.transform.parent = rootTrans;

            var weapon_2Sprite = Common.GetOrAddComponent<tk2dSprite>(weapon_2Obj);
            tk2dSpriteCollectionData tk2DSpriteCollectionData = tk2dSystem.LoadResourceByName<tk2dSpriteCollectionData>(partData.CollectionName);
            weapon_2Sprite.SetSprite(tk2DSpriteCollectionData, 0);
            //weapon_2Sprite.SortingOrder = 8;
            weapon_2Sprite.SortingLevel = 2;

            m_lstPartSprite.Add(weapon_2Sprite);
        }
        if (fashionData.Subweapon_c != 0)
        {
            var partData = ConfigManager.Instance.GetData<PartLoader, PartLoader.Data>(fashionData.Subweapon_c);

            GameObject weapon_2Obj = new GameObject("Subweapon_c");
            weapon_2Obj.transform.parent = rootTrans;

            var weapon_2Sprite = Common.GetOrAddComponent<tk2dSprite>(weapon_2Obj);
            tk2dSpriteCollectionData tk2DSpriteCollectionData = tk2dSystem.LoadResourceByName<tk2dSpriteCollectionData>(partData.CollectionName);
            weapon_2Sprite.SetSprite(tk2DSpriteCollectionData, 0);
            //weapon_2Sprite.SortingOrder = 8;
            weapon_2Sprite.SortingLevel = 2;

            m_lstPartSprite.Add(weapon_2Sprite);
        }
        if (fashionData.Subweapon_d != 0)
        {
            var partData = ConfigManager.Instance.GetData<PartLoader, PartLoader.Data>(fashionData.Subweapon_d);

            GameObject weapon_2Obj = new GameObject("Subweapon_d");
            weapon_2Obj.transform.parent = rootTrans;

            var weapon_2Sprite = Common.GetOrAddComponent<tk2dSprite>(weapon_2Obj);
            tk2dSpriteCollectionData tk2DSpriteCollectionData = tk2dSystem.LoadResourceByName<tk2dSpriteCollectionData>(partData.CollectionName);
            weapon_2Sprite.SetSprite(tk2DSpriteCollectionData, 0);
            //weapon_2Sprite.SortingOrder = 8;
            weapon_2Sprite.SortingLevel = 2;

            m_lstPartSprite.Add(weapon_2Sprite);
        }

        GameObject effectObj = new GameObject("Effect");
        effectObj.transform.parent = rootTrans;
    }
    private void UpdatePartSprite()
    {
        for (int i = 0; i < m_lstPartSprite.Count; i++)
        {
            m_lstPartSprite[i].SetSprite(m_tk2dSpriteAnimator.CurrentSpriteId);
            
            m_lstPartSprite[i].SortingOrder = 600 - (int)m_owner.Transform.position.y + m_lstPartSprite[i].SortingLevel;

            var bounds= m_weaponSprite.GetBounds();
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
