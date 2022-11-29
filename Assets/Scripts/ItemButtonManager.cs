using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemButtonManager : MonoBehaviour
{
    private string itemname;
    private string itemdescription;
    private Sprite itemimage;
    private GameObject item3dmodel;
    private Arinteractionmanager arinteractionmanager;
    public string Itemname { set { itemname = value; } }
    public string Itemdescription { set { itemdescription = value; } }
    public Sprite Itemimage { set { itemimage = value; } }
    public GameObject Item3dmodel { set { item3dmodel = value; } }
    // Start is called before the first frame update
    void Start()
    {
        transform.GetChild(0).GetComponent<Text>().text = itemname;
        transform.GetChild(1).GetComponent<RawImage>().texture = itemimage.texture;
        transform.GetChild(2).GetComponent<Text>().text=itemdescription;
        var boton = GetComponent<Button>();
        boton.onClick.AddListener(GameManager.instance.ARposition);
        boton.onClick.AddListener(create3d);
        arinteractionmanager=FindObjectOfType<Arinteractionmanager>();
    }

    private void create3d()
    {
      arinteractionmanager.Item3dmodel=  Instantiate(item3dmodel);
    }
}
