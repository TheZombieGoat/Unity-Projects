using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D body;
    [SerializeField] private float speed;
  
    //runs once at start
    private void Awake()
    {
        //Gets Body
        body = GetComponent<Rigidbody2D>();
    }
    
    //runs every frame
    private void Update()
    {
       
        //setting up velocity (For x-axis)
        body.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, body.velocity.y);

        //implement Jumping
        if (Input.GetKey(KeyCode.Space))
            body.velocity = new Vector2(body.velocity.x, speed);
    }
}
