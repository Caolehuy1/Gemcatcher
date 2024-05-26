using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
    
{
    [SerializeField] private float jumpForce = 5F;
    [SerializeField] private Rigidbody2D Rigidbody;
    [SerializeField] private int maxJump;
    private bool isGrounded;
    private int jumpCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) )
        {
            if (isGrounded || jumpCount < maxJump)
            {
                //Rigidbody.velocity =new Vector2 (Rigidbody.velocity.x, jumpForce);
                Rigidbody.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
                isGrounded = false;
                jumpCount++;

            }
            
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            isGrounded = true; jumpCount = 0;


        }
        else

        if (collision.collider.tag == "Gem")
        {
            Destroy(collision.gameObject);
            ScoreManager.AddScore(2);
            Debug.Log("vo gem");

        }
        else

        if (collision.collider.tag == "GemDevil")
        {
            ScoreManager.AddScore(-1);
            Debug.Log("vo gemDevil");
            Destroy(collision.gameObject);
        }
        else
        if (collision.collider.tag == "Gemx2")
        {
            ScoreManager.MutipleScore(2);
            Debug.Log("vo gemx2");
            Destroy(collision.gameObject);
        }
        else

       if (collision.collider.tag == "Gem+Time")
        {
            ScoreManager.AddTime(+1);
            Debug.Log("vo gem+Time");
            Destroy(collision.gameObject);

        }
        else

       if (collision.collider.tag == "Gem-Time")
        {
            ScoreManager.AddTime(-2);
            Debug.Log("vo gem-Time");
            Destroy(collision.gameObject);

        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground") { isGrounded = false; }
    }
}
