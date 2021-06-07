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
    }
}
