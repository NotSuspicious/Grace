using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stalker : MonoBehaviour
{
    public Transform stalker;
    public Transform spawnPoint;
    public Transform purpleSpawnPoint;
    private GameManager gm;
    private CutsceneManager cm;
    public AgentMovement agent;
    public Behaviour agentBehaviour;

    void OnEnable()
    {
        GameManager.onStateChange += onStateChange;
        GameManager.onRoomChange += onRoomChange;
    }

    void OnDisable()
    {
        GameManager.onStateChange -= onStateChange;
        GameManager.onRoomChange -= onRoomChange;
    }

    void onStateChange()
    {
        
        
    }

    void onRoomChange()
    {
        if(gm.currentRoom == Room.PURPLE_ROOM){
            updatePosition(purpleSpawnPoint);
        }
        if(gm.currentRoom == Room.HALLWAY){
            agent.resumeNav();   
        } else {
            agent.pauseNav(); 
        }
    }

    // Start is called before the first frame update
    void Awake()
    {
        gm = GameManager.Instance;
        cm = CutsceneManager.Instance;
    }

    void updatePosition(Transform destination)
    {
        agentBehaviour.enabled = false;
        stalker.position = destination.position;
        agentBehaviour.enabled = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player")){
            gm.DecrementHealth();
            gm.resetPlayer();
            updatePosition(spawnPoint);
        }
    }
}
