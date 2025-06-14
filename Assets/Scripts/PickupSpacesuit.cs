using UnityEngine;

public class PickupSpacesuit : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gameObject.SetActive(false);

            // Activar el temporizador
            OxygenTimer oxygenTimer = Object.FindFirstObjectByType<OxygenTimer>();
            oxygenTimer.StartOxygen();

            // Cambiar objetivo
            oxygenTimer.objectiveText.text = "Objetivo: Activa la energía de emergencia";
        }
    }
}
