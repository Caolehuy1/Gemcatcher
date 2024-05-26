using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class GemMover : MonoBehaviour
{

    /*
    * khai báo biến tốc độ là một số thực có giá trị bằng 5.
    * Public sẽ cho phép ta truy cập giá trị speed từ UnityEditor
    */
    public float speed = 5f;
    /*public Vector2 direction;*/       
    //...
    /*private void Start()
    {
        
            int dir = Random.Range(0, 4); // random huong di chuyen  từ 0 tới 3

        if (dir == 0)
        {
            direction = Vector2.up;
                 }
        if (dir == 1)
        {
            direction = Vector2.down;
        }
        if (dir == 2)
        {
            direction = Vector2.left;
        }
        if (dir == 3)
        {
            direction = Vector2.right;*/
     /*   }
    }*/
    void Update()
    {
        /*transform.Translate(direction * speed * Time.deltaTime);*/
    transform.Translate(Vector3.down * speed * Time.deltaTime);

}

    void OnTriggerEnter2D(Collider2D other) //other chính là thông tin của bất kỳ collider nào va chạm với collider này
    {
        {
           
        }
        // thiết lập điều kiện kiểm tra thông tin của OTHER
        if (other.gameObject.CompareTag("Player"))

        // nếu, phương thức so sánh gameobject tag của other với nhãn "Player" là đúng
        { // thì
            AudioSource audioSource = other.GetComponent<AudioSource>();
            audioSource.Play();
            Destroy(gameObject); //xóa gameObject đang gắn collider này. (Không phải là other)
                                 //nghĩa là xóa viên ngọc này, không phải xóa người chơi đang va chạm
        }
        else if (other.gameObject.CompareTag("Ground")) // còn không thì, nếu là mặt đất,
        { // thì
            Destroy(gameObject); //xóa gameObject đang gắn collider này. (Không phải là other)
                                 //nghĩa là xóa viên ngọc này, không phải xóa mặt đất
        }

    }
    //...

}