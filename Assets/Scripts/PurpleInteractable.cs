using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurpleInteractable : Interactable
{

    private GameManager gm;
    private CutsceneManager cm;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameManager.Instance;
        cm = CutsceneManager.Instance;
        SetMessage("TO GIVE SCISSORS");
    }

    public override void Interact()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
