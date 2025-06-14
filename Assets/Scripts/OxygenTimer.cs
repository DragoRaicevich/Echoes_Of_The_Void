using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OxygenTimer : MonoBehaviour
{
    public float timeRemaining = 900f; // 15 minutos en segundos
    public TextMeshProUGUI oxygenText;
    public TextMeshProUGUI objectiveText;
    public bool oxygenStarted = false;

    void Update()
    {
        if (!oxygenStarted) return;

        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            int minutes = Mathf.FloorToInt(timeRemaining / 60);
            int seconds = Mathf.FloorToInt(timeRemaining % 60);
            oxygenText.text = $"Oxígeno: {minutes:00}:{seconds:00}";
        }
        else
        {
            // Se acabó el oxígeno
            oxygenText.text = "Oxígeno: 00:00";
            objectiveText.text = "Has perdido la consciencia...";
            // Aquí podrías cargar una pantalla de fin de juego
            // SceneManager.LoadScene("GameOver");
        }
    }

    public void StartOxygen()
    {
        oxygenStarted = true;
    }
}
