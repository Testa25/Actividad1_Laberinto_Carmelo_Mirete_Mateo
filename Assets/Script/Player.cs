using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Personaje
{
    public class Player : MonoBehaviour
    {
       [SerializeField] private float velocidad;
        [SerializeField] private float giro;
     
        private CharacterController characterController;
        void Start()
        {
            characterController = GetComponent<CharacterController>();
        }

        // Update is called once per frame
        void Update()
        {

            // Obtener input del jugador
            float hInput = Input.GetAxis("Horizontal"); // A/D o Izquierda/Derecha
            float vInput = Input.GetAxis("Vertical");     // W/S o Arriba/Abajo

            // Rotar el personaje
            transform.Rotate(0, hInput * giro * Time.deltaTime, 0);

            // Avanzar en la dirección actual
            Vector3 direccionMovimento = transform.TransformDirection(Vector3.forward * vInput);
            characterController.Move(direccionMovimento * velocidad * Time.deltaTime);


           
        }
    }
}