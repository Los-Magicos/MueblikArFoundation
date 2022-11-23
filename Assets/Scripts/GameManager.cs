using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    public event Action OnMainHUD;
    public event Action OnItemsMenu;
    public event Action OnARPosition;

    public static GameManager instance;
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else 
        { 
            instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void MainHUD() 
    {
        OnMainHUD?.Invoke();
        Debug.Log("Main Menu Activado");
    }
    public void ItemsMenu()
    {
        OnItemsMenu?.Invoke();
        Debug.Log("Items Menu Activado");
    }
    public void ARPosition()
    {
        OnARPosition?.Invoke();
        Debug.Log("Ar position Activado");
    }

}
