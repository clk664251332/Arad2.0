using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public static class CommonHelper
{
    public static void FillDic<T1, T2>(T1 key, T2 value, Dictionary<T1, T2> dictData)
    {
        if (!dictData.ContainsKey(key))
        {
            dictData.Add(key, value);
        }
        else
        {
            dictData[key] = value;
        }
    }

    public static string GetString(ref string src, string s)
    {
        src = s;
        return s;
    }

    public static double GetDouble(string s)
    {
        double value = 0;
        double.TryParse(s, out value);

        return value;
    }

    public static float GetSingle(string s)
    {
        float value = 0;
        float.TryParse(s, out value);

        return value;
    }

    public static float GetSingle(ref float src, string s)
    {
        if (src != 0)
        {
            return src;
        }

        if (s.Equals("0"))
        {
            return src;
        }

        float value = 0;
        float.TryParse(s, out value);

        src = value;
        return value;
    }

    public static int GetInt32(string s)
    {
        int value = 0;

        Int32.TryParse(s, out value);
        return value;
    }

    public static int GetInt32(ref int src, string s)
    {
        if (src != 0)
        {
            return src;
        }


        if (s.Equals("0"))
        {
            return src;
        }

        int value = 0;
        Int32.TryParse(s, out value);

        src = value;
        return value;
    }

    public static uint GetUInt32(string s)
    {
        uint value = 0;
        UInt32.TryParse(s, out value);

        return value;
    }

    public static uint GetUInt32(ref uint src, string s)
    {
        if (src != 0)
        {
            return src;
        }


        if (s.Equals("0"))
        {
            return src;
        }

        uint value = 0;
        UInt32.TryParse(s, out value);

        src = value;
        return value;
    }

    public static short GetInt16(string s)
    {
        short value = 0;
        Int16.TryParse(s, out value);

        return value;
    }

    public static short GetInt16(ref short src, string s)
    {
        if (src != 0)
        {
            return src;
        }

        if (s.Equals("0"))
        {
            return src;
        }

        short value = 0;
        Int16.TryParse(s, out value);

        src = value;
        return value;
    }

    public static ushort GetUInt16(string s)
    {
        ushort value = 0;
        UInt16.TryParse(s, out value);

        return value;
    }

    public static ushort GetUInt16(ref ushort src, string s)
    {
        if (src != 0)
        {
            return src;
        }

        if (s.Equals("0"))
        {
            return src;
        }

        ushort value = 0;
        UInt16.TryParse(s, out value);

        src = value;
        return value;
    }

    public static bool GetBoolean(ref bool src, string s)
    {
        if (src)
        {
            return src;
        }
        bool result = (s.Equals("0") ? false : true);

        src = result;
        return result;
    }

    public static bool GetBoolean(ref bool src, int s)
    {
        if (src)
        {
            return src;
        }

        bool result = ((s == 0) ? false : true);

        src = result;
        return result;
    }

    public static bool GetBoolean(uint s)
    {

        bool result = ((s == 0) ? false : true);

        return result;
    }

    public static byte GetByte(string s)
    {
        byte value = 0;
        byte.TryParse(s, out value);

        return value;
    }

    public static byte GetByte(ref byte src, string s)
    {
        if (src != 0)
        {
            return src;
        }

        if (s.Equals("0"))
        {
            return src;
        }

        byte value = 0;
        byte.TryParse(s, out value);

        src = value;
        return value;
    }

    //将值转为List;
    public static List<byte> TransStrToByteList(List<byte> list, string arg, params char[] separator)
    {
        if (String.IsNullOrEmpty(arg))
        {
            return list;
        }
        if (null == list)
        {
            //Debug.LogError(" TransStrToByteList error !  the 'list' is null.");
            //return list;
            list = new List<byte>();
        }

        if (list.Count != 0)
        {
            return list;
        }

        string[] strs = arg.Split(separator);

        for (int i = 0, len = strs.Length; i < len; ++i)
        {
            byte tmp = GetByte(strs[i]);
            list.Add(tmp);
        }

        if (list.Count == 0)
        {
            Debug.LogError("TransStrToByteList error,list.count = 0");
        }

        return list;
    }

    public static List<uint> TransRangeStrToUintList(List<uint> list, string arg, params char[] separator)
    {
        if (String.IsNullOrEmpty(arg))
        {
            return list;
        }
        if (null == list)
        {
            //Debug.LogError(" TransRangeStrToUintList error !  the 'list' is null.");
            //return list;
            list = new List<uint>();
        }

        if (list.Count != 0)
        {
            return list;
        }

        string[] strs = arg.Split(separator);

        if (strs.Length >= 2)
        {
            uint max = Math.Max(GetUInt32(strs[0]), GetUInt32(strs[1]));
            uint min = Math.Min(GetUInt32(strs[0]), GetUInt32(strs[1]));

            for (uint i = min; i <= max; i++)
            {
                list.Add(i);
            }
        }

        if (list.Count == 0)
        {
            Debug.LogError("TransRangeStrToUintList error,list.count = 0");
        }
        return list;
    }

    //将值转为List;
    public static List<uint> TransStrToUintList(List<uint> list, string arg, params char[] separator)
    {
        list.Clear();
        if (String.IsNullOrEmpty(arg))
        {
            return list;
        }
        if (null == list)
        {
            //Debug.LogError(" TransStrToUintList error !  the 'list' is null.");
            //return list;
            list = new List<uint>();
        }

        if (list.Count != 0)
        {
            return list;
        }

        string[] strs = arg.Split(separator);

        for (int i = 0, len = strs.Length; i < len; ++i)
        {
            uint tmp = GetUInt32(strs[i]);
            list.Add(tmp);
        }

        if (list.Count == 0)
        {
            Debug.LogError("TransStrToUintList error,list.count = 0");
        }

        return list;
    }

    public static List<int> TransStrToIntList(List<int> list, string arg, params char[] separator)
    {
        if (String.IsNullOrEmpty(arg))
        {
            return list;
        }
        if (null == list)
        {
            //Debug.LogError(" TransStrToIntList error !  the 'list' is null.");
            //return list;
            list = new List<int>();
        }

        if (list.Count != 0)
        {
            return list;
        }

        string[] strs = arg.Split(separator);

        for (int i = 0, len = strs.Length; i < len; ++i)
        {
            int tmp = GetInt32(strs[i]);
            list.Add(tmp);
        }

        if (list.Count == 0)
        {
            Debug.LogError(" TransStrToIntList error,list.count = 0");
        }
        return list;
    }

    public static List<float> TransStrToFloatList(List<float> list, string arg, params char[] separator)
    {
        if (String.IsNullOrEmpty(arg))
        {
            return list;
        }
        if (null == list)
        {
            //Debug.LogError(" TransStrToFloatList error !  the 'list' is null.");
            //return list;
            list = new List<float>();
        }

        if (list.Count != 0)
        {
            return list;
        }

        string[] strs = arg.Split(separator);

        for (int i = 0, len = strs.Length; i < len; ++i)
        {
            float tmp = GetSingle(strs[i]);
            list.Add(tmp);
        }

        if (list.Count == 0)
        {
            Debug.LogError(" TransStrToFloatList error,list.count = 0");
        }
        return list;
    }

    public static List<double> TransStrToDoubleList(List<double> list, string arg, params char[] separator)
    {
        if (String.IsNullOrEmpty(arg))
        {
            return list;
        }
        if (null == list)
        {
            //Debug.LogError(" TransStrToFloatList error !  the 'list' is null.");
            //return list;
            list = new List<double>();
        }

        if (list.Count != 0)
        {
            return list;
        }

        string[] strs = arg.Split(separator);

        for (int i = 0, len = strs.Length; i < len; ++i)
        {
            double tmp = GetDouble(strs[i]);
            list.Add(tmp);
        }

        if (list.Count == 0)
        {
            Debug.LogError(" TransStrToFloatList error,list.count = 0");
        }
        return list;
    }

    public static List<string> TransStrToStringList(List<string> list, string arg, params char[] separator)
    {
        if (String.IsNullOrEmpty(arg))
        {
            return list;
        }
        if (null == list)
        {
            //Debug.LogError(" TransStrToStringList error !  the 'list' is null.");
            //return list;
            list = new List<string>();
        }

        if (list.Count != 0)
        {
            return list;
        }

        string[] strs = arg.Split(separator);

        for (int i = 0, len = strs.Length; i < len; ++i)
        {
            list.Add(strs[i]);
        }

        if (list.Count == 0)
        {
            //Debug.LogError(" Key:" + m_uiKey + " TransStrToStringList error,list.count = 0");
        }
        return list;

    }

    public static Vector2 TransToVector2(ref Vector2 src, string arg, params char[] separator)
    {
        if (arg.Equals("0")) return Vector3.zero;

        string[] strs = arg.Split(separator);
        if (strs.Length != 2)
        {
            Debug.LogError(" TransToVector2 error,strs.Length != 2:" + arg);
            return Vector3.zero;
        }

        float x = GetSingle(strs[0]);
        float y = GetSingle(strs[1]);
        src = new Vector2(x, y);

        return src;
    }

    public static Vector3 TransToVector3(ref Vector3 src, string arg, params char[] separator)
    {
        if (arg.Equals("0")) return Vector3.zero;

        string[] strs = arg.Split(separator);
        if (strs.Length != 3)
        {
            Debug.LogError(" TransToVector3 error,strs.Length != 3:" + arg);
            return Vector3.zero;
        }

        float x = GetSingle(strs[0]);
        float y = GetSingle(strs[1]);
        float z = GetSingle(strs[2]);
        src = new Vector3(x, y, z);

        return src;
    }

    public static Vector4 TransToVector4(ref Vector4 src, string arg, params char[] separator)
    {
        if (arg == "0") return Vector4.zero;

        string[] strs = arg.Split(separator);
        if (strs.Length != 4)
        {
            Debug.LogError(" TransToVector4 error,strs.Length != 4:" + arg);
            return Vector3.zero;
        }


        float x = GetSingle(strs[0]);
        float y = GetSingle(strs[1]);
        float z = GetSingle(strs[2]);
        float w = GetSingle(strs[3]);

        src = new Vector4(x, y, z, w);
        return src;
    }
    public static Rect TransToRect(ref Rect src, string arg, params char[] separator)
    {
        if (src.x != 0 || src.y != 0 || src.width != 0 || src.height != 0)
        {
            return src;
        }

        if (arg.Equals("0")) return src;
        string[] strs = arg.Split(separator);
        if (strs.Length != 4)
        {
            //Debug.LogError(" Key:" + m_uiKey + " TransToRect error,strs.Length != 4:" + arg);
            return src;
        }
        src.x = GetSingle(strs[0]);
        src.y = GetSingle(strs[1]);
        src.height = GetSingle(strs[2]);
        src.width = GetSingle(strs[3]);
        return src;
    }

    //将表里的值转为颜色
    public static Color TransStrToColor(ref Color color, string arg, params char[] separator)
    {
        if (color != Color.black)
        {
            return color;
        }

        if (arg.Equals("0")) return Color.white;

        string[] strs = arg.Split(separator);
        if (strs.Length != 3)
        {
            Debug.LogError(" TransStrToColor error,strs.Length != 3:   " + strs.Length);
        }

        color.r = GetSingle(strs[0]) / 255.0f;
        color.g = GetSingle(strs[1]) / 255.0f;
        color.b = GetSingle(strs[2]) / 255.0f;
        return color;
    }
}