using System;
using Unity.VisualScripting;
using UnityEngine;

public class Connector : MonoBehaviour
{
    [SerializeField] private bool isConected = false;
    public bool IsConected { get => isConected; }



    private void OnTriggerStay2D(Collider2D tri)
    {
        string tagName = tri.tag;
        if (tagName == "Connector" || tagName == "PowerStation")
        {
            isConected = true;
        }
        if(tagName == "PowerSocket")
        {
            PowerSocket powerSocket = tri.GetComponent<PowerSocket>();
            if (powerSocket != null)
            {
                isConected = true;
                powerSocket.HasPower = true;
            }
   
        }
    }

    private void OnTriggerExit2D(Collider2D tri)
    {
        string tagName = tri.tag;
        if (tagName == "PowerStation" || tagName == "Connector")
        {
            isConected = false;
        }
        if (tagName == "PowerSocket")
        {
            PowerSocket powerSocket = tri.GetComponent<PowerSocket>();
            if (powerSocket != null)
            {
                isConected = false;
                powerSocket.HasPower = false;
            }

        }
    }
}
