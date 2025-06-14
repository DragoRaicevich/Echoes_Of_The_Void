using UnityEngine;

public class DoorController : MonoBehaviour
{
    public float openHeight = 3f; // Altura que sube la puerta
    public float speed = 2f;

    [SerializeField] private bool isUnlocked = false;
    private bool playerNearby = false;
    private bool hasPlayedOpenSound = false;

    private Vector3 closedPosition;
    private Vector3 openPosition;
    private AudioSource audioSource;

    void Start()
    {
        closedPosition = transform.position;
        openPosition = closedPosition + Vector3.up * openHeight;

        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            Debug.LogWarning("No se encontró AudioSource en la puerta.");
        }
    }

    void Update()
    {
        if (!isUnlocked) return;

        Vector3 targetPosition = playerNearby ? openPosition : closedPosition;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
    }

    public void UnlockDoor()
    {
        isUnlocked = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isUnlocked && other.CompareTag("Player"))
        {
            playerNearby = true;

            if (!hasPlayedOpenSound && audioSource != null)
            {
                audioSource.Play();
                hasPlayedOpenSound = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (isUnlocked && other.CompareTag("Player"))
        {
            playerNearby = false;
            hasPlayedOpenSound = false; // Permite que el sonido se reproduzca si vuelve a acercarse
        }
    }
}
