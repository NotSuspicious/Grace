using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class END : MonoBehaviour
{
    private GameManager gm;
    private CutsceneManager cm;
    public Behaviour agentBehaviour;

    void Start()
    {
        gm = GameManager.Instance;
        cm = CutsceneManager.Instance;
        
    }

   private void OnTriggerEnter2D(Collider2D collision)
    {
            cm.PlayVideo(Cutscenes.ENDING);
            gm.SetGameState(GameState.GAME_OVER);
    }
}
