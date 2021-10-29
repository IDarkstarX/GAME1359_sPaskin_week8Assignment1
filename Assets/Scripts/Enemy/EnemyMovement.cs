using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyMovement : MonoBehaviour
{
    Transform target;
    PlayerHealth playerHealth;
    EnemyHealth enemyHealth;
    UnityEngine.AI.NavMeshAgent nav;


    public List<GameObject> players = new List<GameObject>();

    void Awake ()
    {
        players.AddRange(GameObject.FindGameObjectsWithTag("Player"));
        target = GameObject.FindGameObjectWithTag ("Player").transform;
        playerHealth = target.GetComponent <PlayerHealth> ();
        enemyHealth = GetComponent <EnemyHealth> ();
        nav = GetComponent <UnityEngine.AI.NavMeshAgent> ();
    }


    void Update ()
    {
        
        float shortestDist = float.MaxValue;
        for (int i = 0; i < players.Count; i++)
        {
            float dist = Vector3.Distance(this.transform.position, players[i].transform.position);
            if (dist < shortestDist)
            {
                target = players[i].transform;
                shortestDist = dist;
            }
        }

        if (enemyHealth.currentHealth > 0 && playerHealth.currentHealth > 0)
        {
            nav.SetDestination (target.position);
        }
        else
        {
            nav.enabled = false;
        }
    }
}
