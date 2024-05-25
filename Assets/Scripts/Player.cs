using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed = 8f;
    [SerializeField] float rotationSpeed = 10f;

    bool isWalking = false;

    private void Update()
    {
        // Get the input from the player
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

        // Normalize the input vector so that the player moves at the same speed in all directions
        input.Normalize();

        // Move the player
        Vector3 moveDirection = new Vector3(input.x, 0, input.y);
        transform.position += moveDirection * moveSpeed * Time.deltaTime;

        // Rotate the player
        transform.forward = 
            Vector3.Slerp(transform.forward, moveDirection, rotationSpeed * Time.deltaTime);

        // Check if the player is walking
        isWalking = moveDirection != Vector3.zero;
    }

    public bool IsWalking() => isWalking;
}
