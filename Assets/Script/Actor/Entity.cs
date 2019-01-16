using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity
{
    private uint m_uId;
    private string m_strName;

    public uint Id
    {
        get
        {
            return m_uId;
        }

        set
        {
            m_uId = value;
        }
    }

    public string Name
    {
        get
        {
            return m_strName;
        }

        set
        {
            m_strName = value;
        }
    }

    public Entity()
    {
        //Initialize();
    }

    public virtual void Initialize()
    {

    }

    public virtual void Update()
    {

    }

    public virtual void FixedUpdate()
    {

    }

    public virtual void Release()
    {

    }
}
