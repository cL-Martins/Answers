using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public enum States
{
    Locked, Chasing, FullShadow, Walking
}
public class Monster : MonoBehaviour
{
    public float range;
    NavMeshAgent agent;
    States ia;
    GameObject player;
    float distance, rangeFullShadow, timeDecision;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        agent = GetComponent<NavMeshAgent>();
        ia = States.Walking;
    }

    // Update is called once per frame
    void Update()
    {
        switch (ia)
        {
            case States.Locked:

                break;
            case States.Chasing:
                agent.SetDestination(player.transform.position);
                break;
            case States.FullShadow:

                break;
            case States.Walking:
                timeDecision += Time.deltaTime;
                DetectPlayer();
                if (timeDecision > 3)
                {
                    StartCoroutine("DefaultMoviment");
                    timeDecision = 0;
                }
                break;
        }
    }
    void DetectPlayer()
    {
        distance = Vector3.Distance(player.transform.position, transform.position);
            if (distance < range)
            {
                ia = States.Chasing;
            } else
            {
                ia = States.Walking;
            }
    }
    IEnumerator DefaultMoviment()
    {
        agent.SetDestination(RandomNavmeshLocation(40f));
        yield return new WaitForSeconds(10);

    }
    public Vector3 RandomNavmeshLocation(float radius)
    {
        Vector3 randomDirection = Random.insideUnitSphere * radius;
        randomDirection += transform.position;
        NavMeshHit hit;
        Vector3 finalPosition = Vector3.zero;
        if (NavMesh.SamplePosition(randomDirection, out hit, radius, 1))
        {
            finalPosition = hit.position;
        }
        return finalPosition;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ia = States.Chasing;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        DetectPlayer();
    }
}
