using UnityEngine;

public class SuitPickup : MonoBehaviour
{
    private bool isCollected = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!isCollected && other.CompareTag("Player"))
        {
            isCollected = true;
            UIManager.Instance.ShowHelmetHUD();
            gameObject.SetActive(false); // Oculta el traje
        }
    }
}
