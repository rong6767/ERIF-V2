using System.Collections;
using System.Collections.Generic;
using HFPS.Player;
using UnityEngine;

public class ZombieRespawner : MonoBehaviour
{
    public FlashlightItem flashlightItem;

    public Transform PlayerTransform;
    // Start is called before the first frame update
    void Start()
    {
        flashlightItem.OnFlashlightOut += OnFlashlightOutReceived;
        gameObject.SetActive(false);
    }
    
    void OnFlashlightOutReceived()
    {
        gameObject.SetActive(true);
        transform.position = PlayerTransform.position + PlayerTransform.forward;
        transform.position = new Vector3(transform.position.x,-0.5f,transform.position.z);
        transform.rotation = PlayerTransform.rotation*Quaternion.Euler(0,-180,0);
    }

}
