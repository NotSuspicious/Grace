using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pink : Interactable
{

    private GameManager gm;
    private CutsceneManager cm;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameManager.Instance;
        cm = CutsceneManager.Instance;
        SetMessage("TO GIVE PINK HER RIBBON");
    }

    public override void Interact()
    {
        if(gm.itemOnHand == GameItem.RIBBON){
            gm.SetItem(GameItem.EMPTY);
            cm.PlayVideo(Cutscenes.PINK);
        } else {

        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
