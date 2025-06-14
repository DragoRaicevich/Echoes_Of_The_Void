using UnityEngine;

public class Puzzle2Controller : MonoBehaviour
{
    private bool clickedA = false;

    public GameObject canvasPuzzle2;
    public GameObject puzzleManager;

    public void ClickA()
    {
        clickedA = true;
    }

    public void ClickB()
    {
        if (clickedA)
        {
            puzzleManager.GetComponent<PuzzleManager>().Puzzle2Solved = true;
            canvasPuzzle2.SetActive(false);
        }
    }
}
