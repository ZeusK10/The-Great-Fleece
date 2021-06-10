using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecurityCamera : MonoBehaviour
{
    [SerializeField]
    private GameObject gameOverCutscene;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Player")
        {
            other.gameObject.SetActive(false);
            Color color = new Color(1f, 0.07f, 0f, 0.011f);
            gameObject.GetComponent<MeshRenderer>().material.SetColor("_TintColor", color);
            GameObject.Find("Security_Guards").SetActive(false);
            gameObject.transform.parent.gameObject.GetComponent<Animator>().enabled = false;
            StartCoroutine(StartCapturedCutscene());
        }
    }

    IEnumerator StartCapturedCutscene()
    {
        yield return new WaitForSeconds(0.5f);
        gameOverCutscene.SetActive(true);
    }
}
