using UnityEngine;

public class WireSocket : MonoBehaviour
{
    [SerializeField] private int wireSocketID;

    public int WireSocketID { get => wireSocketID; }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("OnTriggerEnter2D: " + collision.name);
    }
}
