using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteractions : MonoBehaviour
{
    [SerializeField] private bool canInteract;
    [Header("CORE PUZZLE")]
    private GameObject coreKeyObj;
    [SerializeField] private bool hasCoreKey;
    [SerializeField] private bool isCoreKey;
    private int corePuzzleIndex = -1;

    [Header("WIRING PUZZLE")]
    [SerializeField] 

    [Header("MAIN DOOR")]
    private GameObject wiringKeyObj;
    [SerializeField] private bool hasWiringKey;
    [SerializeField] private bool isWiringKey;
    [SerializeField] private MainButtonController mainButtonController;

    string tagName;
    public void Interact(InputAction.CallbackContext context)
    {
        if (canInteract && tagName == "CoreKey")
        {
            GetCoreKey();
        }

        if (canInteract && tagName == "WiringKey")
        {
            GetWiringKey();
        }

        if (canInteract && (tagName == "CoreEasy" || tagName == "CoreMedium" || tagName == "CoreHard"))
        {
            if (hasCoreKey == true)
            {
                UIManager.Instance.ActivetePuzzleCore(corePuzzleIndex);
            }
            else
            {
                UIManager.Instance.ShowNeedCoreKeyMessage();
            }
        }

        if (canInteract && tagName == "Touchpad")
        {
            UIManager.Instance.ActivateTouchpadPanel();
        }

        if(canInteract && tagName == "WiringPuzzle")
        {
            if (hasWiringKey == true)
            {
                UIManager.Instance.ActivateWiringPuzzlePanel();
            }
            else
            {
                UIManager.Instance.ShowNeedCoreKeyMessage();
            }
        }

        if(canInteract && tagName == "MainButton")
        {
            if (mainButtonController.IsActivated == true)
            {
                mainButtonController.ActivateDoor();
            }
            else
            {
                UIManager.Instance.ShowMainDoorLockedMessage();
            }
        }
    }

    private void GetWiringKey()
    {
        if(isWiringKey == true && canInteract)
        {
            hasWiringKey = true;
            wiringKeyObj.SetActive(false);
            canInteract = false;
            UIManager.Instance.HideInteractionKeyMessage();
            SoundManager.Instance.PlayGeneralSound(1, 0.75f);
            isWiringKey = false;
        }
    }

    private void GetCoreKey()
    {
        if (isCoreKey == true && canInteract)
        {
            hasCoreKey = true;
            coreKeyObj.SetActive(false);
            canInteract = false;
            UIManager.Instance.HideInteractionKeyMessage();

            SoundManager.Instance.PlayGeneralSound(1, 0.75f);
            isCoreKey = false;
        }
    }

    private void OnTriggerEnter(Collider tri)
    {
        tagName = tri.tag;
        switch (tagName)
        {
            case "CoreEasy":
                corePuzzleIndex = 0;
                UIManager.Instance.ShowInteractionKeyMessage();
                canInteract = true;

                break;
            case "CoreMedium":
                corePuzzleIndex = 1;
                UIManager.Instance.ShowInteractionKeyMessage();
                canInteract = true;

                break;
            case "CoreHard":
                corePuzzleIndex = 2;
                UIManager.Instance.ShowInteractionKeyMessage();
                canInteract = true;

                break;
            case "Touchpad":
                canInteract = true;
                UIManager.Instance.ShowInteractionKeyMessage();
                break;
            default:
                Debug.Log("Otro Tag:" + tri.name);
                break;
        }

        if (tagName == "CoreKey")
        {
            canInteract = true;
            isCoreKey = true;
            coreKeyObj = tri.gameObject;
            UIManager.Instance.ShowInteractionKeyMessage();
        }

        if (tagName == "WiringKey") 
        {
            canInteract = true;
            isWiringKey = true;
            wiringKeyObj = tri.gameObject;
            UIManager.Instance.ShowInteractionKeyMessage();
        }

        if(tagName == "MainButton")
        {
            canInteract = true;
            UIManager.Instance.ShowInteractionKeyMessage();
        }

        if (tagName == "WiringPuzzle")
        {
            canInteract = true;
            UIManager.Instance.ShowInteractionKeyMessage();
        }

    }
    private void OnTriggerExit(Collider tri)
    {
        canInteract = false;
        tagName = null;

        if (tri.tag == "CoreEasy" || tri.tag == "CoreMedium" || tri.tag == "CoreHard")
        {
            corePuzzleIndex = -1;
        }

        if (tri.tag == "CoreKey")
        {
            isCoreKey = false;
            coreKeyObj = null;
        }

        if(tri.tag == "WiringKey")
        {
            isWiringKey = false;
            wiringKeyObj = null;
        }

        UIManager.Instance.HideInteractionKeyMessage();
    }

    
}
