using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ControladorOpciones : MonoBehaviour
{

    [SerializeField] private Slider sliderVolumen;
    [SerializeField] private Toggle toggleSilenciar;



    //Cambia el volumen de los efectos. Controlado por un Slider.
    public void Volumen()
    {
        ControladorMusica.instancia.volumen(sliderVolumen.value);
    }

    //Carga una escena. Su uso es en botones.
    public void CargarEscena(string nombreEscena)
    {
        ControladorEscena.CargarEscena(nombreEscena);
    }

    //Silencia la musica.
    public void Silenciar()
    {

        if(toggleSilenciar.isOn)
        {
            ControladorMusica.instancia.Desenmudecer();
        }
        else
        {
            ControladorMusica.instancia.Silenciar();
        }

    }

    
    public void CambiarCalidad(int index)
    {
        QualitySettings.SetQualityLevel(index);
    }

}
