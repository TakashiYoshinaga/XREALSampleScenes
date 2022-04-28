using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NRKernal;
using UnityEngine.EventSystems;

public class Manipulation : MonoBehaviour,IPointerDownHandler,IPointerUpHandler
{
    public Transform controller;
    Transform base_parent;
    bool selected = false;
    public float moveSpee = 0.08f;
    public float rotSPeed = -20.0f;
    public void OnPointerDown(PointerEventData eventData)
    {
        selected = true;
        transform.parent = controller;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        selected = false;
        transform.parent = base_parent;
    }

    // Start is called before the first frame update
    void Start()
    {
        base_parent = transform.parent;
    }

    // Update is called once per frame
    void Update()
    {
        if (!selected) return;
        Vector2 p = NRInput.GetTouch();
        if (Mathf.Abs(p.y) > 0.6)
        {
            transform.Translate(Mathf.Sign(p.y) * controller.forward * moveSpee * Time.deltaTime);
        }else if (Mathf.Abs(p.x) > 0.6)
        {
            transform.Rotate(0, Mathf.Sign(p.x) * rotSPeed * Time.deltaTime, 0, Space.Self);
        }
    }
}
