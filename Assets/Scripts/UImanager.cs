using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class UImanager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject mainmenucanvas;
    [SerializeField] private GameObject itemsmenucanvas;
    [SerializeField] private GameObject arcanvas;
    void Start()
    {
        GameManager.instance.onmainmenu += activate_main_menu;
        GameManager.instance.onitemsmenu += activate_items_menu;
        GameManager.instance.onarposition += activate_ar_menu;
    }
    private void activate_main_menu()
    {
        mainmenucanvas.transform.GetChild(0).transform.DOScale(new Vector3(1,1,1),0.3f);
        mainmenucanvas.transform.GetChild(1).transform.DOScale(new Vector3(1, 1, 1), 0.3f);
        mainmenucanvas.transform.GetChild(2).transform.DOScale(new Vector3(1, 1, 1), 0.3f);
       
        itemsmenucanvas.transform.GetChild(0).transform.DOScale(new Vector3(0,0,0), 0.5f);
        itemsmenucanvas.transform.GetChild(1).transform.DOScale(new Vector3(0, 0, 0), 0.5f);
        itemsmenucanvas.transform.GetChild(1).transform.DOMoveY(765, 0.5f);
        
        arcanvas.transform.GetChild(0).transform.DOScale(new Vector3(0,0,0),0.5f);
        arcanvas.transform.GetChild(1).transform.DOScale(new Vector3(0,0,0),0.5f);
    }
    private void activate_items_menu()
    {
        mainmenucanvas.transform.GetChild(0).transform.DOScale(new Vector3(0, 0, 0), 0.3f);
        mainmenucanvas.transform.GetChild(1).transform.DOScale(new Vector3(0, 0, 0), 0.3f);
        mainmenucanvas.transform.GetChild(2).transform.DOScale(new Vector3(0, 0, 0), 0.3f);

        itemsmenucanvas.transform.GetChild(0).transform.DOScale(new Vector3(1, 1, 1), 0.5f);
        itemsmenucanvas.transform.GetChild(1).transform.DOScale(new Vector3(1, 1, 1), 0.5f);
        itemsmenucanvas.transform.GetChild(1).transform.DOMoveY(490 , 0.5f);
    }
    private void activate_ar_menu()
    {
        mainmenucanvas.transform.GetChild(0).transform.DOScale(new Vector3(0, 0, 0), 0.3f);
        mainmenucanvas.transform.GetChild(1).transform.DOScale(new Vector3(0, 0, 0), 0.3f);
        mainmenucanvas.transform.GetChild(2).transform.DOScale(new Vector3(0, 0, 0), 0.3f);

        itemsmenucanvas.transform.GetChild(0).transform.DOScale(new Vector3(0, 0, 0), 0.5f);
        itemsmenucanvas.transform.GetChild(1).transform.DOScale(new Vector3(0, 0, 0), 0.5f);
        itemsmenucanvas.transform.GetChild(1).transform.DOMoveY(765, 0.3f);

        arcanvas.transform.GetChild(0).transform.DOScale(new Vector3(1, 1, 1), 0.5f);
        arcanvas.transform.GetChild(1).transform.DOScale(new Vector3(1, 1, 1), 0.5f);
        
    }
}
