using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class updateItem : MonoBehaviour
{
    private GameManager gm;
    [SerializeField]
    private Sprite ribbon, key, scissors, cutScissors, empty;

    public Image item;


    void OnEnable()
    {
        GameManager.onItemChange += onItemChange;
    }

    void OnDisable()
    {
        GameManager.onItemChange -= onItemChange;
    }

    void onItemChange()
    {
        switch(gm.itemOnHand.ToString()){
            case "RIBBON":
                item.sprite = ribbon;
                break;
            case "SCISSORS":
                item.sprite = scissors;
                break;
            case "CUT_SCISSORS":
                item.sprite = cutScissors;
                break;
            case "KEY":
                item.sprite = key;
                break;
            case "EMPTY":
                item.sprite = empty;
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
