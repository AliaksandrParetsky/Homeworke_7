using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public enum Direction
    {
        Up,
        Down
    }

    [SerializeField] private Direction direction;

    public static event Action<Direction> triggerEvent;

    private bool firstPass = true;

    private void OnTriggerEnter(Collider other)
    {
        if (direction == Direction.Up)
        {
            if (firstPass)
            {
                triggerEvent?.Invoke(Direction.Up);
                firstPass = false;
            }
        }
        if(direction == Direction.Down)
        {
            if (firstPass)
            {
                triggerEvent?.Invoke(Direction.Down);
                firstPass = false;
            }
        }
    }
}
