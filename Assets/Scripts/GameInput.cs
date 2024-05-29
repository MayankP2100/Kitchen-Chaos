using System;
using UnityEngine;

public class GameInput : MonoBehaviour
{
    public event EventHandler OnInteractAction;

    private PlayerInput playerInput;

    private void Awake()
    {
        playerInput = new PlayerInput();
        playerInput.Player.Enable();

        // Subscribe to the Interact event
        playerInput.Player.Interact.performed += Interact_performed;
    }

    private void Interact_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        // This will call all the methods that are subscribed to the event.
        // ? is a null check operator. If OnInteractAction is not null, then call it.
        OnInteractAction?.Invoke(this, EventArgs.Empty);
    }

    public Vector2 GetMovementVectorNormazlized()
    {
        // Read the input value from the player input
        Vector2 inputVector = playerInput.Player.Move.ReadValue<Vector2>();

        return inputVector;
    }
}
