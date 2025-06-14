using System;
using System.Collections;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.UI;

public class WiringPuzzleController : MonoBehaviour
{
    [SerializeField] private WireInteraction[] wires;
    [SerializeField] private GameObject[] lights;
    [SerializeField] private bool allConnected = false;
    [SerializeField] private Button buttonStart; 
    public static event Action OnWiringPuzzleCompleted;

    public void CheckWires()
    {
        foreach (WireInteraction wire in wires)
        {
            if (!wire.IsConnected)
            {
                Debug.Log("Not all wires are connected! This ID: " + wire.WireID);
                
                allConnected = false;
                break;
            }
            else
            {
                allConnected = true;
            }
        }
        if(allConnected)
        {
            buttonStart.interactable = false;
            Debug.Log("All wires connected!");
            OnWiringPuzzleCompleted?.Invoke();
            StartCoroutine(ActivateLights());
        }

    }

    IEnumerator ActivateLights()
    {
        foreach (GameObject light in lights)
        {
            yield return new WaitForSeconds(0.5f);
            light.SetActive(true);
            SoundManager.Instance.PlayCoreZoneSound(1, 0.5f);
            yield return new WaitForSeconds(0.5f);
        }
        SoundManager.Instance.PlayCoreZoneSound(0, 0.5f);
    }

}
