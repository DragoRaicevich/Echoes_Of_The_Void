using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputReader : MonoBehaviour
{
    private PlayerInputActions inputActions;

    public bool InteractPressed { get; private set; }

    private void Awake()
    {
        inputActions = new PlayerInputActions();
        inputActions.Player.Enable();

        inputActions.Player.Interact.performed += ctx => InteractPressed = true;
    }

    private void LateUpdate()
    {
        // Resetea para que solo se dispare una vez por frame
        InteractPressed = false;
    }

    private void OnEnable()
    {
        inputActions?.Enable();
    }

    private void OnDisable()
    {
        inputActions?.Disable();
    }
}
