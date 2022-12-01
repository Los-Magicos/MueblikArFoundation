using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ControladorOpciones : MonoBehaviour
{

    [SerializeField] private Slider sliderVolumen;
    [SerializeField] private Toggle toggleSilenciar;


    private void Start()
    {
        
        sliderVolumen.value = PlayerPrefs.GetFloat("volumen", 0.5f);

    }

    //Cambia el volumen de los efectos. Controlado por un Slider.
    public void Volumen()
    {
        ControladorMusica.instancia.volumen(sliderVolumen.value);
    }

    //Carga una escena. Su uso es en botones.
    public void CargarEscena(string nombreEscena)
    {
        ControladorEscena.CargarEscena(nombreEscena);
        ControladorMusica.instancia.sonidoBoton();
    }

    //Silencia la musica.
    public void Silenciar()
    {
        Debug.Log("Entrando a silenciar");
        if(toggleSilenciar.isOn)
        {
            Debug.Log("Desenmudecer");
            ControladorMusica.instancia.Desenmudecer();
        }
        else
        {
            Debug.Log("Silenciar");
            ControladorMusica.instancia.Silenciar();
        }

    }

    
    public void CambiarCalidad(int index)
    {
        QualitySettings.SetQualityLevel(index);
    }

}
