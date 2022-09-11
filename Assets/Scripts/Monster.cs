using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AI;
public enum States
{
    Locked, Chasing, FullShadow, Walking
}
public class Monster : MonoBehaviour
{
    public Transform[] rooms;
    public float range, distanceInteraction = 3;
    NavMeshAgent agent;
    States ia;
    GameObject player;
    float distance, rangeFullShadow;

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
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, distanceInteraction))
        {
            if (hit.collider.CompareTag("Interact"))
            {
                hit.collider.SendMessage("Interaction");
            }
        }
            switch (ia)
        {
            case States.Locked:

                break;
            case States.Chasing:
                agent.SetDestination(player.transform.position);
                if(agent.remainingDistance <= agent.stoppingDistance + 5)
                {
                    if(Player.lightIntensity > 1)
                    {
                        ia = States.Walking;
                        agent.destination = Vector3.zero;
                    }
                }
                if(agent.remainingDistance <= agent.stoppingDistance)
                {
                    SceneManager.LoadScene("GameOver");
                }
                break;
            case States.FullShadow:

                break;
            case States.Walking:
                DetectPlayer();
                if (agent.destination == null || agent.remainingDistance <= agent.stoppingDistance)
                {
                    Patrol();
                }
                break;
        }
    }
    void Patrol()
    {
       // agent.SetDestination(rooms[Random.Range(0, rooms.Length - 1)].position);
        agent.SetDestination(rooms[7].position);
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
