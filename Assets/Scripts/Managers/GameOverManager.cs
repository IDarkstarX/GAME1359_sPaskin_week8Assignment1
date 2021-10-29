using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    public PlayerHealth [] playerHealth;
	public float restartDelay = 5f;

    public int alivePlayers = 1;
    public int deadPlayerCount = 0;

    Animator anim;
	float restartTimer;

    bool p1Dead = false;
    bool p2Dead = false;

    [SerializeField]
    GameObject[] baddieMovers;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }


    void Update()
    {
        baddieMovers = GameObject.FindGameObjectsWithTag("baddie");
        
        for (int i = 0; i < baddieMovers.Length; i++) {

            baddieMovers[i].GetComponent<EnemyMovement>();
        }

        if (playerHealth[0].currentHealth <= 0 && !p1Dead)
        {
            deadPlayerCount++;
            p1Dead = true;

            for (int i = 0; i < baddieMovers.Length; i++)
            {

                baddieMovers[i].GetComponent<EnemyMovement>().players.Remove(GameObject.Find("Player 1"));
            }

        }
        if (playerHealth[1].currentHealth <= 0 && !p2Dead)
        {
            deadPlayerCount++;
            p2Dead = true;

            for (int i = 0; i < baddieMovers.Length; i++)
            {

                baddieMovers[i].GetComponent<EnemyMovement>().players.Remove(GameObject.Find("Player 2"));
            }

        }

        if (deadPlayerCount >= alivePlayers)
        {
            Debug.Log("Test");
            anim.SetTrigger("GameOver");
            restartTimer += Time.deltaTime;
        }

        if (restartTimer >= restartDelay)
        {
            Application.LoadLevel(Application.loadedLevel);
        }
    }
}
