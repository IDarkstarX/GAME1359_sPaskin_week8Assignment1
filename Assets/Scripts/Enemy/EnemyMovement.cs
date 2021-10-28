using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour
{
    Transform target;
    PlayerHealth playerHealth;
    EnemyHealth enemyHealth;
    UnityEngine.AI.NavMeshAgent nav;


    void Awake ()
    {
        target = GameObject.FindGameObjectWithTag ("Player").transform;
        playerHealth = target.GetComponent <PlayerHealth> ();
        enemyHealth = GetComponent <EnemyHealth> ();
        nav = GetComponent <UnityEngine.AI.NavMeshAgent> ();
    }


    void Update ()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        float shortestDist = float.MaxValue;
        for (int i = 0; i < players.Length; i++)
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
