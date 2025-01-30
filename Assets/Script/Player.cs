using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 100f;  // Velocidad de giro
    [SerializeField] float movementSpeed = 5f;    // Velocidad de avance
    [SerializeField] float gravity = -9.81f;      // Valor de la gravedad
    [SerializeField] float jumpHeight = 2f;       // Altura de salto
    [SerializeField] private float distanciaDeteccionInteractuable;
    [SerializeField] private float distanciaDeteccionSuelo;

    private CharacterController controller;
    private Vector3 velocity;           // Velocidad del personaje (incluyendo gravedad)
    private bool isGrounded;            // Verificar si está tocando el suelo
    private Vector3 posicionInicial;
    void Start()
    {
        posicionInicial = transform.position;
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        // Verificar si el personaje está tocando el suelo
        isGrounded = controller.isGrounded;

        // Obtener las entradas del jugador
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Girar el personaje
        transform.Rotate(0, horizontal * rotationSpeed * Time.deltaTime, 0);

        // Calcular el movimiento (en el espacio local)
        Vector3 forwardMovement = transform.TransformDirection(Vector3.forward) * vertical * movementSpeed * Time.deltaTime;

        // Si está en el suelo y presionan el salto
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f; // Asegura que el personaje no quede flotando en el aire
        }

        // Aplicar el salto
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity); // Salto basado en la gravedad y la altura
        }

        // Aplicar la gravedad
        velocity.y += gravity * Time.deltaTime;

        // Mover el personaje
        controller.Move(forwardMovement + velocity * Time.deltaTime);


        if (Input.GetKey(KeyCode.E))
        {
            if (Physics.Raycast(transform.position, Vector3.forward, out RaycastHit hit, distanciaDeteccionInteractuable))
            {
                if (hit.transform.TryGetComponent(out Panel panel))
                {
                    panel.Interactuar();
                }
            }
        }


    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.TryGetComponent(out Techo techo))
        {
            transform.position = posicionInicial;
            
            //recargar Scene
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

       
    }

}


