using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Motores;

public class Panel : MonoBehaviour
{
    [SerializeField] private Motores.GameManagerSO gM;
  
    
    [SerializeField] private int idPanel;
  
    // Start is called before the first frame update
   public void Interactuar()
    {
        
        gM.InteractuableEjecutado(idPanel);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
