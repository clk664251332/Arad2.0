using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : SingletonObject<EventManager>
{
    public void Initialize()
    {
        CustomEventHandler.Clear();
        InputEventHandler.Clear();
    }

    #region InputEvent
    public void AddInputEvent(IEventListener iEventListener, EEventType eEventType, BoolCallback callback)
    {
        InputEventHandler.AddEvent(iEventListener, eEventType, callback);
    }

    public void RemoveInputEvent(EEventType eEventType, BoolCallback callback)
    {
        InputEventHandler.RemoveEvent(eEventType, callback);
    }

    public bool SendInputEvent(EEventType eEventType)
    {
        return InputEventHandler.SendEvent(eEventType);
    }
    #endregion

    #region CustomEvent
    public void AddCustomEvent(IEventListener iEventListener, EEventType eEventType, Callback callback)
    {
        CustomEventHandler.AddEvent(iEventListener, eEventType, callback);
    }

    public void AddCustomEvent<T>(IEventListener iEventListener, EEventType eEventType, Callback<T> callback)
    {
        CustomEventHandler.AddEvent(iEventListener, eEventType, callback);
    }

    public void AddCustomEvent<T1, T2>(IEventListener iEventListener, EEventType eEventType, Callback<T1, T2> callback)
    {
        CustomEventHandler.AddEvent(iEventListener, eEventType, callback);
    }

    public void RemoveCustomEvent(EEventType eEventType, Callback callback)
    {
        CustomEventHandler.RemoveEvent(eEventType, callback);
    }

    public void RemoveCustomEvent<T>(EEventType eEventType, Callback<T> callback)
    {
        CustomEventHandler.RemoveEvent(eEventType, callback);
    }

    public void RemoveCustomEvent<T1, T2>(EEventType eEventType, Callback<T1, T2> callback)
    {
        CustomEventHandler.RemoveEvent(eEventType, callback);
    }

    public void SendCustomEvent(EEventType eEventType)
    {
        CustomEventHandler.SendEvent(eEventType);
    }

    public void SendCustomEvent<T>(EEventType eEventType, T arg1)
    {
        CustomEventHandler.SendEvent(eEventType, arg1);
    }

    public void SendCustomEvent<T1, T2>(EEventType eEventType, T1 arg1, T2 agr2)
    {
        CustomEventHandler.SendEvent(eEventType, arg1, agr2);
    }
    #endregion
}
