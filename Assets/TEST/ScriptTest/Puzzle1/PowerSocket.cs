using UnityEngine;

public class PowerSocket : MonoBehaviour
{
    [SerializeField] private bool hasPower = false;

    public bool HasPower { get => hasPower; set => hasPower = value; }
}
