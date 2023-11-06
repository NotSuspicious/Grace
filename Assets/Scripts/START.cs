using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class START : MonoBehaviour
{
    private GameManager gm;
    private CutsceneManager cm;
    public Behaviour agentBehaviour;
    public bool hasPlayed;

    void Start()
    {
        hasPlayed = false;
        gm = GameManager.Instance;
        cm = CutsceneManager.Instance;
    }

   private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!hasPlayed){
            cm.PlayVideo(Cutscenes.STALKER);
            hasPlayed = true;
        }
    }
}
