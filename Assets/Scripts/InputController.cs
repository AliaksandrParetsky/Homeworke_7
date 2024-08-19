using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour, GameControls.IPlayerInputActions
{
    private GameControls gameControls;

    public static event Action<Vector2> movementEvent;
    public static event Action<Vector2> mouseXYEvent;
    public static event Action flashlightEvent;

    private void OnEnable()
    {
        if (gameControls == null)
        {
            gameControls = new GameControls();
            gameControls.Enable();
            gameControls.PlayerInput.SetCallbacks(this);
        }
    }

    public void OnMovement(InputAction.CallbackContext context)
    {
        movementEvent?.Invoke(context.ReadValue<Vector2>());
    }

    public void OnMouseXY(InputAction.CallbackContext context)
    {
        mouseXYEvent?.Invoke(context.ReadValue<Vector2>());
    }

    public void OnFlashlight(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
        {
            flashlightEvent?.Invoke();
        }
    }

    private void OnDisable()
    {
        if(gameControls != null)
        {
            gameControls.Disable();
            gameControls.PlayerInput.RemoveCallbacks(this);
        }
    }
}
