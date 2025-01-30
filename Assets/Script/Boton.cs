using Motores;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boton1 : MonoBehaviour
{
    [SerializeField] private GameManagerSO gM;
    [SerializeField] private int idBoton;
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.TryGetComponent(out PlayerDynamic player))
        {
            gM.InteractuableEjecutado(idBoton);
        }
        
    }
}
