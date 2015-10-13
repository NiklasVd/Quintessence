using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using System.Collections.Generic;

public class StandardActorController : ActorController
{
    public const string AnimatorMovementIndexParameterName = "Movement Index";
    public Animator animator;

    public Image healthBarImage;
    private float maxHealthBarValue;

    private MovementAnimationType movementAnimType;

    protected override void Awake()
    {
        maxHealthBarValue = healthBarImage.rectTransform.rect.width; // Is this right?
        base.Awake();
    }
    protected override void Update()
    {
        UpdateHealthBar();
        base.Update();
    }

    private void UpdateHealthBar()
    {
        var currentHealth = Actor.attributes[AttributeType.CurrentHealth];
        // TODO: Update the health bar image with the currentHealth value
    }

    private void SetMovement(MovementAnimationType type)
    {
        movementAnimType = type;
        animator.SetInteger(AnimatorMovementIndexParameterName, (int)movementAnimType);
    }
}

[Serializable]
public enum MovementAnimationType
{
    Idle = 0,
    Walk = 1,
    Run = 2,
    Crouch = 3,
    Hit = 4,
}
