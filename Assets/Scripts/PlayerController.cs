using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Variables
    public float speed;
    public float jump_Force;
    private bool grounded;

    private Rigidbody2D rb;
    private float Horizontal;

    private Animator Animator;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
        Debug.DrawRay(transform.position, Vector3.down * 0.119f, Color.red);

    }

    // Update is called once per frame
    void Update()
    {
        Horizontal = Input.GetAxisRaw("Horizontal");//Arrow L o R || Press Button A o D
        if(Horizontal < 0.0)
        {
            transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        }
        else if (Horizontal > 0.0)
        {
            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        }
        Animator.SetBool("running", Horizontal !=0.0f);        
        if(Physics2D.Raycast(transform.position, Vector3.down, 0.119f))//si el raycast detecta la posicion respecto al ground
        {
            grounded = true;
        }
        else 
        {
            grounded = false;
        }
        

        Debug.DrawRay(transform.position, Vector3.down * 0.119f, Color.red);
        if(Input.GetKeyDown(KeyCode.Z) && grounded )//Valor booleano True -> Press Z || False -> No Press Z
        {
            Salto();
        }
    }

    private void FixedUpdate() 
    {
            rb.velocity = new Vector2(Horizontal, rb.velocity.x);
    }

    void Salto()
    {
        rb.AddForce(Vector2.up * jump_Force);
    }
}
