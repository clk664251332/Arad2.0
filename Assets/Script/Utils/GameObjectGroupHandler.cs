using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 根据类的继承关系在Hierarchy界面创建相应层级的物体以便物体的管理
/// 创建源物体及其父类物体。。
/// </summary>
public static class GameObjectGroupHandler
{
    private static Dictionary<Type, GameObject> m_dicTree = new Dictionary<Type, GameObject>();

    public static GameObject GetActorDetailGroup(Type tSourceType)
    {
        GenerateInheritTree(tSourceType, typeof(Actor));

        GameObject obj = null;
        if (m_dicTree.TryGetValue(tSourceType, out obj))
        {
            return obj;
        }
        return null;
    }

    public static void GenerateInheritTree(Type tSourceType, Type tBaseType)
    {
        if (m_dicTree == null)
        {
            m_dicTree = new Dictionary<Type, GameObject>();
        }
        else
        {
            GameObject obj = null;
            if (m_dicTree.TryGetValue(tSourceType, out obj))
            {
                if (obj == null)
                    m_dicTree.Clear();
            }
        }

        GenerateTree(tSourceType, tBaseType);
    }

    public static void GenerateTree(Type tSourceType, Type tBaseType, GameObject objChild = null)
    {
        if (!tSourceType.IsSubclassOf(tBaseType) && tSourceType != tBaseType)
            return;

        if (m_dicTree.ContainsKey(tSourceType))
        {
            if (objChild != null && m_dicTree[tSourceType] != null)
                objChild.transform.parent = m_dicTree[tSourceType].transform;
        }
        else
        {
            GameObject obj = new GameObject(tSourceType.Name);
            if (objChild != null)
                objChild.transform.parent = obj.transform;

            objChild = obj;
            m_dicTree.Add(tSourceType, obj);

            tSourceType = tSourceType.BaseType;
            GenerateTree(tSourceType, tBaseType, objChild);
        }
    }
}
