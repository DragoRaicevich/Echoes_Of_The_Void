using UnityEngine;

public class MainButtonController : MonoBehaviour
{
    [SerializeField] private bool isActivated = false;
    [SerializeField] private DoorController DoorController;
    public bool IsActivated { get => isActivated; set => isActivated = value; }

    public void ActivateDoor()
    {
        if(isActivated == true)
        {
            DoorController.UnlockDoor();
        }
    }

}
