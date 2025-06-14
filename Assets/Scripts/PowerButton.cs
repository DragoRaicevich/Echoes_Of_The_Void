using UnityEngine;

public class PowerButton : MonoBehaviour
{
    private bool isActivated = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isActivated)
        {
            isActivated = true;
            Debug.Log("Energía de emergencia activada.");

            // Aquí podrías encender luces, abrir puerta, etc.
            GameObject.Find("ControlRoomDoor").SetActive(false);

            // Mostrar mensaje de IA
            Object.FindFirstObjectByType<OxygenTimer>().objectiveText.text = "IA: Sistema inestable... busca solución.";
        }
    }
}
