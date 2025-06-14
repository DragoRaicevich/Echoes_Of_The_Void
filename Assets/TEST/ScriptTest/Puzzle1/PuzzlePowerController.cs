using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PuzzlePowerController : MonoBehaviour
{
    [SerializeField] private List<EnergyNode> energyNodeList;
    [SerializeField] private PowerSocket powerSocket;
    [SerializeField] private Button startButton;

    private bool powerStationIsConnected = false;
    private bool allNodesConected = true;

    public static event Action OnCoreCompleted;


    // Este metodo se llama al pulzar el boton "START".
    public void CheckPower() 
    {
        CheckNodes();
        if (allNodesConected == true && powerStationIsConnected == true)
        {
            OnCoreCompleted?.Invoke();
            startButton.interactable = false; 
            SoundManager.Instance.PlayCoreZoneSound(0, 0.5f);
        }
    }

    private void CheckNodes()
    {
        SoundManager.Instance.PlayWiringZoneSound(0, 0.1f);
        foreach (var node in energyNodeList)
        {
            node.CheckConnectors();
            if (node.NodeHasPower == false)
            {
                allNodesConected = false;
                break;
            }
            else
            {
                allNodesConected = true;
            }
        }
        if (powerSocket.HasPower)
        {
            powerStationIsConnected = true;
        }
    }

}
