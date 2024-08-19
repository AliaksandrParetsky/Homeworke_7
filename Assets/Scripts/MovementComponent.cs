using System;
using UnityEngine;

public class MovementComponent : MonoBehaviour
{
    private CharacterController characterController;
    public CharacterController CharacterController
    {
        get { return characterController = characterController ?? GetComponent<CharacterController>(); }
    }

    [SerializeField] private float speed;

    [SerializeField] AudioMovement audioMovement;

    private Vector2 direction;

    private float gravity = -9.81f;

    private bool first = true;

    private void Update()
    {
        Vector3 movement = new Vector3(direction.x, 0, direction.y);

        movement = Vector3.ClampMagnitude(movement, speed);
        movement.y = gravity;

        movement = transform.TransformDirection(movement);
        CharacterController.Move(movement * (speed * Time.deltaTime));
    }

    public void SetInputDirection(Vector2 dir)
    {
        direction = dir;

        if (dir == Vector2.zero)
        {
            audioMovement.StopAudio();

            first = true;
        }
        if(dir.magnitude > 0.0f)
        {
            if (first)
            {
                audioMovement.PlayAudio();

                first = false;
            }
        }
    }
}
