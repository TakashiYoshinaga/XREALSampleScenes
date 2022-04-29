using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NRKernal;
using UnityEngine.EventSystems;

public class Manipulation : MonoBehaviour,IPointerDownHandler,IPointerUpHandler
{
    //コントローラの位置・姿勢
    [SerializeField] Transform controller;
    //デフォルトの親オブジェクト。未指定(=null)の場合は3D空間そのもの。
    //例えばデフォルトでは頭に追従させたい場合はInspectorからCenterAnchorを割り当てる。
    [SerializeField] Transform base_parent;
    bool selected = false;
    Transform manipulationPos;
    //マニピュレーション中にデフォルトの傾きをキープする場合はtrue (要リファクタリング)
    public bool keepTiltAngle = true;
    //前後移動と左右回転の速度
    public float moveSpeed = 0.08f;
    public float rotSpeed = -20.0f;

    public void OnPointerDown(PointerEventData eventData)
    {
        selected = true;
        if (keepTiltAngle)
        {
            manipulationPos.parent = controller;
        }
        else
        {
            transform.parent = controller;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        selected = false;
        if (keepTiltAngle)
        {
            manipulationPos.parent = base_parent;
        }
        else
        {
            transform.parent = base_parent;
        }
    }
    void Start()
    {
        if (keepTiltAngle)
        {
            manipulationPos = new GameObject().transform;
            manipulationPos.position = transform.position;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (!selected) return;
        Vector2 p = NRInput.GetTouch();
        //コントローラのyの絶対値が0.6より大きければ前後に移動
        if (Mathf.Abs(p.y) > 0.6)
        {
            if (keepTiltAngle)
            {
                manipulationPos.transform.Translate(Mathf.Sign(p.y) * controller.forward * moveSpeed * Time.deltaTime);
            }
            else
            {
                transform.Translate(Mathf.Sign(p.y) * controller.forward * moveSpeed * Time.deltaTime);
            }
        }
        //コントローラのxの絶対値が0.6より大きければ左右に回転
        else if (Mathf.Abs(p.x) > 0.6)
        {
            if (keepTiltAngle)
            {
                transform.Rotate(0, Mathf.Sign(p.x) * rotSpeed * Time.deltaTime, 0, Space.World);
            }
            else
            {
                transform.Rotate(0, Mathf.Sign(p.x) * rotSpeed * Time.deltaTime, 0, Space.Self);
            }
        }

        if (keepTiltAngle)
        {
            transform.position = manipulationPos.transform.position;
        }
    }
}
