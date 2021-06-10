﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabKeyCardActiavtion : MonoBehaviour
{
    [SerializeField]
    private GameObject _sleepingGuardCutscene;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Player")
        {
            _sleepingGuardCutscene.SetActive(true);
        }
    }
    
}
