using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Para manejar escenas

public class GameEndTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Meta")
        {
            Debug.Log("¡Has llegado a la meta!");
            EndGame();
        }
    }

    void EndGame()
    {
        // Cierra la aplicación si es un juego compilado
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
    }
}
