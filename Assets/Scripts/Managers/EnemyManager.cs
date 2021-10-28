using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public PlayerHealth[] playerHealth;
    public GameObject enemy;
    public float spawnTime = 3f;
    public Transform[] spawnPoints;

    [SerializeField]
    GameObject GGController;

    void Start ()
    {
        InvokeRepeating ("Spawn", spawnTime, spawnTime);
    }


    void Spawn ()
    {

        if(GGController.GetComponent<GameOverManager>().deadPlayerCount >= GGController.GetComponent<GameOverManager>().alivePlayers)
        {
            return;
        }

        int spawnPointIndex = Random.Range (0, spawnPoints.Length);

        Instantiate (enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
    }
}
