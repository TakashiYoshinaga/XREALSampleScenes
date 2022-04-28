using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NRKernal;
public class ShootBullet : MonoBehaviour
{
    public GameObject bulletPrefab;
    GameObject bullet;
    // Start is called before the first frame update
    void Start()
    {
        NRInput.AddClickListener(
            ControllerHandEnum.Right,
            ControllerButton.TRIGGER, () => {
                if (bullet != null) DestroyImmediate(bullet);
                bullet = GameObject.Instantiate(bulletPrefab);
                bullet.transform.position = transform.position;
                bullet.GetComponent<Rigidbody>().AddForce(transform.forward * 8f, ForceMode.Impulse);
            }
        );
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
