using System;
using System.Collections.Generic;
using UnityEngine;

public class InputEventHandler
{
    private static Dictionary<int, List<EventListen>> m_dictEvent = new Dictionary<int, List<EventListen>>();

    public static void AddEvent(IEventListener iEventListener, EEventType eEventType, Delegate callback)
    {
        if (callback == null)
        {
            Debug.LogWarning(string.Format("add  EEventType : {0} call ball is null", eEventType.ToString()));
            return;
        }

        int idEvent = (int)eEventType;
        List<EventListen> lstListen = null;
        if (!m_dictEvent.TryGetValue(idEvent, out lstListen))
        {
            lstListen = new List<EventListen>();
        }

        for (int i = 0, count = lstListen.Count; i < count; i++)
        {
            EventListen eventListen = lstListen[i];
            if (eventListen.m_callBack == callback)
            {
                Debug.LogWarning(string.Format("add same keyvalue {0}={1}", eEventType.ToString(), callback.ToString()));
                return;
            }
        }

        lstListen.Add(new EventListen(iEventListener, callback));
        m_dictEvent[idEvent] = lstListen;
    }

    public static void RemoveEvent(EEventType eEventType, Delegate callback)
    {
        int idEvent = (int)eEventType;
        List<EventListen> lstListen = null;
        if (m_dictEvent.TryGetValue(idEvent, out lstListen))
        {
            if (lstListen != null)
            {
                for (int i = lstListen.Count - 1; i >= 0; --i)
                {
                    EventListen eventListen = lstListen[i];
                    if (eventListen.m_callBack == callback)
                    {
                        lstListen.Remove(eventListen);
                    }
                }
            }
        }
    }

    public static bool SendEvent(EEventType eEventType)
    {
        bool bRet = false;
        int idEvent = (int)eEventType;
        List<EventListen> lstListen = null;
        if (m_dictEvent.TryGetValue(idEvent, out lstListen))
        {
            if (lstListen == null)
                return bRet;

            int nCount = lstListen.Count;
            for (int i = nCount - 1; i >= 0; --i)
            {
                EventListen eventListen = lstListen[i];
                if (eventListen == null)
                {
                    Debug.LogWarning("###########send event type: " + eEventType + "callback is Null");
                    lstListen.RemoveAt(i);
                    continue;
                }

                //关闭监听
                if (eventListen.m_eventListener != null && !eventListen.m_eventListener.bListen)
                {
                    continue;
                }

                BoolCallback callBack = eventListen.m_callBack as BoolCallback;
                if (callBack == null)
                {
                    lstListen.RemoveAt(i);
                    continue;
                }

                //如果有一个返回正确，就认为是正确的
                bool bReturn = callBack();
                if (bReturn)
                {
                    bRet = true;
                    break;
                }
            }
        }

        return bRet;
    }

    public static void Clear()
    {
        m_dictEvent.Clear();
    }
}
