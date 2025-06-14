using UnityEngine;

public class GameManager : MonoBehaviour
{

    [Header("GAME MANAGER")]
    [SerializeField] private bool gameOver = false;

    [Header("TOUCHPAD")]
    [SerializeField] private bool touchpadCompleted = false;
    [SerializeField] private string correctCode = "1234";
    [SerializeField] private DoorController[] doorControllers;

    [Header("CORE ZONE")]
    [SerializeField] private bool coreZoneCompleted = false;
    private int coresComplete = 0;

    [Header("WIRING ZONE")]
    [SerializeField] private bool wiringZoneCompleted = false;

    [Header("MAIN DOOR")]
    [SerializeField] private MainButtonController mainButtonController;
    public bool TouchpadCompleted { get => touchpadCompleted; set => touchpadCompleted = value; }
    public string CorrectCode { get => correctCode; }
    public static GameManager Instance { get; private set; }
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
    private void Start()
    {
        PuzzlePowerController.OnCoreCompleted += CoreComplete;
        WiringPuzzleController.OnWiringPuzzleCompleted += WiringComplete;
        OxygenController.OnTimeOut += GameOver; 

    }

    private void OnDisable()
    {
        PuzzlePowerController.OnCoreCompleted -= CoreComplete;
        WiringPuzzleController.OnWiringPuzzleCompleted -= WiringComplete;
        OxygenController.OnTimeOut -= GameOver;
    }

    private void GameOver()
    {
        gameOver = true;
        Debug.Log("Game Over!");
    }

    public void UnlockDoors()
    {
        if (touchpadCompleted)
        {
            foreach (var door in doorControllers)
            {
                door.UnlockDoor();
            }
        }
    }

    private void ActivateMainBootn()
    {
        mainButtonController.IsActivated = true;
    }

    private void WiringComplete()
    {
        wiringZoneCompleted = true;
        if(coreZoneCompleted == true)
        {
            ActivateMainBootn();
        }
        Debug.Log("Wiring zone completed!");
    }

    private void CoreComplete()
    {
        coresComplete++;
        if (coresComplete >= 3)
        {
            Debug.Log("All cores completed!");
            coreZoneCompleted = true;
            if(wiringZoneCompleted == true)
            {
                ActivateMainBootn();
            }
        }
    }
}
