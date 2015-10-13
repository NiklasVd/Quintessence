using UnityEngine;
using System.Collections;
using System;

public abstract class Entity : MonoBehaviour
{
    public string permanentId = Guid.NewGuid().ToString();

    public virtual void OnWriteSaveStream()
    {

    }
    public virtual void OnReadSaveStream()
    {

    }

    protected virtual void Awake()
    {

    }
    protected virtual void Start()
    {

    }
    protected virtual void Update()
    {

    }
    protected virtual void OnDestroy()
    {

    }
}
