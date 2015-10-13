using UnityEngine;
using System.Collections;

public class PlayerActorController : StandardActorController
{
    protected override void Update()
    {
        UpdateMovementInput();
        base.Update();
    }

    private void UpdateMovementInput()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");

        var position = Actor.transform.position;
        position.x += horizontal * Time.deltaTime;

        var localScale = Actor.transform.localScale;
        localScale.x *= !Mathf.Approximately(horizontal, 0) ?
            horizontal : 1;
        Actor.transform.localScale = localScale;
    }
}
