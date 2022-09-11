using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AI;
public enum States
{
    Locked, Chasing, FullShadow, Walking, FullChase
}
public class Monster : MonoBehaviour
{
    public Transform[] rooms;
    public float range, distanceInteraction = 3;
    NavMeshAgent agent;
    States ia;
    GameObject player;
    float distance, rangeFullShadow;
    Door doorLocked;

    public States Ia { get => ia; set => ia = value; }

    // Start is called before the first frame update
    void Start()
    {
        doorLocked = GameObject.FindGameObjectWithTag("DoorBoss").GetComponentInChildren<Door>();
        player = GameObject.FindGameObjectWithTag("Player");
        agent = GetComponent<NavMeshAgent>();
        ia = States.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, distanceInteraction))
        {
            if (hit.collider.CompareTag("Interact"))
            {
                //agent.speed = 0;
                hit.collider.SendMessage("Interaction");
                //StartCoroutine("ReAcellerate");
                
            }
        }
            switch (ia)
        {
            case States.Locked:
                if (doorLocked.Open)
                {
                    ia = States.Walking;
                }
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
            case States.FullChase:
                agent.SetDestination(player.transform.position);
                break;
        }
    }
    void Patrol()
    {
        agent.SetDestination(rooms[Random.Range(0, rooms.Length - 1)].position);
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
    IEnumerator ReAcellerate()
    {
        print("oi");
        for(int i = 0; i < agent.speed; i++)
        {
            agent.speed = i / 10;
        }
        yield return new WaitForSeconds(1);
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
