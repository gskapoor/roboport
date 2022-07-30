using UnityEngine;

public class playerMovement : MonoBehaviour
{
    [SerializeField]private float speed;
    [SerializeField]private float jumpSpeed;
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
        if (horizontalInput > 0)
            transform.localScale = new Vector3(transform.localScale.x,transform.localScale.y,transform.localScale.z);
        else if (horizontalInput < 0)
            transform.localScale = new Vector3(-1*transform.localScale.x,transform.localScale.y,transform.localScale.z);
        //PLayer Jump
        if(Input.GetKey(KeyCode.Space))
            body.velocity = new Vector2(body.velocity.x,jumpSpeed);
    }

}
