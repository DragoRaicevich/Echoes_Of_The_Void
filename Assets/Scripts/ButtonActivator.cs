using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class ButtonActivator : MonoBehaviour
{
    public GameObject[] doorsToUnlock;
    public Light pointLight;

    [Header("Puzzle UI")]
    public GameObject codePanel;              // Panel UI
    public TMP_InputField codeInputField;     // Campo de ingreso
    public string correctCode = "042";        // Código correcto

    private bool isActivated = false;
    private bool playerInside = false;
    private bool isEnteringCode = false;

    private PlayerInputActions inputActions;

    void Awake()
    {
        inputActions = new PlayerInputActions();

        if (pointLight == null)
            pointLight = GetComponentInChildren<Light>();

        if (codePanel != null)
            codePanel.SetActive(false); // Ocultar panel al inicio
    }

    void OnEnable()
    {
        inputActions.Enable();
        inputActions.Player.Interact.performed += OnInteract;
    }

    void OnDisable()
    {
        inputActions.Player.Interact.performed -= OnInteract;
        inputActions.Disable();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = false;
            CloseCodePanel();
        }
    }

    private void OnInteract(InputAction.CallbackContext context)
    {
        if (isActivated) return;

        if (isEnteringCode)
        {
            CheckCode(); // Confirmar código con E
            return;
        }

        if (!playerInside) return;

        // Mostrar panel para ingresar código
        OpenCodePanel();
    }

    private void OpenCodePanel()
    {
        if (codePanel != null)
        {
            codePanel.SetActive(true);
            codeInputField.text = "";
            codeInputField.ActivateInputField();
            isEnteringCode = true;
        }
    }

    private void CloseCodePanel()
    {
        if (codePanel != null)
            codePanel.SetActive(false);

        isEnteringCode = false;
    }

    private void CheckCode()
    {
        if (codeInputField.text == correctCode)
        {
            ActivateButton();
            CloseCodePanel();
        }
        else
        {
            Debug.Log("Código incorrecto");
        }
    }

    private void ActivateButton()
    {
        isActivated = true;
        Debug.Log("Puzzle resuelto: botón activado");

        if (pointLight != null)
            pointLight.color = Color.green;

        foreach (GameObject door in doorsToUnlock)
        {
            DoorController controller = door.GetComponent<DoorController>();
            if (controller != null)
                controller.UnlockDoor();
        }
    }
}
