using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class ReflectionHelper
{
    private static Dictionary<string, Type> m_dicReflectionType = new Dictionary<string, Type>();

    public static Type GetTypeByName(string name)
    {
        if (m_dicReflectionType.ContainsKey(name))
            return m_dicReflectionType[name];

        Assembly assembly = Assembly.GetExecutingAssembly();//获取当前的程序集
        Type[] types = assembly.GetExportedTypes();
        for(int i=0;i< types.Length; ++i)
        {
            var t = types[i];
            if (t.IsClass && t.Name == name)
            {
                m_dicReflectionType[name] = t;
                return t;
            }
        }

        Debug.LogError("not find objecttype = " + name);
        return null;
    }

    public static object CreateObjectByName(string name,object[] param = null)
    {
        Type type = GetTypeByName(name);
        if (type == null)
            return null;

        return Activator.CreateInstance(type, name);
    }

    public static T CreatClassByName<T>(string name,object[] param =null) where T : class
    {
        if (string.IsNullOrEmpty(name))
        {
            Debug.LogError("name is null or empty ");
            return null;
        }

        object obj = CreateObjectByName(name, param);
        if (obj == null)
            return null;

        T ret = (obj is T) ? (obj as T) : null;
        if (ret == null)
        {
            Debug.LogError("name = " + name + "is not a class type");
        }

        return ret;
    }
    
    public static List<Type> GetAllSubclassByType(Type typeBase)
    {
        List<Type> lstType = new List<Type>();
        Assembly assembly = Assembly.GetExecutingAssembly();//获取当前程序集
        Type[] types = assembly.GetExportedTypes();
        for(int i=0;i< types.Length; i++)
        {
            var t = types[i];
            if (t.IsClass && t.IsSubclassOf(typeBase))
            {
                lstType.Add(t);
            }
        }

        return lstType;
    }
}
