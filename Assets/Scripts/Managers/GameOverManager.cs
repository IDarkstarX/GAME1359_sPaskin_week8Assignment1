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

    void Awake()
    {
        anim = GetComponent<Animator>();
    }


    void Update()
    {
        /*
        for (int i = 0; i < playerHealth.Length; i++) {
            Debug.Log("Checking if players are alive...");
            if (playerHealth[i].currentHealth < 0)
            {
                Debug.Log("A player has died! D:");
                deadPlayerCount++;
                return;
            }
        }
        */

        if(playerHealth[0].currentHealth < 0 && !p1Dead)
        {
            deadPlayerCount++;
            p1Dead = true;
        }
        if (playerHealth[1].currentHealth < 0 && !p2Dead)
        {
            deadPlayerCount++;
            p2Dead = true;
        }

        if (deadPlayerCount >= alivePlayers)
        {
            Debug.Log("Test");
            restartTimer += Time.deltaTime;
            anim.SetTrigger("GameOver");
        }

        if (restartTimer >= restartDelay)
        {
            Application.LoadLevel(Application.loadedLevel);
        }
    }
}
