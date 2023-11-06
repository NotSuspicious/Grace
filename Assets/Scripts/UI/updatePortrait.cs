using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class updatePortrait : MonoBehaviour
{
    private GameManager gm;
    [SerializeField]
    private Sprite pink, purple, stalker, empty;

    public Image portrait;

    public void onPortraitChange(string dollName)
    {
        switch(dollName){
            case "pink":
                portrait.sprite = pink;
                break;
            case "purple":
                portrait.sprite = purple;
                break;
            case "stalker":
                portrait.sprite = stalker;
                break;
            case "empty":
                portrait.sprite = empty;
                break;
            break;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        gm = GameManager.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
