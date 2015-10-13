using UnityEngine;
using System.Collections;
using System;

public abstract class Action : ScriptableObject
{
    public string permanentId = Guid.NewGuid().ToString();

    public ActionCastTypes castTypeFlags;
    public ActionCastTargets castTargetFlags;

    protected virtual bool CanCast(Actor caster, ActionCastParameters p)
    {
        if (!HasCastFlags(ActionCastTypes.Active))
        {
            return false;
        }

        #region Targets
        if (HasTargetFlags(ActionCastTargets.None))
        {
            return true;
        }

        if (HasTargetFlags(ActionCastTargets.Actors) &&
            p.targetActor == null)
        {
            return false;
        }

        if (HasTargetFlags(ActionCastTargets.FriendlyActors) &&
            p.targetActor.team != caster.team)
        {
            return false;
        }
        else if (HasTargetFlags(ActionCastTargets.EnemyActors) &&
            p.targetActor.team == caster.team)
        {
            return false;
        }
        #endregion

        return true;
    }

    private bool HasCastFlags(ActionCastTypes flag)
    {
        return (castTypeFlags & flag) == flag;
    }
    private bool HasTargetFlags(ActionCastTargets flag)
    {
        return (castTargetFlags & flag) == flag;
    }
}

[Flags, Serializable]
public enum ActionCastTypes
{
    Active = 1 << 0,
    Passive = 1 << 1,
    Mixed = Active | Passive
}

[Flags, Serializable]
public enum ActionCastTargets
{
    None = 0,
    Location = 1 << 2 | 1 << 3,

    FriendlyActors = 1 << 2,
    EnemyActors = 1 << 3,
    Actors = FriendlyActors | EnemyActors,
}

public class ActionCastParameters
{
    public readonly Vector3 targetPosition;
    public readonly Actor targetActor;

    public ActionCastParameters(Vector3 targetPosition = default(Vector3),
        Actor targetActor = null)
    {
        this.targetPosition = targetPosition;
        this.targetActor = targetActor;
    }
}
