using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurpleChase : MonoBehaviour
{
    private GameManager gm;
    private CutsceneManager cm;
    public bool hasPlayed;
    public Behaviour agentBehaviour;

    void Start()
    {
        hasPlayed = false;
        gm = GameManager.Instance;
        cm = CutsceneManager.Instance;
        agentBehaviour.enabled = false;
    }

   private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!hasPlayed){
            cm.PlayVideo(Cutscenes.PURPLE2);
            hasPlayed = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        agentBehaviour.enabled = true;
    }
}
