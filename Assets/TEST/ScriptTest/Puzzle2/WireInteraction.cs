using UnityEngine;
using UnityEngine.EventSystems;

public class WireInteraction : MonoBehaviour, IDragHandler, IPointerUpHandler
{
    [Header("WIRE END")]
    [SerializeField] private GameObject wireEnd;
    private float initialWidthWireEnd;

    [Header("CONECTOR")]
    [SerializeField] private int wireID;
    [SerializeField] private bool isConnected = false;
    private Vector2 initialPosition;
    private RectTransform rectTransform;

    [Header("WIRESOCKET")]
    [SerializeField] private GameObject wireSocket;

    public bool IsConnected { get => isConnected; }
    public int WireID { get => wireID; }

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        initialPosition = rectTransform.anchoredPosition;

        initialWidthWireEnd = wireEnd.GetComponent<RectTransform>().sizeDelta.x;
    }


    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.position = eventData.position;

        Vector2 posicionActual = transform.position;
        Vector2 puntoOrigen = transform.parent.position;
        Vector2 direccion = posicionActual - puntoOrigen;

        float angulo = Vector2.SignedAngle(Vector2.right, direccion);

        transform.rotation = Quaternion.Euler(0, 0, angulo);
        wireEnd.transform.rotation = Quaternion.Euler(0, 0, angulo);

        float nuevaDistancia = direccion.magnitude;

        RectTransform wireEndRect = wireEnd.GetComponent<RectTransform>();
        wireEndRect.sizeDelta = new Vector2(nuevaDistancia, wireEndRect.sizeDelta.y);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if(isConnected == false)
        {
            ResetWirePosition();
        }
        else
        {
            SetConnection();
        }

    }

    private void SetConnection()
    {
        SoundManager.Instance.PlayWiringZoneSound(0, 0.5f);
    }

    private void ResetWirePosition()
    {
        wireEnd.GetComponent<RectTransform>().sizeDelta = new Vector2(initialWidthWireEnd, wireEnd.GetComponent<RectTransform>().sizeDelta.y);
        rectTransform.anchoredPosition = initialPosition;

        transform.rotation = Quaternion.identity;
        wireEnd.transform.rotation = Quaternion.identity;
    }

    private void OnTriggerEnter2D(Collider2D tri)
    {
        Debug.Log("OnTriggerEnter2D: " + tri.name);
        if (tri.CompareTag("WireSocket"))
        {
            WireSocket connector = tri.GetComponent<WireSocket>();
            if (connector != null && !isConnected && connector.WireSocketID == wireID)
            {
                isConnected = true;
                wireSocket = tri.gameObject;
                int randimIndex = Random.Range(1, 2);
                SoundManager.Instance.PlayWiringZoneSound(randimIndex, 0.5f);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D tri)
    {
        if(tri.CompareTag("WireSocket"))
        {
            isConnected = false;
            wireSocket = null;
        }

    }
}
