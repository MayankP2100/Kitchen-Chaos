using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInput : MonoBehaviour
{
    public Vector2 GetMovementVectorNormazlized()
    {
        Vector2 input = new Vector2(0, 0);

        // Check if the player is pressing the keys
        if (Input.GetKey(KeyCode.W))
        {
            input.y = 1;
        }

        if (Input.GetKey(KeyCode.S))
        {
            input.y = -1;
        }

        if (Input.GetKey(KeyCode.A))
        {
            input.x = -1;
        }

        if (Input.GetKey(KeyCode.D))
        {
            input.x = 1;
        }

        // Normalize the input vector to prevent faster diagonal movement
        input = input.normalized;

        return input;
    }
}
