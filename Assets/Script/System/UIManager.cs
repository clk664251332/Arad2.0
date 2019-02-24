using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIManager : SingletonObject<UIManager>
{
    public Transform m_rootTrans;
    private Dictionary<string, BaseMediator> m_dicBaseMediator = new Dictionary<string, BaseMediator>();
    private List<BaseMediator> m_lstOpenMediator = new List<BaseMediator>();

    public void Initialize()
    {
        InitCanvas();
        InitMediator();
        EventManager.Instance.AddInputEvent(null, EEventType.InputManager_ShowUI, new BoolCallback(ShowUITest));
    }

    private void InitCanvas()
    {
        GameObject canvasObj = new GameObject("Canvas");
        canvasObj.layer = 5;
        Canvas canvas = Common.GetOrAddComponent<Canvas>(canvasObj);
        GameObject.DontDestroyOnLoad(canvasObj);
        m_rootTrans = canvasObj.transform;
        canvas.renderMode = RenderMode.ScreenSpaceCamera;
        canvas.worldCamera = Camera.main;
        canvas.sortingLayerName = "UI";

        Common.GetOrAddComponent<GraphicRaycaster>(canvasObj);
    }

    private void InitMediator()
    {
        List<Type> lstType = ReflectionHelper.GetAllSubclassByType(typeof(BaseMediator));
        if (lstType == null) return;

        for (int i = 0; i < lstType.Count; i++)
        {
            Type typeMediator = lstType[i];
            string strMediatorName = typeMediator.ToString().ToLower();

            if (!m_dicBaseMediator.ContainsKey(strMediatorName))
            {
                BaseMediator baseMediator = Activator.CreateInstance(typeMediator) as BaseMediator;
                baseMediator.PanelName = strMediatorName;

                m_dicBaseMediator.Add(strMediatorName, baseMediator);
            }
        }
    }

    public void Update()
    {
        for (int i = 0; i < m_lstOpenMediator.Count; i++)
        {
            if (m_lstOpenMediator[i].IsOpen)
                m_lstOpenMediator[i].Update();
        }
    }

    public void ToggleOpen<T>() where T : BaseMediator
    {
        BaseMediator mediator = GetMediator<T>();
        if (mediator != null)
        {
            mediator.ToggleOpen();
        }
    }

    public void OpenWnd<T>() where T : BaseMediator
    {
        string strMediatorName = typeof(T).ToString().ToLower();
        OpenWnd(strMediatorName);
    }

    public void OpenWnd(string name)
    {
        BaseMediator mediator = GetMediator(name);
        if (mediator != null)
        {
            mediator.UIManagerOpen();
        }
    }

    private void OpenWnd(BaseMediator mediator)
    {
        if (mediator == null) return;

        if (!m_lstOpenMediator.Contains(mediator))
        {
            m_lstOpenMediator.Add(mediator);
        }
    }

    public void CloseWnd<T>() where T : BaseMediator
    {
        string strMediatorName = typeof(T).ToString().ToLower();
        CloseWnd(strMediatorName);
    }

    public void CloseWnd(string name)
    {
        BaseMediator mediator = GetMediator(name);
        if (mediator != null)
        {
            mediator.UIManagerClose();
        }
    }

    private void CloseWnd(BaseMediator mediator)
    {
        if (mediator == null) return;

        if (!m_lstOpenMediator.Contains(mediator))
        {
            m_lstOpenMediator.Remove(mediator);
        }
    }

    private BaseMediator GetMediator(string mediatorName)
    {
        BaseMediator baseMediator = null;
        m_dicBaseMediator.TryGetValue(mediatorName, out baseMediator);
        return baseMediator;
    }

    private T GetMediator<T>() where T : BaseMediator
    {
        string strMediatorName = typeof(T).ToString().ToLower();
        return GetMediator(strMediatorName) as T;
    }

    private bool ShowUITest()
    {
        ToggleOpen<TestUI>();

        return true;
    }

    public void Release()
    {
        for (int i = 0; i < m_lstOpenMediator.Count; i++)
        {
            m_lstOpenMediator[i].Release();
        }
    }
}
