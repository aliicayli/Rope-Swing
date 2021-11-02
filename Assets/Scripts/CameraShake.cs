using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraShake : MonoBehaviour
{
    //Camera shake effect when passing through the rings.

    public float timeOfShake;
    public float powerOfShake;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("FireBallRedCollider") || other.gameObject.CompareTag("FireBallPurpleCollider"))
        {
            Camera.main.DOShakeRotation(timeOfShake, powerOfShake, fadeOut: true);
        }
    }
}
