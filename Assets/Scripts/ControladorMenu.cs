using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControladorMenu : MonoBehaviour
{
    [SerializeField] private Animator animator;
    
    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    private void Start()
    {
        
        animator.SetBool("InicioApp", true);
        ControladorMusica.instancia.EfectosIniciales();

    }

    //Carga una escena. Su uso es en botones.
    public void CargarEscena(string nombreEscena)
    {
        if(nombreEscena.Equals("Sesion"))
        {

            ControladorMusica.instancia.sonidoPartida();
        }
        else
        {
            ControladorMusica.instancia.sonidoBoton();
        }

        
        SceneManager.LoadScene(nombreEscena);
    }

    public void Salir()
    {
        ControladorMusica.instancia.sonidoBoton();
        Application.Quit();
    }
    
}
