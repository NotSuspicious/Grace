using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurpleChaseEnd : MonoBehaviour
{
    private GameManager gm;
    private CutsceneManager cm;
    private bool hasPlayed;

    public PurpleChase pc;
    public Behaviour agentBehaviour;

    void Start()
    {
        hasPlayed = false;
        gm = GameManager.Instance;
        cm = CutsceneManager.Instance;
        
    }

   private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!hasPlayed){
            cm.PlayVideo(Cutscenes.PURPLE1);
            hasPlayed = true;
        }
        agentBehaviour.enabled = false;
    }
}
