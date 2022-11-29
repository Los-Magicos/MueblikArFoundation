using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    [SerializeField] private List<Item> items = new List<Item>();
    [SerializeField] private GameObject botoncontainer;
    [SerializeField] private ItemButtonManager buttonmanager;
    // Start is called before the first frame update
    void Start()
    {
        GameManager.instance.onitemsmenu += crearbotons;
    }

    private void crearbotons()
    {
        foreach (Item item in items)
        {
            ItemButtonManager iboton;
            iboton = Instantiate(buttonmanager, botoncontainer.transform);
            iboton.Itemname = item.ItemName;
            iboton.Itemimage = item.ItemImage;
            iboton.Itemdescription = item.ItemDescription;
            iboton.Item3dmodel = item.Item3DModel;
            iboton.name = item.ItemName;


        }
        GameManager.instance.onitemsmenu -= crearbotons;
    }
}
