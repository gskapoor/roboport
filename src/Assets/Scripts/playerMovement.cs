using System.Collections;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    [SerializeField]private float speed = 1;
    [SerializeField]private float jumpSpeed = 1;
    [SerializeField]private bool isRight = true;
    [SerializeField]private bool doubleJumpEnabled = false;
    [SerializeField]private float error = 0.1f;
    //[SerializeField]private bool djumpUnlocked = false;
    private Rigidbody2D body;
    private BoxCollider2D col;
    private bool doubleJump;
    

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        col = GetComponent<BoxCollider2D>();
        doubleJump = true;
        
    }
    private void Update()
    {
        //Player L&R movement
        float horizontalInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(horizontalInput*speed,body.velocity.y);
        //Flip Player

        if ((!isRight && horizontalInput > 0) || (isRight && horizontalInput < 0)){
            transform.Rotate(0f,180f,0f);
            isRight = !isRight;
        }

        //Player Jump
        if (Input.GetButtonDown("Jump") && (isGrounded() || (doubleJumpEnabled && doubleJump)))
        {
            doubleJump = isGrounded();
            body.velocity = new Vector2(body.velocity.x,jumpSpeed);
        }


    }

    private bool isGrounded(){
        RaycastHit2D hit = Physics2D.BoxCast(col.bounds.center, col.bounds.size, 0f, Vector2.down, error);
        Color rayColor;
        if (hit.collider != null)
        {
            rayColor = Color.red;
        }
        else 
        {
            rayColor = Color.green;
        }

        Debug.DrawRay(col.bounds.center,Vector2.down * (col.bounds.extents.y + error),rayColor);
        return hit.collider != null;
    }

    
    
}
