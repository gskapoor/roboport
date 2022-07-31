using System.Collections;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    [SerializeField]private float speed = 1;
    [SerializeField]private float jumpSpeed = 1;
    [SerializeField]private bool isRight = true;
    [SerializeField]private float error = 0.1f;
    [SerializeField] private float jumpyDelay = 0.2f;
    [SerializeField ]private int jumpMax = 2;
    private int jj;
    private bool canJump = true;
    private Rigidbody2D body;
    private BoxCollider2D col;
    

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        col = GetComponent<BoxCollider2D>();
        jj = jumpMax;
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
            jumpMax = jj;
        }
        if(Input.GetKey(KeyCode.Space) && jumpMax > 0 && canJump == true)
        {
            canJump = false;
            body.velocity = new Vector2(body.velocity.x,jumpSpeed);
            jumpMax -= 1;
            Debug.Log(jj);
            StartCoroutine(jumpDelay());
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
    IEnumerator jumpDelay()
    {
     yield return new WaitForSeconds(jumpyDelay);
     canJump = true;
    }

    
    
}
