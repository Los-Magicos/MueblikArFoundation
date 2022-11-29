
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControladorEscena : MonoBehaviour
{

    /// <summary>
    /// Carga una escena por medio del un parametro
    /// </summary>
    public static void CargarEscena(string nombreEscena)
    {
        ControladorMusica.instancia.sonidoBoton();
        SceneManager.LoadScene(nombreEscena);
    }
    /// <summary>
    /// Reload the current active scene
    /// </summary>
    public static void ReloadCurrentLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    
}

