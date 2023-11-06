using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class updateStatus : MonoBehaviour
{
    private GameManager gm;
    [SerializeField]
    private Sprite status6, status5, status4, status3, status2, status1;

    public Image status;

    

    public void onStatusChange()
    {
        switch(gm.playerHealth){
            case 6:
                status.sprite = status6;
                break;
            case 5:
                status.sprite = status5;
                break;
            case 4:
                status.sprite = status4;
                break;
            case 3:
                status.sprite = status3;
                break;
            case 2:
                status.sprite = status2;
                break;
            case 1:
                status.sprite = status1;
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
