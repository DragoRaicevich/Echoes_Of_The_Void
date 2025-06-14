using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class SurvivalManager : MonoBehaviour
{
    public float timeWithoutSuit = 60f;
    public float timeWithSuit = 900f; // 15 minutos en segundos

    public bool hasSuit = false;
    private bool isDead = false;

    public GameObject helmetHUD;       // HUD del casco
    public GameObject gameOverUI;      // UI de muerte
    public TMPro.TextMeshProUGUI oxygenText;  // Texto de tiempo restante

    void Start()
    {
        helmetHUD.SetActive(false);
        gameOverUI.SetActive(false);
    }

    void Update()
    {
        if (isDead) return;

        if (!hasSuit)
        {
            timeWithoutSuit -= Time.deltaTime;
            if (timeWithoutSuit <= 0f)
            {
                Die("Te quedaste sin oxígeno.");
            }
        }
        else
        {
            timeWithSuit -= Time.deltaTime;
            UpdateOxygenDisplay();

            if (timeWithSuit <= 0f)
            {
                Die("Se agotó el oxígeno del traje.");
            }
        }
    }

    public void PutOnSuit()
    {
        hasSuit = true;
        helmetHUD.SetActive(true);
    }

    private void Die(string reason)
    {
        isDead = true;
        Debug.Log(reason);
        gameOverUI.SetActive(true);
        // Opcional: detener controles
        Time.timeScale = 0f;
    }

    private void UpdateOxygenDisplay()
    {
        int minutes = Mathf.FloorToInt(timeWithSuit / 60f);
        int seconds = Mathf.FloorToInt(timeWithSuit % 60f);
        oxygenText.text = $"Oxígeno: {minutes:00}:{seconds:00}";
    }
}
