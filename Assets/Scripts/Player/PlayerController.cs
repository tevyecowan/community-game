using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed = 3.0f;                          
    Rigidbody2D playerRB;                              
    Animator animator;
    UIInventory playerUIInv;
    public int power = 2;
    Vector2 left = new Vector2(-1, 0);
    Vector2 right = new Vector2(1, 0);
    Vector2 up = new Vector2(0, 1);
    Vector2 down = new Vector2(0, -1);



    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        playerRB = GetComponent<Rigidbody2D>();
        updateSlots(16);

    }

    public void updateSlots(int numToAdd)
    {
        playerUIInv = GameObject.Find("InventoryPanel").GetComponent<UIInventory>();
        playerUIInv.updateNumberOfSlots(numToAdd);
    }

    public void talk(Vector2 x)
    {
        RaycastHit2D hit = Physics2D.Raycast(playerRB.position + Vector2.up * 0.2f, x, 1.5f, LayerMask.GetMask("NPC"));
        if (hit.collider != null)
        {
            NonPlayerCharacter character = hit.collider.GetComponent<NonPlayerCharacter>();
            if (character != null)
            {
                character.DisplayDialogue();
            }
        }
    }



    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            talk(up);
            talk(left);
            talk(right);
            talk(down);

        }

        //take direction inputs 
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector2 move = new Vector2(0, 0);
        if (horizontal != 0.0f || vertical != 0.0f) // if player asked to move
        {
            // if the pressure is more important on the horizontal axis
            if (horizontal != 0 ) // note that if both values are equals the default behaviour will be to chose horizontal axis.
            {
                move[0] = horizontal;
                move[1] = 0;
            }
            else
            {
                move[1] = vertical;
                move[0] = 0;

            }
        }

        Vector2 position = playerRB.position;

        position = position + move * speed * Time.deltaTime;

        playerRB.MovePosition(position);

    }
    //end of class
}
