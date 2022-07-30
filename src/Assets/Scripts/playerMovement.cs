using UnityEngine;

public class playerMovement : MonoBehaviour
{
    [SerializeField]private float speed = 1;
    [SerializeField]private float jumpSpeed = 1;
    [SerializeField]private bool isRight = true;
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
        if (!isRight && horizontalInput > 0){
            transform.rotate(0f, 180f, 0f);
            isRight = true;
        }
        else if (isRight && horizontalInput < 0){
            transform.rotate(0f, 180f, 0f);
            isRight = false;
        }
        //Player Jump
        if(Input.GetKey(KeyCode.Space))
            body.velocity = new Vector2(body.velocity.x,jumpSpeed);
        //Player Shoot
    }

}
