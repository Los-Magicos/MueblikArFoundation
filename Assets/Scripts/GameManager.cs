using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public event Action onmainmenu;
    public event Action onitemsmenu;
    public event Action onarposition;
    public static GameManager instance;
    // Start is called before the first frame update
    private void Awake()
    {
        if ( instance != null && instance != this )
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }
    void Start()
    {
        Mainmenu();
    }
    public void Mainmenu()
    {
        onmainmenu?.Invoke();
        Debug.Log("main menu activated");
    }
    public void itemsmenu()
    {
        onitemsmenu?.Invoke();
        Debug.Log("items menu activated");
    }
    public void ARposition()
    {
        onarposition?.Invoke();
        Debug.Log("on ar activated");
    }
    public void closeapp()
    {
        SceneManager.LoadScene("MenuInicial");
    }
}
