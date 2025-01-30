using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform player;             // El transform del jugador (el personaje)
    public Vector3 offset;               // La distancia entre la c�mara y el jugador
    public float rotationSpeed = 100f;   // Velocidad de rotaci�n de la c�mara
    public float smoothSpeed = 0.125f;   // Factor de suavizado para el movimiento de la c�mara

    private float currentAngle = 0f;     // �ngulo actual de la c�mara alrededor del jugador

    void LateUpdate()
    {
        // Obtener la entrada horizontal para la rotaci�n
        float horizontal = Input.GetAxis("Horizontal");

        // Si hay entrada horizontal (A/D o flechas izquierda/derecha), rotamos la c�mara
        if (horizontal != 0)
        {
            currentAngle += horizontal * rotationSpeed * Time.deltaTime;
        }

        // Calcular la nueva posici�n deseada de la c�mara basada en el �ngulo actual
        Quaternion rotation = Quaternion.Euler(0, currentAngle, 0);
        Vector3 desiredPosition = player.position + rotation * offset;

        // Suaviza el movimiento de la c�mara
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // Actualiza la posici�n de la c�mara
        transform.position = smoothedPosition;

        // Mantener la c�mara mirando al jugador
        transform.LookAt(player);
    }
}
