using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControladorMenu : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject logo;
    

    private void Start()
    {

        if(PlayerPrefs.GetInt("Inicio", 0) == 0)
        {

            StartCoroutine(Inicio());
            PlayerPrefs.SetInt("Inicio", 1);

        }
        else
        {
            logo.gameObject.SetActive(false);
        }
    }

    IEnumerator Inicio()
    {

        ControladorMusica.instancia.EfectosIniciales(4);
        yield return new WaitForSeconds(5);
        ControladorMusica.instancia.EfectosIniciales(5);
        yield return new WaitForSeconds(1.2f);
        logo.gameObject.SetActive(false);

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

        
        ControladorEscena.CargarEscena(nombreEscena);
    }

    public void Salir()
    {
        ControladorMusica.instancia.sonidoBoton();
        PlayerPrefs.SetInt("Inicio", 0);
        Application.Quit();
    }
    
}
