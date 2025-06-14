using NUnit.Framework.Internal;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class WiringColumn : MonoBehaviour
{
    [SerializeField] private GameObject[] wires;
    [SerializeField] private float positionY = 300f; 
    private void Start()
    {
        RandomizerPositionWires();
    }

    private void RandomizerPositionWires()
    {
        List<int> availableIndices = new List<int>();
        for (int i = 0; i < wires.Length; i++)
            availableIndices.Add(i);

        float currentY = positionY;

        for (int i = 0; i < wires.Length; i++)
        {
            int randomListIndex = Random.Range(0, availableIndices.Count);
            int wireIndex = availableIndices[randomListIndex];

            currentY -= 50f;
            wires[wireIndex].transform.localPosition = new Vector3(wires[wireIndex].transform.localPosition.x,
                                                                   currentY,0);

            availableIndices.RemoveAt(randomListIndex);
        }
    }
}
