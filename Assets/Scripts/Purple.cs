using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Purple : MonoBehaviour
{
    public Transform purple;
    public Transform spawnPoint;
    private GameManager gm;
    private CutsceneManager cm;

    public Behaviour agentBehaviour;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Awake()
    {
        gm = GameManager.Instance;
        cm = CutsceneManager.Instance;
    }

        void OnEnable()
    {
        GameManager.onStateChange += onStateChange;
    }

    void OnDisable()
    {
        GameManager.onStateChange -= onStateChange;
    }

    void onStateChange()
    {

    }

    void FixedUpdate()
    {  
        
    }

    void updatePosition(Transform destination)
    {
        agentBehaviour.enabled = false;
        purple.position = destination.position;
        agentBehaviour.enabled = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player")){
            gm.DecrementHealth();
            gm.resetPlayer();
            updatePosition(spawnPoint);
            agentBehaviour.enabled = false;
        }
    }
}
