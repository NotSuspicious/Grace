using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Openable : Interactable
{
    public Sprite open;
    public Sprite closed;

    private SpriteRenderer sr;
    private bool isOpen;
    public GameObject collider;

    private GameManager gm;
    private CutsceneManager cm;

    public string doorType;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameManager.Instance;
        cm = CutsceneManager.Instance;
        sr = GetComponent<SpriteRenderer>();
        sr.sprite = closed;
    }

    public override void Interact()
    {
        if(gm.itemOnHand == GameItem.KEY){
            if(isOpen){
                sr.sprite = closed;
                collider.SetActive(true);
            }
            
            else{
                sr.sprite = open;
                collider.SetActive(false);
            }
            isOpen = !isOpen;
        }
        
        
        
    }
}
