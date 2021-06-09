using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GuardAI : MonoBehaviour
{
    private NavMeshAgent agent;
    public List<Transform> wayPoints;
    public int currentTarget;
    private bool reverseAI;
    private bool targetReached;
    private Animator _animator;
    private bool guardIsDistracted;
    private Vector3 coinPos;
    // Start is called before the first frame update
    void Start()
    {
        _animator = gameObject.GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (wayPoints.Count>0 && wayPoints[currentTarget] != null && guardIsDistracted == false)
        {
            agent.SetDestination(wayPoints[currentTarget].position);
            if(targetReached==true)
            {
                _animator.SetBool("isWalking", false);
            }
            else
            {
                _animator.SetBool("isWalking", true);
            }
            
            float dist = Vector3.Distance(transform.position, wayPoints[currentTarget].position);
            if (dist < 1.0f && targetReached == false )
            {
                targetReached = true;
                agent.autoBraking = true;
                if (wayPoints.Count>1)
                {
                    StartCoroutine(StopGuardRoutine());
                }
                
            }
        }
        if(guardIsDistracted==true)
        {
            _animator.SetBool("isWalking", true);
            float dist = Vector3.Distance(transform.position, coinPos);
            if (dist < 4.0f)
            {
                agent.autoBraking = true;
                gameObject.GetComponent<NavMeshAgent>().enabled = false;
                _animator.SetBool("isWalking", false);
            }
        }
        
    }

    IEnumerator StopGuardRoutine()
    {
        if (currentTarget == wayPoints.Count - 1)
        {
            
            reverseAI = true;
            
            yield return new WaitForSeconds(Random.Range(2, 6));
            agent.autoBraking = false;
        }
        else if (currentTarget == 0)
        {
            //_animator.SetBool("isWalking", false);
            reverseAI = false;
            //agent.autoBraking = true;
            yield return new WaitForSeconds(Random.Range(2, 6));
            agent.autoBraking = false;
        }

        if (reverseAI == false)
        {
            currentTarget++;
        }
        else
        {
            currentTarget--;
        }
        targetReached = false;
    }

    public void SomethingIsWrong(Vector3 pos)
    {
        guardIsDistracted = true;
        coinPos = pos;
        agent.SetDestination(coinPos);
    }

}
