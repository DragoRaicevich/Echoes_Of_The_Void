using Mono.Cecil.Cil;
using UnityEngine;

public class LogicaEntreEscenas : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        var noDestruirEntreEscenas = FindObjectsOfType<LogicaEntreEscenas>();
        if (noDestruirEntreEscenas.Length > 1)
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);   
    
    }



    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
