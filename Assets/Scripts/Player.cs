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

        bool canMove = !Physics.CapsuleCast(
            transform.position, transform.position + Vector3.up * 2f, 1f, moveDirection, moveSpeed * Time.deltaTime);


        /*
            Check if the player can move in the direction of the input.
            If the player can't move in the direction of the input, try to move on the X axis.
            If the player can't move on the X axis, try to move on the Z axis.
            If the player can't move on the Z axis, don't move.
        */
        if (!canMove)
        {
            float playerHeight = 2f;
            float playerRadius = 1f;
            float maxDistance = moveSpeed * Time.deltaTime;

            // Attempt on X axis
            Vector3 moveDirectionX = new Vector3(input.x, 0, 0).normalized;

            canMove = !Physics.CapsuleCast(
                    transform.position, 
                    transform.position + Vector3.up * playerHeight, 
                    playerRadius,
                    moveDirectionX, 
                    maxDistance
                    );

            if (canMove)
            {
                transform.position += moveDirectionX * moveSpeed * Time.deltaTime;
            }
            else
            {
                // Attempt on Z axis
                Vector3 moveDirectionZ = new Vector3(0, 0, input.y).normalized;

                canMove = !Physics.CapsuleCast(
                        transform.position,
                        transform.position + Vector3.up * playerHeight,
                        playerRadius,
                        moveDirectionZ,
                        maxDistance
                        );

                if (canMove)
                {
                    transform.position += moveDirectionZ * moveSpeed * Time.deltaTime;
                }
            }
        }
        else
        {
            transform.position += moveDirection * moveSpeed * Time.deltaTime;
        }


        // Rotate the player
        transform.forward =
            Vector3.Slerp(transform.forward, moveDirection, rotationSpeed * Time.deltaTime);


        // Check if the player is walking
        isWalking = moveDirection != Vector3.zero;


    }

    public bool IsWalking() => isWalking;
}
