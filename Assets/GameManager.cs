using UnityEngine;
using System.Collections;

// Game States
// for now we are only using these two
public enum GameState { CUTSCENE, PLAYING, INSIDE_ROOM, GAME_OVER}
public enum Room { ENTRANCE, HALLWAY, PINK_ROOM, MIRROR_ROOM, PURPLE_ROOM }
public enum GameItem {RIBBON, SCISSORS, CUT_SCISSORS, KEY, EMPTY}

public delegate void OnStateChangeHandler();

public class GameManager : MonoBehaviour{
    public static GameManager Instance {get; private set;}
    public delegate void OnStateChange();
    public static event OnStateChange onStateChange;

    public delegate void OnItemChange();
    public static event OnItemChange onItemChange;

    public delegate void OnRoomChange();
    public static event OnRoomChange onRoomChange;

    public  GameState gameState { get; private set; }
    public Room currentRoom {get; private set;}

    public int playerHealth;
    public GameItem itemOnHand;

    public Transform player;
    public Transform spawnPoint;

    //UI, TODO: Change into event
    public updateStatus uStatus;

    public void Awake()
    {
        
        if(Instance != null && Instance != this)
        {
            Destroy(this);
        } else {
            Instance = this;
        }
        gameState = GameState.PLAYING;
    }

    public void Start()
    {
        
    }

    public void Update()
    {

    }

    public void SetGameState(GameState state){
        this.gameState = state;
        GameManager.onStateChange();
        Debug.Log(gameState.ToString());
    }

    public void SetItem(GameItem gameItem)
    {
        this.itemOnHand = gameItem;
        GameManager.onItemChange();
    }

    public void SetRoom(Room room)
    {
        currentRoom = room; 
        GameManager.onRoomChange();
        Debug.Log(currentRoom.ToString());
    }

    public void DecrementHealth()
    {
        playerHealth--;
        uStatus.onStatusChange();
    }

    public void OnApplicationQuit(){
        GameManager.Instance = null;
    }

    public void resetPlayer()
    {
        player.position = spawnPoint.position;
    }

}