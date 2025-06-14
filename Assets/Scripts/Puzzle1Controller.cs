using UnityEngine;

public class Puzzle1Controller : MonoBehaviour
{
    private int[] correctOrder = { 1, 2, 3 };
    private int currentStep = 0;

    public GameObject canvasPuzzle1;
    public GameObject puzzleManager;

    public void PressButton(int buttonID)
    {
        if (buttonID == correctOrder[currentStep])
        {
            currentStep++;
            if (currentStep >= correctOrder.Length)
            {
                puzzleManager.GetComponent<PuzzleManager>().Puzzle1Solved = true;
                canvasPuzzle1.SetActive(false);
            }
        }
        else
        {
            currentStep = 0; // reiniciar si se equivoca
        }
    }
}
