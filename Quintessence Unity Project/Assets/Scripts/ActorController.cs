using UnityEngine;
using System.Collections;

public abstract class ActorController : MonoBehaviour
{
    protected Actor Actor
    {
        get;
        private set;
    }

    protected virtual void Awake()
    {
        Actor = GetComponent<Actor>();
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
