using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterStateManager : BaseStateManager
{
    public MonsterStateManager(Actor actor) : base(actor)
    {
        m_lstState.Add(new IdleState(actor));
        m_lstState.Add(new WalkState(actor));
    }
}
