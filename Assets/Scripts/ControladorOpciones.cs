using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ControladorOpciones : MonoBehaviour
{

    [SerializeField] private Slider sliderVolumen;

    public void Volumen()
    {
        ControladorMusica.instancia.volumen(sliderVolumen.value);
    }

    public void CargarEscena(string nombreEscena)
    {
        ControladorEscena.CargarEscena(nombreEscena);
    }

    public void Silenciar()
    {

        ControladorMusica.instancia.Silenciar();

    }

    public void CambiarCalidad(int index)
    {
        QualitySettings.SetQualityLevel(index);
    }

}
