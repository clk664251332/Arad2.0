using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEventListener
{
    bool bListen
    {
        get;
        set;
    }
}

public class EventListen
{
    public IEventListener m_eventListener;
    public Delegate m_callBack;

    public EventListen(IEventListener eventListener, Delegate callback)
    {
        m_eventListener = eventListener;
        m_callBack = callback;
    }
}

public class CustomEventHandler
{
    private static Dictionary<int, List<EventListen>> m_dicEvent = new Dictionary<int, List<EventListen>>();

    public static void AddEvent(IEventListener iEventListener, EEventType eEventType, Delegate callback)
    {
        if(callback == null)
        {
            Debug.LogWarning("XX");
            return;
        }

        int idEvent = (int)eEventType;
        List<EventListen> lstListen = null;
        if(!m_dicEvent.TryGetValue(idEvent,out lstListen))
        {
            lstListen = new List<EventListen>();
        }

        for(int i=0,count= lstListen.Count; i < count; i++)
        {
            EventListen eventListen = lstListen[i];
            if (eventListen.m_callBack == callback)
            {
                Debug.LogWarning("Add Same Key");
            }
        }

        lstListen.Add(new EventListen(iEventListener, callback));
        m_dicEvent[idEvent] = lstListen;
    }

    public static void RemoveEvent(EEventType eEventType, Delegate callback)
    {
        int idEvent = (int)eEventType;
        List<EventListen> lstListen = null;
        if (m_dicEvent.TryGetValue(idEvent, out lstListen))
        {
            if (lstListen == null)
                return;

            int nCount = lstListen.Count;
            for (int i = nCount - 1; i >= 0; --i)
            {
                EventListen eventListen = lstListen[i];
                if (eventListen.m_callBack == callback)
                {
                    lstListen.Remove(eventListen);
                }
            }
        }
    }

    public static void SendEvent(EEventType eEventType)
    {
        int idEvent = (int)eEventType;
        List<EventListen> lstListen = null;
        if (m_dicEvent.TryGetValue(idEvent, out lstListen))
        {
            if (lstListen == null)
                return;

            int nCount = lstListen.Count;
            for(int i = nCount - 1; i >= 0; --i)
            {
                EventListen eventListen = lstListen[i];

                if (lstListen[i] == null)
                {
                    Debug.LogWarning("CallBack is Null");
                    lstListen.RemoveAt(i);
                    continue;
                }

                //关闭监听
                if (eventListen.m_eventListener != null && !eventListen.m_eventListener.bListen)
                {
                    continue;
                }

                Callback callBack = eventListen.m_callBack as Callback;
                if (callBack == null)
                {
                    Debug.LogWarning("CallBack is Null");
                    continue;
                }

                callBack();
            }
        }
    }

    public static void SendEvent<T>(EEventType eEventType, T arg1)
    {
        int idEvent = (int)eEventType;
        List<EventListen> lstListen = null;
        if (m_dicEvent.TryGetValue(idEvent, out lstListen))
        {
            if (lstListen == null)
                return;

            int nCount = lstListen.Count;
            for (int i = nCount - 1; i >= 0; --i)
            {
                EventListen eventListen = lstListen[i];

                if (lstListen[i] == null)
                {
                    Debug.LogWarning("CallBack is Null");
                    lstListen.RemoveAt(i);
                    continue;
                }

                //关闭监听
                if (eventListen.m_eventListener != null && !eventListen.m_eventListener.bListen)
                {
                    continue;
                }

                Callback<T> callBack = eventListen.m_callBack as Callback<T>;
                if (callBack == null)
                {
                    Debug.LogWarning("CallBack is Null");
                    continue;
                }

                callBack(arg1);
            }
        }
    }

    public static void SendEvent<T1, T2>(EEventType eEventType, T1 arg1, T2 arg2)
    {
        int idEvent = (int)eEventType;
        List<EventListen> lstListen = null;
        if (m_dicEvent.TryGetValue(idEvent, out lstListen))
        {
            if (lstListen == null)
                return;

            int nCount = lstListen.Count;
            for (int i = nCount - 1; i >= 0; --i)
            {
                EventListen eventListen = lstListen[i];

                if (lstListen[i] == null)
                {
                    Debug.LogWarning("CallBack is Null");
                    lstListen.RemoveAt(i);
                    continue;
                }

                //关闭监听
                if (eventListen.m_eventListener != null && !eventListen.m_eventListener.bListen)
                {
                    continue;
                }

                Callback<T1, T2> callBack = eventListen.m_callBack as Callback<T1, T2>;
                if (callBack == null)
                {
                    Debug.LogWarning("CallBack is Null");
                    continue;
                }

                callBack(arg1, arg2);
            }
        }
    }

    public static void Clear()
    {
        m_dicEvent.Clear();
    }
}
