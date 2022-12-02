using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputReader : MonoBehaviour, Control.IPlayerActions
{
    public event Action JumpEvent;
    public event Action AttackEvent;
    public event Action SpellEvent;
    public event Action SlideEvent;
    private Control control;

    void Start()
    {
        control = new Control();
        control.Player.SetCallbacks(this);

        control.Player.Enable();
    }

    private void OnDestroy()
    {
        control.Player.Disable();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (!context.performed) return;

        JumpEvent?.Invoke();
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        if (!context.performed) return;

        AttackEvent?.Invoke();
    }

    public void OnSpell(InputAction.CallbackContext context)
    {
        if (!context.performed) return;

        SpellEvent?.Invoke();
    }

    public void OnSlide(InputAction.CallbackContext context)
    {
        if (!context.performed) return;

        SlideEvent?.Invoke();
    }
}
