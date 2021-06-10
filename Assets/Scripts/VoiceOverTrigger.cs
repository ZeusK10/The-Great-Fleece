using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoiceOverTrigger : MonoBehaviour
{
    [SerializeField]
    private AudioClip _clip;
    private bool isActivated;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Player")
        {
            if(isActivated==false)
            {
                isActivated = true;
                AudioSource.PlayClipAtPoint(_clip, Camera.main.transform.position);
            }
            
        }
        
    }
}
