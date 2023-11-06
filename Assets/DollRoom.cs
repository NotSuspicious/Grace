using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DollRoom : MonoBehaviour
{

    private GameManager GM;
    public Room room;

    public string doll;
    public updatePortrait up;
    // Start is called before the first frame update
    void Awake()
    {
        GM = GameManager.Instance;
    }

      void OnEnable()
    {
        GameManager.onRoomChange += onRoomChange;
    }

    void OnDisable()
    {
        GameManager.onRoomChange -= onRoomChange;
    }

    void onRoomChange()
    {
        
    }

    void ShowRoom()
    {

    }

    void HideRoom()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
    
        if(doll != "")
            up.onPortraitChange(doll);
        
        GM.SetGameState(GameState.INSIDE_ROOM);
        GM.SetRoom(room);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {   
        up.onPortraitChange("stalker");
        GM.SetGameState(GameState.PLAYING);
        GM.SetRoom(Room.HALLWAY);
    }
}


