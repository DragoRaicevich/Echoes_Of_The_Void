using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyNode : MonoBehaviour
{
    [SerializeField] private bool nodeHasPower = false;

    [SerializeField] private List<Connector> connectorList;
    [SerializeField] private bool connectedToPowerStation = false;
    //Color
    [SerializeField] private Image coreImage;
    private Color offColor;
    private Color onColor;

    public bool NodeHasPower { get => nodeHasPower; set => nodeHasPower = value; }
    public bool ConnectedToPowerStation { get => connectedToPowerStation; set => connectedToPowerStation = value; }

    [SerializeField] private bool foundPower = false;

    private void Start()
    {
        onColor = Color.white;
        offColor = Color.black;
    }

    public void CheckConnectors()
    {
        foreach (Connector connector in connectorList)
        {
            if (connector.IsConected == true)
            {
                foundPower = true;
                break;
            }
            else
            {
                foundPower = false;
            }
        }

        if (foundPower == true)
        {
            PowerCellOn();
        }
        else
        {
            PowerCellOff();
        }
    }
    public void PowerCellOn()
    {
        nodeHasPower = true;
        SetCellColor(nodeHasPower);
    }
    public void PowerCellOff()
    {
        nodeHasPower = false;
        SetCellColor(nodeHasPower);
    }
    private void SetCellColor(bool state)
    {
        if (nodeHasPower)
        {
            coreImage.color = onColor;
        }
        else
        {
            coreImage.color = offColor;
        }
    }
}
