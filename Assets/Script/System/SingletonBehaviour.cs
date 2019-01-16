using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 该脚本必须挂载到场景物体上才行
/// </summary>
/// <typeparam name="T"></typeparam>
public class SingletonBehaviour<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T m_instance;

    public static T Instance
    {
        get
        {
            if (m_instance == null)
            {
                m_instance = FindObjectOfType<T>();
                SingletonInstances.InstanceList.Add(m_instance);
            }

            return m_instance;
        }
    }
}

