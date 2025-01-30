using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;


public class PlayerDynamic : MonoBehaviour
{
    
    [SerializeField] private float fuerza;
    [SerializeField] private float fuerzaSalto;
    [SerializeField] private float velocidadMaxima;
    [SerializeField]private float distanciaDeteccionSuelo;
    [SerializeField] private float distanciaDeteccionInteractuable;

    private Rigidbody rb;
    private float hInput , vInput;
    private float fuerzaSaltoMaxima;
    private Vector3 posicionInicial;

    // Start is called before the first frame update
    void Start()
    {
        posicionInicial = transform.position;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        hInput = Input.GetAxisRaw("Horizontal");
        vInput = Input.GetAxisRaw("Vertical");

        if (Input.GetKeyDown(KeyCode.Space))
        {
           if( Physics.Raycast(transform.position, Vector3.down, distanciaDeteccionSuelo ))
            rb.AddForce(Vector3.up.normalized * fuerzaSalto, ForceMode.Impulse);


        }
        if (Input.GetKey(KeyCode.E)) { 
        if(Physics.Raycast(transform.position,Vector3.forward, out RaycastHit hit , distanciaDeteccionInteractuable))
            {
                if(hit.transform.TryGetComponent(out Panel panel))
                {
                    panel.Interactuar();
                }
            }
        }
   
       
    }
    private void FixedUpdate()
    {
        rb.AddForce(new Vector3(hInput, 0, vInput).normalized * fuerza, ForceMode.Force);
        LimitarVelocidad();
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.transform.TryGetComponent(out Techo techo))
        {
            transform.position = posicionInicial;
            rb.velocity = Vector3.zero;
            //recargar Scene
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    private void LimitarVelocidad()
    {
        Vector3 velocidadHorizontal = new Vector3(rb.velocity.x, 0, rb.velocity.z);
        if (velocidadHorizontal.magnitude > velocidadMaxima)
        {
            velocidadHorizontal = velocidadHorizontal.normalized * velocidadMaxima;
            rb.velocity = new Vector3(velocidadHorizontal.x, rb.velocity.y, velocidadHorizontal.z);
        }
    }
}
