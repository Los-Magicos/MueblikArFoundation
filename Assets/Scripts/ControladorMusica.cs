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
            return;
        }
        
        instancia = this;
        DontDestroyOnLoad(this);
    
        //this.musicAudioSource.clip = clip[5];
        //this.musicAudioSource.Play();
        volumen(PlayerPrefs.GetFloat("volumen", 0.5f));

    }

    public void EfectosIniciales(int index)
    {

        fxAudioSource.clip = clip[index];
        fxAudioSource.Play();

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

        this.mixer.SetFloat("volumenMixer", -80);

    }

    //Vulve a activar el sonido con el valor guardado.
    public void Desenmudecer()
    {
        Debug.Log(PlayerPrefs.GetFloat("volumen", 0.5f) + " Volumen");
        this.mixer.SetFloat("volumenMixer", PlayerPrefs.GetFloat("volumen", 0.5f));
        this.fxAudioSource.clip = clip[3];
        this.fxAudioSource.Play();
    }
    
    //Cambia el volumen del mixer.
    public void volumen(float volumen)
    {
        Debug.Log(PlayerPrefs.GetFloat("volumen", 0.5f) + " Volumen cambiando");
        PlayerPrefs.SetFloat("volumen", volumen);
        this.mixer.SetFloat("volumenMixer", volumen*80 - 80);

    }

}
