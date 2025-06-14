using UnityEngine;
using UnityEngine.EventSystems;

public class InteractionNode : MonoBehaviour, IPointerClickHandler
{
    private float currentRotation;
    [SerializeField] private EnergyNode energyNode;
    [SerializeField] private bool isSeleccted = false;
    [SerializeField] private PuzzlePowerController powerController;
    [SerializeField] private GameObject mouseIcon;

    private void Start()
    {
        currentRotation = transform.rotation.eulerAngles.z;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        currentRotation += 90f;
        transform.rotation = Quaternion.Euler(0, 0, currentRotation);
        if (mouseIcon != null)
        {
            mouseIcon.SetActive(false);
        }

        SoundManager.Instance.PlayCoreZoneSound(1, 0.5f);
    }
}
