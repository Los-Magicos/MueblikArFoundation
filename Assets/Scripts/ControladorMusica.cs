using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class ControladorMusica : MonoBehaviour
{

    public static ControladorMusica instancia;

    [SerializeField] private AudioSource fxAudioSource;
    [SerializeField] private AudioSource musicAudioSource;
    [SerializeField] private AudioMixer mixer;

    [SerializeField] private List<AudioClip> clip;

    private float fxVolumen;
    private float musicVolumen;

    private void Awake()
    {

        if(instancia != null)
        {
            Destroy(this.gameObject);
        }
        
        instancia = this;

        this.musicAudioSource.clip = clip[5];
        this.musicAudioSource.Play();

        DontDestroyOnLoad(this.gameObject);

        volumen(PlayerPrefs.GetFloat("volumen", 0.5f));
        
    }

    //Reproduce un efecto de sonido al pulsar un boton. Es llamado por botones
    public void sonidoBoton()
    {

        this.fxAudioSource.clip = clip[0];
        this.fxAudioSource.Play();

    }

    //Reproduce un efecto de sonido al inicar la App.
    public void sonidoPartida()
    {

        this.fxAudioSource.clip = clip[1];
        this.fxAudioSource.Play();

    }

    //Silencia el mixer, donde están los audio source "fxAudioSource" y "musicAudioSource".
    public void Silenciar()
    {

        this.mixer.SetFloat("volumen", 0);

    }

    //Vulve a activar el sonido con el valor guardado.
    public void Desenmudecer()
    {
        this.mixer.SetFloat("volumen", PlayerPrefs.GetFloat("volumen", 0.5f));
    }
    
    //Cambia el volumen del mixer.
    public void volumen(float volumen)
    {

        PlayerPrefs.SetFloat("volumen", volumen);
        this.mixer.SetFloat("volumenMixer", volumen*80 - 80);

    }

}
