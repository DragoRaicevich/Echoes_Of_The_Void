using UnityEngine;
using UnityEngine.InputSystem;

public class PowerButtonInteractable : MonoBehaviour
{
    public GameObject interactText;
    public GameObject puerta; // Asigna la puerta que se abrirá
    private bool playerInRange = false;
    private bool isActivated = false;

    // Se conecta desde el Inspector: componente Player Input del PLAYER,
    // evento de la acción "Interact", igual que PlayerInteractions.Interact.
    public void OnInteract(InputAction.CallbackContext context)
    {
        if (!context.performed || isActivated || !playerInRange) return;

        isActivated = true;
        Debug.Log("¡Botón activado!");

        if (puerta != null)
        {
            DoorController door = puerta.GetComponent<DoorController>();
            if (door != null)
                door.UnlockDoor();
        }

        if (interactText != null)
            interactText.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            if (!isActivated && interactText != null)
                interactText.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            if (interactText != null)
                interactText.SetActive(false);
        }
    }
}

