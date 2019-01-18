using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestUI : BaseMediator
{
    Text m_hp;
    Text m_mp;
    Text m_attack;
    Text m_defend;
    Button m_close;

    public override void InitElement()
    {
        base.InitElement();
        m_hp = GetElement("(Text)hp") as Text;
        m_mp = GetElement("(Text)mp") as Text;
        m_attack = GetElement("(Text)attack") as Text;
        m_defend = GetElement("(Text)defend") as Text;
        m_close = GetElement("(Button)close") as Button;
        m_close.onClick.AddListener(Close);
    }

    public override void OnOpen()
    {
        base.OnOpen();
        Refresh();
    }

    public override void Close()
    {
        base.Close();
    }

    private void Refresh()
    {
        m_hp.text = SingletonObject<Hero>.Instance.GetAttr(EActorAttr.HP).Value.ToString();
        m_mp.text = SingletonObject<Hero>.Instance.GetAttr(EActorAttr.MP).Value.ToString();
        m_attack.text = SingletonObject<Hero>.Instance.GetAttr(EActorAttr.PhysicalAttack).Value.ToString();
        m_defend.text = SingletonObject<Hero>.Instance.GetAttr(EActorAttr.PhysicalDefence).Value.ToString();
    }
}
