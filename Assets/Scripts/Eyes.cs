using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eyes : MonoBehaviour
{
    [SerializeField]
    private GameObject gameOverCutscene;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Player")
        {
            gameOverCutscene.SetActive(true);
            gameObject.transform.parent.gameObject.transform.parent.gameObject.SetActive(false);
        }
    }
}
