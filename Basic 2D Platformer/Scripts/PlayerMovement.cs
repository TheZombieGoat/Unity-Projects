using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D body;
    [SerializeField] private float speed;
    private Animator anim;
    private bool grounded;
  
    //runs once at start
    private void Awake()
    {
        //Grabs references for body from Rigidbody and Animator for game object
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        //setting default speed
        speed = 5;
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
        if (Input.GetKey(KeyCode.Space) && grounded)
            Jump();

        //setting up animator parameters
        anim.SetBool("Running", horizontal_input != 0);
        anim.SetBool("grounded", grounded);
    }

    private void Jump()
    {
        body.velocity = new Vector2(body.velocity.x, speed);
        anim.SetTrigger("jump");
        grounded = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = true;
        }
    }


}
