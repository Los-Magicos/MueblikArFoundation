using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class ControladorMusica : MonoBehaviour
{

    public static ControladorMusica instancia;

    [SerializeField] private AudioSource fxAudioSource;
    [SerializeField] private AudioSource musicAudioSource;
    [SerializeField] private List<AudioClip> clip;

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
        
    }

    public void sonidoBoton()
    {
        this.fxAudioSource.clip = clip[0];
        this.fxAudioSource.Play();
    }

    public void sonidoPartida()
    {
        this.fxAudioSource.clip = clip[1];
        this.fxAudioSource.Play();
    }

}
