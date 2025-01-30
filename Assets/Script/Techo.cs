using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Techo : MonoBehaviour
{
    [SerializeField] private Motores.GameManagerSO gM;
    [SerializeField] private int id;
    [SerializeField] private float velocidadObstaculo;
    private float yDirecction = 1 ;
    private bool activar;
    private Vector3 posicionInicial;



    private void Start()
    {
        posicionInicial = transform.position;
    }
    private void OnEnable()
    {
        gM.OnNuevaInteraccion += Activar;
    }

    private void Activar(int id)
    {
        
        if(this.id == id)
        {
            activar = true;
            yDirecction *= -1f;
        }

    }
    // Update is called once per frame
    void Update()
    {
        if (activar)
        {
            float newY = transform.position.y + (yDirecction * 5 *  Time.deltaTime);
            if(yDirecction > 0 && newY >= posicionInicial.y)
            {
                newY = posicionInicial.y;
                activar = false;
            }
            transform.Translate(new Vector3(0, yDirecction, 0) * velocidadObstaculo * Time.deltaTime, Space.World);
        }
       
        
    }
    private void OnDisable()
    {
        gM.OnNuevaInteraccion -= Activar;
    }
}
