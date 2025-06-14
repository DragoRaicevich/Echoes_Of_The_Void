using UnityEngine;

public class PowerButtonInteractable : MonoBehaviour
{
    public GameObject interactText;
    public GameObject puerta; // Asigna la puerta que se abrirá
    private bool playerInRange = false;
    private PlayerInputReader inputReader;

    private void Start()
    {
        inputReader = Object.FindFirstObjectByType<PlayerInputReader>();
    }

    private void Update()
    {
        if (playerInRange && inputReader != null && inputReader.InteractPressed)
        {
            Debug.Log("¡Botón activado!");

            // Aquí colocas lo que debe pasar al activar el botón
            if (puerta != null)
                puerta.SetActive(false); // o animación, etc.

            if (interactText != null)
                interactText.SetActive(false);

            playerInRange = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            if (interactText != null)
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

