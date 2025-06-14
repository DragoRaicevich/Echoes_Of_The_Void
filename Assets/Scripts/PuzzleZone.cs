using UnityEngine;

public class PuzzleZone : MonoBehaviour
{
    public GameObject puzzleCanvas;

    private void Start()
    {
        if (puzzleCanvas != null)
        {
            puzzleCanvas.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(">> OnTriggerEnter con: " + other.name);

        if (other.CompareTag("Player"))
        {
            Debug.Log("Jugador entró al área del puzzle");

            if (puzzleCanvas != null)
                puzzleCanvas.SetActive(true);

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Jugador salió del área del puzzle");

            if (puzzleCanvas != null)
                puzzleCanvas.SetActive(false);

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
}

