using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    public bool Puzzle1Solved = false;
    public bool Puzzle2Solved = false;
    public GameObject interactionButton;

    void Update()
    {
        if (Puzzle1Solved && Puzzle2Solved)
        {
            interactionButton.SetActive(true);
            enabled = false;
        }
    }
}
