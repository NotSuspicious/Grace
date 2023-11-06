using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : Interactable
{
    [SerializeField]
    private GameItem itemType;

    private GameManager gameManager;

    public override void Interact()
    {
        gameManager.SetItem(itemType);
        Destroy(gameObject);
    }
    void Start()
    {
        gameManager = GameManager.Instance;
        SetMessage("TO PICK UP");
    }
}
