using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinStateActivation : MonoBehaviour
{
    [SerializeField]
    private GameObject _winLevelCutscene;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Player")
        {
            if(GameManager.Instance.HasCard==true)
            {
                _winLevelCutscene.SetActive(true);
            }
            else
            {
                Debug.Log("You must have a card");
            }
        }
    }
}
