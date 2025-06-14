using UnityEngine;

public class SuitPickup : MonoBehaviour
{
    private bool isCollected = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!isCollected && other.CompareTag("Player"))
        {
            isCollected = true;
            FindObjectOfType<SurvivalManager>().PutOnSuit();
            gameObject.SetActive(false); // Oculta el traje
        }
    }
}
