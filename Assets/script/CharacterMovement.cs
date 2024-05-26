using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public AudioClip jumpAudio;
    public AudioClip respawnAudio;
    public AudioClip ouchAudio;

    public float speed = 5.0f;
    public float jumpTakeOffSpeed = 7;
    public float maxSpeedJump = 7;
    private Animator animator;
    private bool IsGameOrver;

    void Start()
    {
        IsGameOrver = false;
        animator = GetComponent<Animator>(); //bắt đầu animation khép mở chân
    }
    public void setGameOrver(bool isGameOrver)
    {  IsGameOrver = isGameOrver;}
    void Update()
        

    {
        if (IsGameOrver) { return; }
        float moveHorizontal = Input.GetAxis("Horizontal");
        bool isMoving = moveHorizontal != 0; // khai báo biến isMoving
        animator.SetBool("isMoving", isMoving);

        if (isMoving) // nếu nhân vật đang di chuyển
        {
            transform.position += new Vector3(moveHorizontal * speed * Time.deltaTime, 0f, 0f);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Gembooster")
        {
            speed += 5;

            Destroy(collision.gameObject);

        }
    }

}
