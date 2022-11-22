using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MenuOpciones : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private AudioMixer audioMixer;
    public void Silenciar(bool silenciar)
    {
        if(silenciar){
            audioMixer.SetFloat("volumen", 0);
        }else{
            audioMixer.SetFloat("volumen", 1);
        }
    }

    // Update is called once per frame
    public void CambiarCalidad(int index)
    {
        QualitySettings.SetQualityLevel(index);
    }
}
