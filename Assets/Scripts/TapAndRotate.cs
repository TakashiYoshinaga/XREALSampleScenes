using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NRKernal;
using UnityEngine.EventSystems;
public class TapAndRotate : MonoBehaviour,IPointerClickHandler
{
    public float speed = 20.0f;
    bool rotate = false;

    public void OnPointerClick(PointerEventData eventData)
    {
        rotate = !rotate;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (rotate)
        {
            transform.Rotate(0, speed * Time.deltaTime, 0, Space.World);
        }
    }
}
