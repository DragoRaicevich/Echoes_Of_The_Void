using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TouchpadController : MonoBehaviour
{
    [SerializeField] private Text touchpadText;

    [SerializeField] private Image padlockCloseImage;
    [SerializeField] private Color closeColor;
    [SerializeField] private Color openColor;
    [SerializeField] private Image padlockOpenImage;
    [SerializeField] private Button[] numberButtons;

    private void Start()
    {
        closeColor = padlockOpenImage.color;
        openColor = padlockCloseImage.color;
    }

    private void OnEnable()
    {
        touchpadText.text = string.Empty;
    }

    public void AddNumber(string numberButton)
    {
        touchpadText.text = touchpadText.text + numberButton;
        if (touchpadText.text.Length > 3)
        {
            StartCoroutine(CheckCodeCoroutine());
        }
    }

    private void DeactivateButtons()
    {
        foreach (Button button in numberButtons)
        {
            button.interactable = false;
        }
    }

    private void ActivateButtons()
    {
        foreach (Button button in numberButtons)
        {
            button.interactable = true;
        }
    }

    IEnumerator CheckCodeCoroutine()
    {
        DeactivateButtons();
        if (touchpadText.text == GameManager.Instance.CorrectCode)
        {
            GameManager.Instance.TouchpadCompleted = true;
            padlockCloseImage.color = closeColor;
            padlockOpenImage.color = openColor;
            GameManager.Instance.UnlockDoors();
            yield return new WaitForSeconds(0.5f);
            UIManager.Instance.DeactivateTouchpadPanel();
        }
        else
        {
            yield return new WaitForSeconds(0.5f);
            touchpadText.text = string.Empty;
            ActivateButtons();
        }
    }
}
