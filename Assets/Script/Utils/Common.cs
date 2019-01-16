using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void Callback();
public delegate void Callback<T>(T arg1);
public delegate void Callback<T1, T2>(T1 arg1, T2 arg2);
public delegate void Callback<T1, T2, T3>(T1 arg1, T2 arg2, T3 arg3);

public class Common
{
    public static T GetOrAddComponent<T>(GameObject go) where T : Component
    {
        T t = go.GetComponent<T>();

        if (t == null)
            t = go.AddComponent<T>();

        return t;
    }
}
