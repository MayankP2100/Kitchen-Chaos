using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Variables
    [SerializeField] float moveSpeed = 8f;
    [SerializeField] float rotationSpeed = 10f;
    [SerializeField] GameInput gameInput;

    private bool isWalking = false;

    private void Update()
    {
        // Get the movement input from the player
        Vector2 input = gameInput.GetMovementVectorNormazlized();

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
