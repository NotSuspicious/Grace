using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public enum Cutscenes {INTRO, PINK, STALKER, PURPLE1, PURPLE2, ENDING}
public class CutsceneManager : MonoBehaviour
{
    [SerializeField]
    private VideoClip intro, pink, stalker, purple1, purple2, ending;

    [SerializeField]
    private VideoPlayer player;
    [SerializeField]
    private GameObject output;

    private GameManager gm;

    public static CutsceneManager Instance {get; private set;}

    public void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(this);
        } else {
            Instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        player.loopPointReached += EndReached;
        gm = GameManager.Instance;
        PlayVideo(intro);
    }

    void EndReached(VideoPlayer vp)
    {
        player.clip = null;
        output.SetActive(false);
        gm.SetGameState(GameState.INSIDE_ROOM);
    }

    public void PlayVideo(Cutscenes c)
    {
        switch(c.ToString()){
            case "PINK":
                player.clip = pink;
                break;
            case "STALKER":
                player.clip = stalker;
                break;
            case "PURPLE1":
                player.clip = purple1;
                break;
            case "PURPLE2":
                player.clip = purple2;
                break;
            case "ENDING":
                player.clip = ending;
                break;
            case "INTRO":
                player.clip = intro;
                break;
            Debug.Log("No video found with that enum");
            break;
        }
        if(player.clip == null){
            Debug.LogError("No clip assigned!");
            return;
        }
        output.SetActive(true);
        gm.SetGameState(GameState.CUTSCENE);
        player.Play();
        
    }

    //PlayVideo overload
    public void PlayVideo(VideoClip c)
    {
        player.clip = c;
        if(player.clip == null){
            Debug.LogError("No clip assigned!");
            return;
        }
        output.SetActive(true);
        gm.SetGameState(GameState.CUTSCENE);
        player.Play();
        
    }

}
