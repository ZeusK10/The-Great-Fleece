using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    private NavMeshAgent agent;
    private Animator _animator;
    RaycastHit hitInfo;
    Ray rayOrigin;
    float dist;
    [SerializeField]
    private GameObject coinPrefab;
    [SerializeField]
    AudioClip coinAudio;
    private bool coinDropped;

    void Start()
    {
        _animator = gameObject.GetComponentInChildren<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            rayOrigin = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(rayOrigin,out hitInfo))
            {
                agent.destination = hitInfo.point;
                _animator.SetBool("Walk", true);
            }
        }

        dist = Vector3.Distance(hitInfo.point, transform.position); 
        if (dist<1)
        {
            _animator.SetBool("Walk", false);
        }

        if(coinDropped==false)
        {
            if (Input.GetMouseButtonDown(1))
            {
                rayOrigin = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(rayOrigin, out hit))
                {
                    _animator.SetTrigger("Throw");
                    coinDropped = true;
                    Instantiate(coinPrefab, hit.point, Quaternion.identity);
                    AudioSource.PlayClipAtPoint(coinAudio, transform.position);
                    CoinTossed(hit.point);
                }
                
            }
        }
        
    }

    void CoinTossed(Vector3 coinPos)
    {
        GameObject[] guards = GameObject.FindGameObjectsWithTag("Guard1");
        foreach(var guard in guards)
        {
            GuardAI guardScript = guard.GetComponent<GuardAI>();
            guardScript.SomethingIsWrong(coinPos);
        }
    }
}
