using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestUI : BaseMediator
{
    Text m_txtActorState;

    public override void InitElement()
    {
        base.InitElement();
        m_txtActorState = GetElement("(Text)actorState") as Text;
    }

    public override void OnOpen()
    {
        base.OnOpen();
        m_txtActorState.text = SingletonObject<Hero>.Instance.Name;
    }
}
