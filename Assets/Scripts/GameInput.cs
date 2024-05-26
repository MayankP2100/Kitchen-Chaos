using UnityEngine;

public class GameInput : MonoBehaviour
{
    private PlayerInput playerInput;

    private void Awake()
    {
        playerInput = new PlayerInput();
        playerInput.Player.Enable();
    }

    public Vector2 GetMovementVectorNormazlized()
    {
        // Read the input value from the player input
        Vector2 inputVector = playerInput.Player.Move.ReadValue<Vector2>();

        return inputVector;
    }
}
