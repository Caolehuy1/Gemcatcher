// GemFallScript - Phiên bản cơ bản
using System.Collections;
using System.Collections.Generic;
using UnityEngine; // Sử dụng các tính năng được định nghĩa trong UnityEngine

public class GemFallScript : MonoBehaviour
{
    // Khai báo biến để chứa prefab của viên ngọc. Đây sẽ là đối tượng mà chúng ta sẽ tạo ra trong trò chơi.
    public List<GameObject> ItemPrefab;
  
    // Biến đếm thời gian kể từ lần sinh viên ngọc cuối cùng.
    private float timer;
    // Khoảng thời gian (tính bằng giây) giữa mỗi lần sinh viên ngọc mới.
    private float spawnInterval = 3f; //tần suất spawn: 3 giây / 1 gem

    private bool IsGameOrver;
    private void Start()
    {
        IsGameOrver = false;
        
    }
    public void setGameOrver(bool isGameOrver)
    { IsGameOrver = isGameOrver; }
    void Update()
        
    {
        if (IsGameOrver) return;   
        // Cộng dồn thời gian từ lần cuối cập nhật đến bây giờ vào biến timer.
        timer += Time.deltaTime;
        // Kiểm tra nếu thời gian đã đủ lớn bằng hoặc lớn hơn khoảng thời gian sinh viên ngọc.
        if (timer >= spawnInterval)
        {
            SpawnGem(); // Gọi hàm sinh viên ngọc.
            timer = 0; // Đặt lại biến đếm thời gian.
        }
    }

    /*void SpawnGem()
    {
        // Tạo ra viên ngọc tại vị trí cố định ở trên màn hình. 
        Vector3 spawnPosition = new Vector3(0f, 6f, 0); //Vector3(tọa độ x, tọa độ y và chiều sâu z)

        // Sử dụng Instantiate để tạo ra một bản sao của prefab viên ngọc tại vị trí và hướng quy định.
        Instantiate(gemPrefab, spawnPosition, Quaternion.identity); // Instantiate(Object nào, vị trí nào, không có hướng quay)
    }*/
    void SpawnGem()
    {
        /* Khai báo và tạo một biến có giá trị ngẫu nhiên trong khoảng màn hình trước khi tạo gem mới. 
        * Biến này đóng vai trò là tọa độ X (ngang) mới.
        */
        float randomX = Random.Range(-8f, 8f); //Màn hình rộng 16 point nên lề trái là -8 và biên phải là 8
                                               //Khai báo một biến tọa độ vị trí và lưu giá trị tọa độ trên
        Vector3 spawnPosition = new Vector3(randomX, 6f, 0); // Đưa biến số này vào Vector3, để tạo tọa độ vị trí mới

        int randomIndex = Random.Range(0, ItemPrefab.Count);
        //Đưa tọa độ này vào function (hàm) Instantiate để tạo và thả viên gem mới
        Instantiate(ItemPrefab[randomIndex], spawnPosition, Quaternion.identity);
    }

}