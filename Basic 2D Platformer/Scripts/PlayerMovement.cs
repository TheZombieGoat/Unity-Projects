using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D body;
    [SerializeField] private float speed;
    [SerializeField] private LayerMask groundLayer;
    private Animator anim;
    private BoxCollider2D boxCollider;
  
    //runs once at start
    private void Awake()
    {
        //Grabs references for body from Rigidbody, BoxCollider and Animator for game object
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
        //setting default speed
        speed = 10;
    }
    
    //runs every frame
    private void Update()
    {   
        float horizontal_input = Input.GetAxis("Horizontal");

        //setting up velocity (For x-axis)
        body.velocity = new Vector2(horizontal_input * speed, body.velocity.y);

        //flips player when moving left-right
        if (horizontal_input > 0.01f)
            transform.localScale = Vector3.one;
        else if (horizontal_input < -0.01f)
            transform.localScale = new Vector3(-1,1,1);

        //implement Jumping
        if (Input.GetKey(KeyCode.Space) && isGrounded())
            Jump();

        //setting up animator parameters
        anim.SetBool("Running", horizontal_input != 0);
        anim.SetBool("grounded", isGrounded());

    }

    private void Jump()
    {
        body.velocity = new Vector2(body.velocity.x, speed);
        anim.SetTrigger("jump");
    }


    private bool isGrounded()
    {
        //using box collision to check if player is on ground.
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center,boxCollider.bounds.size,0,Vector2.down,0.1f,groundLayer);
        return raycastHit.collider != null;
    }

}
