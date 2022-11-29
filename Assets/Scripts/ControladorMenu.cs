using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControladorMenu : MonoBehaviour
{
    
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
