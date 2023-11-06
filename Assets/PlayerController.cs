using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{

    public Animator animator;

    public float moveSpeed = 1f;
    public float collisionOffset = 0.05f;
    public ContactFilter2D movementFilter;
    Vector2 movementInput;
    Rigidbody2D rb;
    List <RaycastHit2D> castCollisions = new List<RaycastHit2D>();

    private Vector2 boxSize = new Vector2(0.1f, 1f);

    public GameObject interactIcon;
    public TMP_Text interactMessage;

    private GameManager gm;

    


    // Start is called before the first frame update
    void Start()
    {
        gm = GameManager.Instance;
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if(gm.gameState == GameState.CUTSCENE)
            return;
        if(movementInput != Vector2.zero){
            bool success = TryMove(movementInput);
            if(!success) {
                success = TryMove(new Vector2(movementInput.x, 0));
                if(!success) {
                    success = TryMove(new Vector2(0, movementInput.y));
                }
            }

            animator.SetBool("isMoving", success);
        } else {
            animator.SetBool("isMoving", false);
        }
    }

    private bool TryMove(Vector2 direction)
    {
        
        int count = rb.Cast(
            movementInput,
            movementFilter,
            castCollisions,
            moveSpeed * Time.fixedDeltaTime + collisionOffset
        );

        if(count == 0){
            rb.MovePosition(rb.position + movementInput * moveSpeed * Time.fixedDeltaTime);
            return true;
        } else return false;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E)){
            CheckInteraction();
        }
    }

    void OnMove(InputValue movementValue)
    {
        movementInput = movementValue.Get<Vector2>();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.CompareTag("Door")){
            collider.gameObject.GetComponent<Interactable_Door>().openDoor();
        }
        
    }


    void OnTriggerStay2D(Collider2D collider)
    {

    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if(collider.CompareTag("Door")){
            collider.gameObject.GetComponent<Interactable_Door>().closeDoor();
        }
    }

    public void Interact()
    {

    }

    public void CheckInteraction()
    {
        RaycastHit2D[] hits = Physics2D.BoxCastAll(
            transform.position, boxSize, 0, Vector2.zero);

        if(hits.Length > 0){
            foreach(RaycastHit2D rc in hits){
                if(rc.transform.GetComponent<Interactable>()){
                    rc.transform.GetComponent<Interactable>().Interact();
                    return;
                }
            }
        }
    }
    
    public void OpenInteractable(string message)
    {
        interactIcon.SetActive(true);
        interactMessage.transform.gameObject.SetActive(true);
        SetInteractableMessage(message);
    }

    public void CloseInteractable()
    {
        interactIcon.SetActive(false);
        interactMessage.transform.gameObject.SetActive(false);
    }

    public void SetInteractableMessage(string message)
    {
        interactMessage.text = message;
    }



    
}
