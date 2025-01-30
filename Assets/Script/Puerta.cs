using Motores;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puerta : MonoBehaviour
{
    [SerializeField] private GameManagerSO gM;
    [SerializeField] private int idPuerta;

    private bool abrir = false;

    // Start is called before the first frame update
    void Start()
    {
        gM.OnNuevaInteraccion += Abrir;
    }

    private void Abrir(int idBotonpulsado)
    {
        if (idBotonpulsado == idPuerta)
        {
            abrir = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (abrir) { 
        transform.Translate(Vector3.down * 30 * Time.deltaTime);
        }
    }
}
