using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Motores
{
    [CreateAssetMenu(menuName = "MiGameManager")]
    public class GameManagerSO : ScriptableObject 
    {
        public event Action<int> OnNuevaInteraccion;
        internal void InteractuableEjecutado(int idInteraccion)
        {
            //Lanzar un evente de que un boton ha sido pulsado
            OnNuevaInteraccion.Invoke(idInteraccion);
        }

    
    
    }
}
