using UnityEngine;

public class playerMovement : MonoBehaviour
{
    [SerializeField]private float speed = 1;
    [SerializeField]private float jumpSpeed = 1;
    [SerializeField]private bool isRight = true;
    private int jumpAmt = 0;
    private int jumpMax = 2;
    
    private Rigidbody2D body;
    

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
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
    
        if (isGrounded()){
            jumpAmt = 0;
        }
        if(Input.GetKey(KeyCode.Space) && jumpAmt < jumpMax)
        {
            body.velocity = new Vector2(body.velocity.x,jumpSpeed);
            jumpAmt += 1;
            
        }
    }
    private bool isGrounded(){
        BoxCollider2D collider = GetComponent<BoxCollider2D>();
        RaycastHit2D hit = Physics2D.Raycast(collider.bounds.center,Vector2.down,collider.bounds.extents.y + 0.01f);
        Color rayColor;
        if (hit != null)
        {
            rayColor = Color.red;
        }
        else 
        {
            rayColor = Color.green;
        }

        Debug.DrawRay(collider.bounds.center,Vector2.down * (collider.bounds.extents.y + 0.01f),rayColor);
        return hit != null;
    }

    
    
}
