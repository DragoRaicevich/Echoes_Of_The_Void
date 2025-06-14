using System;
using UnityEngine;
using UnityEngine.UI;

public class OxygenController : MonoBehaviour
{
    [SerializeField] private Text oxygenTimerText;
    [SerializeField] private float timeRemaining = 60f; // 10 minutos = 600 segundos
    [SerializeField] private bool isRunning = false;

    public bool IsRunning { get => isRunning; set => isRunning = value; }

    public static event Action OnTimeOut;

    void Update()
    {
        if (isRunning && timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;

            int minutes = Mathf.FloorToInt(timeRemaining / 60f);
            int seconds = Mathf.FloorToInt(timeRemaining % 60f);

            oxygenTimerText.text = $"{minutes:00}:{seconds:00}";
        }
        else if (timeRemaining <= 0)
        {
            isRunning = false;
            oxygenTimerText.text = "00:00";
            OnTimeOut?.Invoke();
        }
    }
}
