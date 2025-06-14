using UnityEngine;

public class TriggerTest : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Entró: " + other.name);
    }
}
