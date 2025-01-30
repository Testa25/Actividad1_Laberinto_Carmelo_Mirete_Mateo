using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform player;             // El transform del jugador (el personaje)
    public Vector3 offset;               // La distancia entre la cámara y el jugador
    public float rotationSpeed = 100f;   // Velocidad de rotación de la cámara
    public float smoothSpeed = 0.125f;   // Factor de suavizado para el movimiento de la cámara

    private float currentAngle = 0f;     // Ángulo actual de la cámara alrededor del jugador

    void LateUpdate()
    {
        // Obtener la entrada horizontal para la rotación
        float horizontal = Input.GetAxis("Horizontal");

        // Si hay entrada horizontal (A/D o flechas izquierda/derecha), rotamos la cámara
        if (horizontal != 0)
        {
            currentAngle += horizontal * rotationSpeed * Time.deltaTime;
        }

        // Calcular la nueva posición deseada de la cámara basada en el ángulo actual
        Quaternion rotation = Quaternion.Euler(0, currentAngle, 0);
        Vector3 desiredPosition = player.position + rotation * offset;

        // Suaviza el movimiento de la cámara
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // Actualiza la posición de la cámara
        transform.position = smoothedPosition;

        // Mantener la cámara mirando al jugador
        transform.LookAt(player);
    }
}
