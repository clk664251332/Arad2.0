using Game.Config;
//using Network;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBindingManager : SingletonObject<KeyBindingManager>
{
    public class EventInfo
    {
        public EEventType eEventType; //事件类型 InputManager_开头的事件
        public ELimitCon eLimitCon; //事件限制条件
        public int weight;  //事件权重
    }

    //限制条件
    public enum ELimitCon
    {
        None,  //不收限制
        OnUI, //只接受NGUI上的信息
        ExceptUI,//除了UI
        OnUIInCludeChatArea,//只接受NGUI包括聊天区域上的信息
    }

    //键盘操作方式
    public enum EKeyClick
    {
        Down,
        Up,
        Keep,
    }

    //权重
    public enum EPriority
    {
        HeroOther,
        HeroSpace,
        Hero_RightClick,
        Hero_LeftClick,
        Hero_Ctrl_LeftClick,
        Hero_CtrlUp,
        Hero_PickObject,
        Hero_Shift_Click,
        SceenItem,
        UI,
        GetItemUrl,
        HeroEsc,
        Close_Self,
    }

    public class KeyHandle
    {
        KeyCode m_eKeyCode = KeyCode.None;
        EKeyClick m_eKeyClick = EKeyClick.Down;

        public KeyHandle(KeyCode keyCode, EKeyClick keyClick)
        {
            m_eKeyCode = keyCode;
            m_eKeyClick = keyClick;
        }

        public KeyCode eKeyCode
        {
            get
            {
                return m_eKeyCode;
            }
        }

        public EKeyClick eKeyClick
        {
            get
            {
                return m_eKeyClick;
            }
        }
    }

    public class KeyFire
    {
        List<KeyHandle> m_lstKeyHandle = new List<KeyHandle>();

        public void Clear()
        {
            m_lstKeyHandle.Clear();
        }

        public void AddKeyHandle(KeyCode keyCode, EKeyClick keyClick)
        {
            KeyHandle keyHandle = new KeyHandle(keyCode, keyClick);
            m_lstKeyHandle.Add(keyHandle);
        }

        public bool IsMouseOperate
        {
            get
            {
                for (int i = 0, count = m_lstKeyHandle.Count; i < count; i++)
                {
                    KeyHandle keyHandle = m_lstKeyHandle[i];
                    if (keyHandle.eKeyCode == KeyCode.Mouse0 || keyHandle.eKeyCode == KeyCode.Mouse1)
                    {
                        return true;
                    }
                }

                return false;
            }
        }

        public int Count
        {
            get
            {
                return m_lstKeyHandle.Count;
            }
        }

        public KeyHandle GetKeyHandleByIndex(int index)
        {
            int count = Count;
            if (count >= 0 && index < count)
            {
                return m_lstKeyHandle[index];
            }

            return null;
        }
    }

    private Dictionary<KeyFire, List<EventInfo>> m_dicKeyBind = new Dictionary<KeyFire, List<EventInfo>>();
    List<KeyFire> m_lstKeyFireOne = new List<KeyFire>();
    List<KeyFire> m_lstKeyFireTwo = new List<KeyFire>();
    List<EventInfo> m_lstInvokeEvent = new List<EventInfo>();

    List<KeyFire> m_lstInputKeyFireOne = new List<KeyFire>();
    List<KeyFire> m_lstInputKeyFireTwo = new List<KeyFire>();

    List<KeyFire> m_lstCurrentKeyFire = new List<KeyFire>();
    private bool m_bCurrentFire = true;
    private bool m_bEnable = true;
    private bool m_bBattleStatus = false;


    public void InitLogic() { }
    public void RegisterEvent()
    {
        //EventManager.GetInst().AddCustomEvent(null, EEventType.OnEnterLoginStage, OnEventStartBindKey);
        //EventManager.GetInst().AddCustomEvent(null, EEventType.BindKey, OnEventBindKey);
        //EventManager.GetInst().AddCustomEvent<bool>(null, EEventType.EnableKeyBindManager, OnEventSetEnable);
        //EventManager.GetInst().AddCustomEvent<bool>(null, EEventType.EnterMap, OnEventSetBattleStatus);
    }

    public void UnRegisterEvent() { }
    //public void RegisterMsg(NetworkCore pClient) { }
    //public void UnRegisterMsg(NetworkCore pClient) { }

    public void Initialize()
    {
        OnEventStartBindKey();
    }

    public void Update()
    {
        if (!m_bEnable)
            return;

        //如果PM是自由模式
        //if (LogicManager.GetLogic<PMManager>().FreeCam)
        //    return;

        //if (UIKeepDropItem.IsKeepDrag)
        //    return;

        //if (UICamera.inputHasFocus)
        //{
        //    ProcessKeyFocusEvent();
        //    return;
        //}


        //if (UIInput.bCustomSelected)
        //{
        //    ProcessKeyFocusEvent();
        //    return;
        //}

        //if (DebugPanelManager.InputHasFocus)
        //    return;

        m_lstCurrentKeyFire.Clear();

        //获取一个绑定操作
        BindKeyCombind(m_lstCurrentKeyFire, m_lstKeyFireOne);
        //获取第二个绑定操作
        BindKeyCombind(m_lstCurrentKeyFire, m_lstKeyFireTwo);

        //触发事件
        Invoke(m_lstCurrentKeyFire);
    }

    public void ProcessKeyFocusEvent()
    {
        m_lstCurrentKeyFire.Clear();

        //获取一个绑定操作
        BindKeyCombind(m_lstCurrentKeyFire, m_lstInputKeyFireOne);
        //获取第二个绑定操作
        BindKeyCombind(m_lstCurrentKeyFire, m_lstInputKeyFireTwo);

        //触发事件
        Invoke(m_lstCurrentKeyFire);
    }

    public void Release() { }

    private void BindClear()
    {
        m_dicKeyBind.Clear();
    }

    public void OnEventBindKey()
    {

        OnEventSetBattleStatus(true);
    }

    public void OnEventStartBindKey()
    {
        BindClear();

        ////同一操作的权重由高到低触发事件，高权重的事件触发了，低权重的事件就被屏蔽
        ////根据事件绑定返回bool值为true代表这个事件类型触发了，否则继续遍历权重，直到较高权重的事件触发，屏蔽低权重的事件
        AddKeyBind(KeyCode.M, EEventType.InputManager_MouseRightClick, EPriority.HeroOther);
        //AddKeyBind(KeyCode.Mouse0, EEventType.InputManager_Url_Item_Left_Click, EPriority.UI);
        //AddKeyBind(KeyCode.Mouse1, EEventType.InputManager_Url_Item_Right_Click, EPriority.UI);
        //AddKeyBind(KeyCode.Mouse1, EEventType.InputManager_Cancel_Cursor_State, EPriority.UI);
        //AddKeyBind(KeyCode.Mouse1, EEventType.InputManager_Hero_RightClick, EPriority.Hero_RightClick, EKeyClick.Down, ELimitCon.ExceptUI);

        //AddKeyBind(KeyCode.Mouse0, EEventType.InputManager_Pick_Up_DropObject, EPriority.Hero_PickObject, EKeyClick.Down, ELimitCon.ExceptUI);
        //AddKeyBind(KeyCode.Mouse0, EEventType.InputManager_Hero_LeftClick, EPriority.Hero_LeftClick, EKeyClick.Down, ELimitCon.ExceptUI);

        //AddKeyBind(KeyCode.Mouse0, EEventType.InputManager_Get_ItemInfo, EPriority.GetItemUrl, EKeyClick.Down, ELimitCon.OnUIInCludeChatArea, KeyCode.LeftControl, EKeyClick.Down);
        //AddKeyBind(KeyCode.Mouse0, EEventType.InputManager_Get_ItemInfo, EPriority.GetItemUrl, EKeyClick.Down, ELimitCon.OnUIInCludeChatArea, KeyCode.LeftControl, EKeyClick.Keep);
        //AddKeyBind(KeyCode.Mouse0, EEventType.InputManager_Get_ItemInfo, EPriority.GetItemUrl, EKeyClick.Down, ELimitCon.OnUIInCludeChatArea, KeyCode.LeftControl, EKeyClick.Up);

        ////同权重的事件同时触发
        //AddKeyBind(KeyCode.Mouse0, EEventType.InputManager_Hero_Shift_LeftClick, EPriority.Hero_Shift_Click, EKeyClick.Down, ELimitCon.ExceptUI, KeyCode.LeftShift, EKeyClick.Down);
        //AddKeyBind(KeyCode.Mouse0, EEventType.InputManager_Hero_Shift_LeftClick, EPriority.Hero_Shift_Click, EKeyClick.Down, ELimitCon.ExceptUI, KeyCode.LeftShift, EKeyClick.Keep);
        //AddKeyBind(KeyCode.Mouse0, EEventType.InputManager_Hero_Shift_LeftClick, EPriority.Hero_Shift_Click, EKeyClick.Down, ELimitCon.ExceptUI, KeyCode.LeftShift, EKeyClick.Up);


        //AddKeyBind(KeyCode.V, EEventType.InputManager_Hero_Path_Show, EPriority.HeroOther);
        //AddKeyBind(KeyCode.P, EEventType.InputManager_Show_Coordinate, EPriority.HeroOther);
        ////快捷键开启debug输出模式
        //AddKeyBind(KeyCode.D, EEventType.InputManager_DebugMode, EPriority.HeroOther);
        //AddKeyBind(KeyCode.F12, EEventType.InputManager_Screen_Shot, EPriority.HeroOther);

        //AddKeyBind(KeyCode.Escape, EEventType.InputManager_Hero_Esc, EPriority.HeroEsc);

        //AddKeyBind(KeyCode.Mouse0, EEventType.InputManager_Close_Self, EPriority.Close_Self);
        //AddKeyBind(KeyCode.Mouse1, EEventType.InputManager_Close_Self, EPriority.Close_Self);

        //AddKeyBind(KeyCode.LeftAlt, EEventType.InputManager_Change_Tip_Item_Show, EPriority.UI, EKeyClick.Down);
        //AddKeyBind(KeyCode.LeftAlt, EEventType.InputManager_Reset_Tip_Item_Show, EPriority.UI, EKeyClick.Up);
        //AddKeyBind(KeyCode.RightAlt, EEventType.InputManager_Change_Tip_Item_Show, EPriority.UI, EKeyClick.Down);
        //AddKeyBind(KeyCode.RightAlt, EEventType.InputManager_Reset_Tip_Item_Show, EPriority.UI, EKeyClick.Up);


        ////input 锁定条件下，还需要监听的事件
        //AddInputKeyBind(KeyCode.Mouse0, EEventType.InputManager_Get_ItemInfo, EPriority.GetItemUrl, EKeyClick.Down, ELimitCon.OnUIInCludeChatArea, KeyCode.LeftControl, EKeyClick.Down);
        //AddInputKeyBind(KeyCode.Mouse0, EEventType.InputManager_Get_ItemInfo, EPriority.GetItemUrl, EKeyClick.Down, ELimitCon.OnUIInCludeChatArea, KeyCode.LeftControl, EKeyClick.Keep);
        //AddInputKeyBind(KeyCode.Mouse0, EEventType.InputManager_Get_ItemInfo, EPriority.GetItemUrl, EKeyClick.Down, ELimitCon.OnUIInCludeChatArea, KeyCode.LeftControl, EKeyClick.Up);

        //AddInputKeyBind(KeyCode.Mouse0, EEventType.InputManager_Cutstom_Select, EPriority.UI);
    }

    private void OnEventSetBattleStatus(bool bEnter)
    {
        OnEventStartBindKey();

        m_bBattleStatus = bEnter;

        //if (m_bBattleStatus)
        //{
        //    var ConfigData = ConfigMgr.GetInst().GetConfig<ShortcutLoader>().datas;
        //    var SaveData = GameSetting.GetInst().LstKeySettingDatas;

        //    if (SaveData == null || SaveData.Count == 0)
        //    {
        //        KeyBindByShortloaderData(ConfigMgr.GetInst().GetConfig<ShortcutLoader>().datas);
        //        GameSetting.GetInst().LstKeySettingDatas = ConfigMgr.GetInst().GetConfig<ShortcutLoader>().datas;
        //    }
        //    else
        //    {
        //        var newDatas = new List<ShortcutLoader.Data>();

        //        foreach (var data in ConfigData)
        //        {
        //            var saveDataAvaliable = SaveData.Find(t => t.strEvent == data.strEvent);

        //            if (saveDataAvaliable != null)
        //            {
        //                BindCustomKey(saveDataAvaliable);
        //                newDatas.Add(saveDataAvaliable);
        //            }
        //            else
        //            {
        //                BindCustomKey(data);
        //                newDatas.Add(data);
        //            }
        //        }

        //        GameSetting.GetInst().LstKeySettingDatas = newDatas;
        //    }

        //    GameSetting.GetInst().SaveGameSet();
        //}
    }

    private void OnEventSetEnable(bool bEnable)
    {
        m_bEnable = bEnable;
    }

    //private void KeyBindByShortloaderData(List<ShortcutLoader.Data> lstData)
    //{
    //    if (lstData == null || lstData.Count <= 0)
    //        return;

    //    for (int i = 0; i < lstData.Count; i++)
    //    {
    //        BindCustomKey(lstData[i]);
    //    }
    //}

    //private void BindCustomKey(ShortcutLoader.Data data)
    //{
    //    if (data == null) return;

    //    try
    //    {
    //        EEventType et = (EEventType)Enum.Parse(typeof(EEventType), data.strEvent);
    //        KeyCode key1 = (KeyCode)Enum.Parse(typeof(KeyCode), data.Key1);
    //        KeyCode key2 = (KeyCode)Enum.Parse(typeof(KeyCode), data.Key2);
    //        EKeyClick ec = (EKeyClick)Enum.Parse(typeof(EKeyClick), data.strEKeyClick);
    //        EPriority ep = (EPriority)Enum.Parse(typeof(EPriority), data.strEpriority);
    //        ELimitCon el = (ELimitCon)Enum.Parse(typeof(ELimitCon), data.strELimitCon);
    //        EKeyClick keyClickAdd = (EKeyClick)Enum.Parse(typeof(EKeyClick), data.strEKeyClick2);
    //        KeyCode keyCodeAdd = (KeyCode)Enum.Parse(typeof(KeyCode), data.strKeycode2);

    //        AddKeyBind(key1, et, ep, ec, el, keyCodeAdd, keyClickAdd);
    //        AddKeyBind(key2, et, ep, ec, el, keyCodeAdd, keyClickAdd);

    //        //如果改了跳跃的快捷键 同时影响组合键
    //        if (et == EEventType.InputManager_Hero_CtrlUp)
    //        {
    //            if (key1 != KeyCode.None)
    //            {
    //                AddKeyBind(KeyCode.Mouse0, EEventType.InputManager_Hero_Ctrl_LeftClick, EPriority.Hero_Ctrl_LeftClick, EKeyClick.Down, ELimitCon.ExceptUI, key1, EKeyClick.Down);
    //                AddKeyBind(KeyCode.Mouse0, EEventType.InputManager_Hero_Ctrl_LeftClick, EPriority.Hero_Ctrl_LeftClick, EKeyClick.Down, ELimitCon.ExceptUI, key1, EKeyClick.Keep);
    //            }
    //            if (key2 != KeyCode.None)
    //            {
    //                AddKeyBind(KeyCode.Mouse0, EEventType.InputManager_Hero_Ctrl_LeftClick, EPriority.Hero_Ctrl_LeftClick, EKeyClick.Down, ELimitCon.ExceptUI, key2, EKeyClick.Down);
    //                AddKeyBind(KeyCode.Mouse0, EEventType.InputManager_Hero_Ctrl_LeftClick, EPriority.Hero_Ctrl_LeftClick, EKeyClick.Down, ELimitCon.ExceptUI, key2, EKeyClick.Keep);
    //            }
    //        }
    //    }
    //    catch (System.Exception ex)
    //    {
    //        MyLog.Log("KeyBindByShortloaderData ex: " + ex);
    //    }
    //}


    private void BindKeyCombind(List<KeyFire> currentKeyFire, List<KeyFire> lstKey)
    {
        int nCount = lstKey.Count;
        for (int i = 0; i < nCount; i++)
        {
            KeyFire keyFire = lstKey[i];

            if (keyFire.Count > 0)
            {
                m_bCurrentFire = true;
                for (int j = 0, jCount = keyFire.Count; j < jCount; j++)
                {
                    KeyHandle keyHandle = keyFire.GetKeyHandleByIndex(j);
                    if (keyHandle == null)
                    {
                        m_bCurrentFire = false;
                        break;
                    }

                    if (Input.GetKeyDown(keyHandle.eKeyCode))
                    {
                        if (keyHandle.eKeyClick != EKeyClick.Down)
                        {
                            m_bCurrentFire = false;
                            break;
                        }

                        continue;
                    }

                    if (Input.GetKeyUp(keyHandle.eKeyCode))
                    {
                        if (keyHandle.eKeyClick != EKeyClick.Up)
                        {
                            m_bCurrentFire = false;
                            break;
                        }

                        continue;
                    }

                    if (Input.GetKey(keyHandle.eKeyCode))
                    {
                        if (keyHandle.eKeyClick != EKeyClick.Keep)
                        {
                            m_bCurrentFire = false;
                            break;
                        }

                        continue;
                    }

                    m_bCurrentFire = false;
                }

                if (m_bCurrentFire)
                {
                    currentKeyFire.Add(keyFire);
                }
            }
        }
    }

    private void Invoke(List<KeyFire> currentKeyFire)
    {
        if (currentKeyFire.Count <= 0)
        {
            return;
        }

        bool bMouseOperate = false;

        //排序权重高到低
        m_lstInvokeEvent.Clear();
        for (int i = 0, count = currentKeyFire.Count; i < count; i++)
        {
            if (currentKeyFire[i].IsMouseOperate)
            {
                bMouseOperate = true;
            }

            if (m_dicKeyBind.ContainsKey(currentKeyFire[i]))
            {
                m_lstInvokeEvent.AddRange(m_dicKeyBind[currentKeyFire[i]]);
            }
        }

        m_lstInvokeEvent.Sort(WidgetSort);

        //跳出循环的条件是  1.sameWidget被设置，表示事件处理成功了
        //                  2.sameWidget同权重的事件都处理了
        int sameWidget = -1;
        for (int i = 0, count = m_lstInvokeEvent.Count; i < count; i++)
        {
            EventInfo eventInfo = m_lstInvokeEvent[i];

            //同级权重信息同时触发
            if (-1 != sameWidget && sameWidget != eventInfo.weight)
            {
                break;
            }

            //bool bNgui = UIManager.GetInst().MouseInUI();
            //bool bInChatArea = UIManager.GetInst().IsMouseInChatArea();
            //bool bCheckCon = true;
            //if (eventInfo.eLimitCon == ELimitCon.OnUI && !bNgui)
            //{
            //    bCheckCon = false;
            //}
            //else if (eventInfo.eLimitCon == ELimitCon.OnUIInCludeChatArea && !bNgui && !bInChatArea)
            //{
            //    bCheckCon = false;
            //}
            //else if (eventInfo.eLimitCon == ELimitCon.ExceptUI && bNgui)
            //{
            //    bCheckCon = false;
            //}

            //if (bCheckCon)
            {
                //触发事件 决定是否事件传递
                if (InputEventHandler.SendEvent(eventInfo.eEventType))
                {
                    //只要有鼠标左右键的操作触发，都需要取消当前的鼠标状态
                    if (bMouseOperate)
                    {
                        //InputEventHandler.SendEvent(EEventType.InputManager_Cancel_Cursor_State);
                    }

                    //同级权重信息设置
                    if (-1 == sameWidget)
                    {
                        sameWidget = eventInfo.weight;
                    }
                }
            }
        }
    }

    private int WidgetSort(EventInfo a, EventInfo b)
    {
        return a.weight > b.weight ? -1 : 1;
    }


    private void AddInputKeyBind(KeyCode keyCode1, EEventType eventType, EPriority widget,
                        EKeyClick keyClick1 = EKeyClick.Down, ELimitCon effectTarget = ELimitCon.None,
                        KeyCode keyCode2 = KeyCode.None, EKeyClick keyClick2 = EKeyClick.Down)
    {
        if (keyCode1 == KeyCode.None)
            return;

        if (eventType > EEventType.InputManager_Event_End || eventType < EEventType.InputManager_Event_Start)
            return;

        KeyFire keyFire = new KeyFire();
        if (keyCode2 != KeyCode.None)
        {
            keyFire.AddKeyHandle(keyCode1, keyClick1);
            keyFire.AddKeyHandle(keyCode2, keyClick2);
            m_lstInputKeyFireTwo.Add(keyFire);
        }
        else
        {
            keyFire.AddKeyHandle(keyCode1, keyClick1);
            m_lstInputKeyFireOne.Add(keyFire);
        }

        if (!m_dicKeyBind.ContainsKey(keyFire))
        {
            List<EventInfo> lstEvent = new List<EventInfo>();

            EventInfo eventInfo = new EventInfo();
            eventInfo.eLimitCon = effectTarget;
            eventInfo.eEventType = eventType;
            eventInfo.weight = (int)widget;
            lstEvent.Add(eventInfo);

            m_dicKeyBind.Add(keyFire, lstEvent);
        }
        else
        {
            List<EventInfo> lstEvent = m_dicKeyBind[keyFire];
            EventInfo eventInfo = lstEvent.Find(info => info.eEventType == eventType);
            if (eventInfo == null)
            {
                eventInfo = new EventInfo();
                eventInfo.eEventType = eventType;
                eventInfo.eLimitCon = effectTarget;
                eventInfo.weight = (int)widget;
                lstEvent.Add(eventInfo);
            }

            m_dicKeyBind[keyFire] = lstEvent;
        }
    }


    private void AddKeyBind(KeyCode keyCode1, EEventType eventType, EPriority widget,
                            EKeyClick keyClick1 = EKeyClick.Down, ELimitCon effectTarget = ELimitCon.None,
                            KeyCode keyCode2 = KeyCode.None, EKeyClick keyClick2 = EKeyClick.Down)
    {
        if (keyCode1 == KeyCode.None)
            return;

        if (eventType > EEventType.InputManager_Event_End || eventType < EEventType.InputManager_Event_Start)
            return;

        KeyFire keyFire = new KeyFire();
        if (keyCode2 != KeyCode.None)
        {
            keyFire.AddKeyHandle(keyCode1, keyClick1);
            keyFire.AddKeyHandle(keyCode2, keyClick2);
            m_lstKeyFireTwo.Add(keyFire);
        }
        else
        {
            keyFire.AddKeyHandle(keyCode1, keyClick1);
            m_lstKeyFireOne.Add(keyFire);
        }

        if (!m_dicKeyBind.ContainsKey(keyFire))
        {
            List<EventInfo> lstEvent = new List<EventInfo>();

            EventInfo eventInfo = new EventInfo();
            eventInfo.eLimitCon = effectTarget;
            eventInfo.eEventType = eventType;
            eventInfo.weight = (int)widget;
            lstEvent.Add(eventInfo);

            m_dicKeyBind.Add(keyFire, lstEvent);
        }
        else
        {
            List<EventInfo> lstEvent = m_dicKeyBind[keyFire];
            EventInfo eventInfo = lstEvent.Find(info => info.eEventType == eventType);
            if (eventInfo == null)
            {
                eventInfo = new EventInfo();
                eventInfo.eEventType = eventType;
                eventInfo.eLimitCon = effectTarget;
                eventInfo.weight = (int)widget;
                lstEvent.Add(eventInfo);
            }

            m_dicKeyBind[keyFire] = lstEvent;
        }
    }
}
