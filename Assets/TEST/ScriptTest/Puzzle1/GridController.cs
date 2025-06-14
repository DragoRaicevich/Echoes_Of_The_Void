using UnityEngine;
using UnityEngine.UI;

public class GridController : MonoBehaviour
{
    [SerializeField] private Image[] slotArray;
    [SerializeField] private int rows;
    [SerializeField] private int columns;
    [SerializeField] private Vector2 startPosition = new Vector2(0, 0); // posición base de la grilla
    [SerializeField] private float spacing = 10f; // espacio opcional entre imágenes

    private void Start()
    {
        CreateGrid();
    }

    private void CreateGrid()
    {
        if (slotArray == null || slotArray.Length == 0) return;

        // Suponemos que todas las imágenes tienen el mismo tamaño
        Vector2 cellSize = slotArray[0].rectTransform.sizeDelta;

        int index = 0;

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < columns; col++)
            {
                if (index >= slotArray.Length) return;

                // Posición calculada desde la posición inicial
                float x = startPosition.x + col * (cellSize.x);
                float y = startPosition.y - row * (cellSize.y); // Usamos "-" porque en UI hacia abajo es negativo

                // Seteamos la nueva posición local
                slotArray[index].rectTransform.anchoredPosition = new Vector2(x, y);
                index++;
            }
        }
    }
}
