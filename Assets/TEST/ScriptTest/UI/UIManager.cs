using System.Collections;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [Header("UI PLAYER")]
    [SerializeField] private GameObject HelmentImage;
    [Header("UI CORE PUZZLE ")]
    [SerializeField] private GameObject corePuzzlePanel;
    [SerializeField] private GameObject[] puzzleArrayPanels;

    [Header("UI WIRING PUZZLE")]
    [SerializeField] private GameObject wiringPuzzlePanel;

    [Header("PLAYER")]
    [SerializeField] private FirstPersonController firstPersonController;
    [SerializeField] private MouseLook mouseLook;

    [Header("INITIAL CAPSULE")]
    [SerializeField] private GameObject tochpadPanel;

    [Header("MESSAGES")]
    [SerializeField] private GameObject messagePanel;
    [SerializeField] private GameObject interactionMessage;
    [SerializeField] private GameObject needKeyMessage;
    [SerializeField] private GameObject mainDoorLockMessage;
    public static UIManager Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

    }

    public void ActivateTouchpadPanel()
    {
        tochpadPanel.SetActive(true);
        DeactivatePlayerControlls();
    }
    public void DeactivateTouchpadPanel()
    {
        tochpadPanel.SetActive(false);
        messagePanel.SetActive(true);
        ActivatePlayerControlls();
    }
    public void ActivateWiringPuzzlePanel()
    {
        wiringPuzzlePanel.SetActive(true);
        DeactivatePlayerControlls();
    }
    public void DeactivatePuzzleWiringPanel()
    {
        wiringPuzzlePanel.SetActive(false);
        ActivatePlayerControlls();
    }

    public void ActivetePuzzleCore(int index)
    {
        DeactivatePlayerControlls();
        puzzleArrayPanels[index].SetActive(true);
        corePuzzlePanel.SetActive(true);
    }

    public void DeactivatePuzzleCore(int index)
    {
        corePuzzlePanel.SetActive(false);
        puzzleArrayPanels[index].SetActive(false); // Desactiva el panel del puzzle según el índice
        ActivatePlayerControlls();

    }

    public void ShowMainDoorLockedMessage()
    {
        StartCoroutine(ShowMainDoorLockedMessageCorrutine());
    }

    IEnumerator ShowMainDoorLockedMessageCorrutine()
    {
        HideInteractionKeyMessage();
        mainDoorLockMessage.SetActive(true);
        yield return new WaitForSeconds(5f);
        mainDoorLockMessage.SetActive(false);
    }

    private void DeactivatePlayerControlls()
    {
        firstPersonController.enabled = false;
        mouseLook.enabled = false;
        Cursor.lockState = CursorLockMode.None;
    }

    private void ActivatePlayerControlls()
    {
        firstPersonController.enabled = true;
        mouseLook.enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void ShowNeedCoreKeyMessage()
    {
        StartCoroutine(ShowNeedCoreKeyMessageCoroutine());
    }

    IEnumerator ShowNeedCoreKeyMessageCoroutine()
    {
        HideInteractionKeyMessage();
        needKeyMessage.SetActive(true);
        yield return new WaitForSeconds(3f);
        needKeyMessage.SetActive(false);
    }

    public void ShowInteractionKeyMessage()
    {
        interactionMessage.SetActive(true);
    }

    public void HideInteractionKeyMessage()
    {
        interactionMessage.SetActive(false);
    }
}
