using DG.Tweening.Plugins.Options;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class Arinteractionmanager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Camera arcamera;
    private ARRaycastManager raycastManager;
    private List<ARRaycastHit> hits = new List<ARRaycastHit>();
    private GameObject arpointer;
    private GameObject item3dmodel;
    private GameObject item_seleccionado;
    private bool initpos;
    private bool in_ui;
    private Vector2 init_t_pos;
    private bool isover3dmodel;
    

    public GameObject Item3dmodel
    {
        set
        {
            item3dmodel = value;
            item3dmodel.transform.position = arpointer.transform.position;
            item3dmodel.transform.parent = arpointer.transform;
            initpos = true; 
        }
    }
    void Start()
    {
        arpointer = transform.GetChild(0).gameObject;
        raycastManager = FindObjectOfType<ARRaycastManager>();
        GameManager.instance.onmainmenu += setitempos;
    }

    private void setitempos()
    {
        if (item3dmodel!=null)
        {
            item3dmodel.transform.parent = null;
            arpointer.SetActive(false);
            item3dmodel=null;
        }
    }
    public void deleteitem()
    {
        Destroy(item3dmodel);
        arpointer.SetActive(false);
        GameManager.instance.Mainmenu();
    }

    // Update is called once per frame
    void Update()
    {
        if ( initpos )
        {
            Vector2 middle = new Vector2(Screen.width / 2, Screen.height / 2);
            raycastManager.Raycast(middle, hits, TrackableType.Planes);
            if (hits.Count > 0)
            {
                transform.position = hits[0].pose.position;
                transform.rotation = hits[0].pose.rotation;
                arpointer.SetActive(true);
                initpos = false;
            }
        }
        if (Input.touchCount>0)
        {
            Touch touchone = Input.GetTouch(0);
            if (touchone.phase == TouchPhase.Began)
            {
                var touchpos = touchone.position;
                in_ui = tapui(touchpos);
                isover3dmodel = Tap_over(touchpos);
            }

            if ( touchone.phase == TouchPhase.Moved )
            {
                if (raycastManager.Raycast(touchone.position,hits,TrackableType.Planes))
                {
                    Pose hitpose = hits[0].pose;
                    if  (!in_ui && isover3dmodel)
                    {
                        transform.position = hitpose.position;
                    }
                }
            }

            if (Input.touchCount == 2)
            {
                Touch touch_two = Input.GetTouch(1);
                if (touchone.phase == TouchPhase.Began || touch_two.phase == TouchPhase.Began)
                {
                    init_t_pos = touch_two.position - touchone.position;
                }
                if (touchone.phase == TouchPhase.Moved || touch_two.phase == TouchPhase.Moved)
                {
                    Vector2 currentpos = touch_two.position - touchone.position;
                    float angle = Vector2.SignedAngle(init_t_pos,currentpos);
                    item3dmodel.transform.rotation = Quaternion.Euler(0,item3dmodel.transform.eulerAngles.y-angle,0);
                    init_t_pos = currentpos; 
                }
            }
            if ( isover3dmodel && item3dmodel == null && !in_ui)
            {
                GameManager.instance.ARposition();
                item3dmodel = item_seleccionado;
                item_seleccionado = null;
                arpointer.SetActive(true);
                transform.position = item3dmodel.transform.position;
                item3dmodel.transform.parent = arpointer.transform;
            }
        }
    }

    private bool Tap_over(Vector2 touchposition)
    {
        bool a = false;
        Ray racho = arcamera.ScreenPointToRay(touchposition);
        if ( Physics.Raycast(racho, out RaycastHit thehit ) )
        {
            if (thehit.collider.CompareTag("Item"))
            {
                item_seleccionado = thehit.transform.gameObject;
                a = true;
            }
        }
        else
        {
            a = false;
        }
        return a;
    }

    private bool tapui(Vector2 touchpos)
    {
        PointerEventData edata = new PointerEventData(EventSystem.current);
        edata.position = new Vector2(touchpos.x, touchpos.y);
        List<RaycastResult> result = new List<RaycastResult> ();
        EventSystem.current.RaycastAll(edata, result);
        return result.Count > 0;
    }
}
