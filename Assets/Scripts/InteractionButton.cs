using UnityEngine;

public class InteractionButton : MonoBehaviour
{
    public GameObject player;
    public GameObject door;
    public float distance = 2f;

    void Update()
    {
        float d = Vector3.Distance(player.transform.position, transform.position);
        if (d <= distance && Input.GetKeyDown(KeyCode.E))
        {
            door.SetActive(false);
        }
    }
}
