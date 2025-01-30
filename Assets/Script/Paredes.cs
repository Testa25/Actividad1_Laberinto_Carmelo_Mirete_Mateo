using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paredes : MonoBehaviour
{
    [SerializeField] private Motores.GameManagerSO gM;
    [SerializeField] private int id;
    [SerializeField] private float velocidadObstaculo;
    private float xDirecction = 1;
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

        if (this.id == id)
        {
            activar = true;
            xDirecction *= -1f;
        }

    }
    // Update is called once per frame
    void Update()
    {
        if (activar)
        {
            float newX = transform.position.x + (xDirecction * 5 * Time.deltaTime);
            if (xDirecction > 0 && newX >= posicionInicial.y)
            {
                newX = posicionInicial.x;
                activar = false;
            }
            transform.Translate(new Vector3(xDirecction, 0, 0) * velocidadObstaculo * Time.deltaTime, Space.World);
        }


    }
    private void OnDisable()
    {
        gM.OnNuevaInteraccion -= Activar;
    }
}