using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] MovementComponent movementComponent;
    
    [SerializeField] Light flashligh;

    private bool isActiv = true;

    private void OnEnable()
    {
        InputController.movementEvent += InputController_movementEvent;
        InputController.flashlightEvent += InputController_flashlightEvent;
    }

    private void InputController_flashlightEvent()
    {
        if(isActiv)
        {
            flashligh.enabled = false;
            isActiv = false;
        }
        else
        {
            flashligh.enabled = true;
            isActiv = true;
        }
    }

    private void InputController_movementEvent(Vector2 input)
    {
        movementComponent.SetInputDirection(input);
    }

    private void OnDisable()
    {
        InputController.movementEvent -= InputController_movementEvent;
        InputController.flashlightEvent -= InputController_flashlightEvent;
    }
}
