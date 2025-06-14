using UnityEngine;
using UnityEngine.InputSystem;

public class MouseLook : MonoBehaviour
{
    [SerializeField] private Transform playerBody;  // Asigna el transform del cuerpo del jugador
    [SerializeField] private float mouseSensitivity = 100f;

    private float xRotation = 0f;
    private Vector2 lookInput;

    public void OnLook(InputAction.CallbackContext context)
    {
        lookInput = context.ReadValue<Vector2>();
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // Oculta y bloquea el cursor en el centro
    }

    private void Update()
    {
        float mouseX = lookInput.x * mouseSensitivity * Time.deltaTime;
        float mouseY = lookInput.y * mouseSensitivity * Time.deltaTime;

        // Rota hacia arriba/abajo (limitado)
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // Rota el cuerpo del jugador
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
