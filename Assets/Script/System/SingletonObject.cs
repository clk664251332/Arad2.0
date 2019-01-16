using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// 不需要挂载到场景物体，直接使用
/// </summary>
public class SingletonObject<T> where T : class
{
    private static T m_instance;

    public static T Instance
    {
        get
        {
            if (m_instance == null)
            {
                m_instance = (T)Activator.CreateInstance(typeof(T));
                SingletonInstances.InstanceList.Add(m_instance);
            }

            return m_instance;
        }
    }
}
