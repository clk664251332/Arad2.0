using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public enum EState
{
    Open,
    Close,
    Load,
}

public class BaseMediator
{
    protected string strPanelName = string.Empty;
    protected EState m_eCurState = EState.Load;
    private bool m_bOpen = false;

    private GameObject m_mediatorObj;
    protected Transform m_mediatorTrans;

    public string PanelName
    {
        get
        {
            return strPanelName;
        }

        set
        {
            strPanelName = value;
        }
    }
    public bool IsOpen
    {
        get { return m_eCurState == EState.Open; }
    }

    public void UIManagerOpen()
    {
        m_bOpen = true;
        switch (m_eCurState)
        {
            case EState.Open:
                {
                    DirectOpen();
                }
                break;
            case EState.Close:
                {
                    DirectOpen();
                }
                break;
            case EState.Load:
                {
                    LoadObjResources();
                }
                break;
            default:
                break;
        }
    }

    public UIBehaviour GetElement(string elementName)
    {
        if (m_mediatorTrans == null) return null;

        int nEnd;
        var childs = m_mediatorTrans.GetComponentsInChildren<Transform>();
        for (int i = 0; i < childs.Length; i++)
        {
            string strName = childs[i].gameObject.name;
            nEnd = strName.IndexOf(")");

            if (nEnd == -1) continue;
            string strSub = strName.Substring(0, nEnd + 1);

            if (strSub.Equals("(Text)") && strName.Equals(elementName))
            {
                return childs[i].GetComponent<Text>() as UIBehaviour;
            }
            else if(strSub.Equals("(Button)") && strName.Equals(elementName))
            {
                return childs[i].GetComponent<Button>() as UIBehaviour;
            }
            else if (strSub.Equals("(Image)") && strName.Equals(elementName))
            {
                return childs[i].GetComponent<Image>() as UIBehaviour;
            }
        }

        return null;
    }

    public void ToggleOpen()
    {
        if (m_eCurState != EState.Open)
            UIManagerOpen();
        else
            UIManagerClose();
    }

    public void UIManagerClose()
    {
        if (!m_bOpen) return;

        m_bOpen = false;
        if (m_mediatorObj == null) return;

        ResetPos();
        m_eCurState = EState.Close;
        m_mediatorObj.SetActive(false);
        //OnClose();
    }

    private void ResetPos()
    {
        //重置窗口位置
    }

    private void DirectOpen()
    {
        if (m_mediatorObj == null) return;

        if(m_eCurState == EState.Open)
        {
            //显示在最前面
        }

        OnOpen();
        m_eCurState = EState.Open;
        m_mediatorObj.SetActive(m_bOpen);
    }

    private void LoadObjResources()
    {
        if (m_eCurState == EState.Load)
        {
            GameObject loadObj = Resources.Load<GameObject>("UI/" + strPanelName);
            m_mediatorObj = GameObject.Instantiate(loadObj);
            m_mediatorObj.transform.parent = UIManager.Instance.m_rootTrans;
            m_mediatorObj.SetActive(false);
            m_mediatorTrans = m_mediatorObj.transform;

            if (m_bOpen)
            {
                InitElement();
                DirectOpen();
                return;
            }

            m_eCurState = EState.Close;

        }
    }

    public virtual void Update()
    {

    }

    public virtual void InitElement()
    {

    }
    public virtual void OnOpen()
    {

    }

    public virtual void Close()
    {
        UIManagerClose();
    }

    public virtual void Release()
    {

    }
}
