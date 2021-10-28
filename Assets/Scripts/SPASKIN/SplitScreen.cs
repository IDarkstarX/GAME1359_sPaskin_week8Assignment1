using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplitScreen : MonoBehaviour
{
    [SerializeField]
    Camera cam1;
    [SerializeField]
    Camera cam2;

    public int numPlayers = 1;

    [SerializeField]
    GameObject player2;

    [SerializeField]
    float singleplayer = 1;

    // Start is called before the first frame update
    void Start()
    {
        //cam1.rect = new Rect(0, 0, 0.5f, 1);
        //cam2.rect = new Rect(0.5f, 0, 0.5f, 1);
    }

    // Update is called once per frame
    void Update()
    {
        
        cam1.rect = new Rect(0, 0, singleplayer, 1);
        cam2.rect = new Rect(0.5f, 0, singleplayer, 1);

        if(Input.GetButton("HotJoin") && numPlayers == 1)
        {
            numPlayers++;

            GameObject.FindGameObjectWithTag("playerNumber").gameObject.GetComponent<GameOverManager>().alivePlayers = 2;

            player2.SetActive(true);
            singleplayer = 0.5f;
        }


    }
}
