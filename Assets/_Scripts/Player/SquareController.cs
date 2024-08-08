using UnityEngine;

public class SquareController : MonoBehaviour
{
    // Tham chiếu đến ScriptableObject PlayerData
    public PlayerData playerData;

    // Vị trí ban đầu của hình vuông
    private Vector2 initialPosition;

    void Start()
    {
        // Lưu vị trí ban đầu của hình vuông
        initialPosition = transform.position;
        // Sự kiện giảm máu
        GameManager.Instance.OnPlayerHit.AddListener(UpdateHP);
    }

    void FixedUpdate()
    {
        // Lấy input của người chơi
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        // Tạo vector di chuyển
        Vector3 movement = new Vector3(horizontal, vertical, 0f);
        // Di chuyển hình vuông
        transform.Translate(playerData.moveSpeed * Time.deltaTime * movement);
    }

    // Xử lý va chạm
    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Circle":
            case "PinWheel":
                // Xử lý va chạm với vong tron xanh va PinWheel
                GameManager.Instance.HandleEnemyCollision();
                break;
            case "YellowCircle":
                // Xử lý va chạm với vòng tròn vàng
                HandleYellowCircleCollision(collision);
                break;
            case "Box":
                GameManager.Instance.HandleBoxCollision();
                break;
        }
    }

    // OnTriggerEnter2D được gọi khi Collider2D other đi vào trigger [map 2 , 3]
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "CheckPoint")
        {
            // Cập nhật vị trí ban đầu là vị trí checkpoint
            initialPosition = other.transform.position;
        }
    }

    private void HandleYellowCircleCollision(Collision2D collision)
    {
        Destroy(collision.gameObject);
        GameManager.Instance.IncreaseScore(); // Tăng điểm số
    }

    private void UpdateHP()
    {
        playerData.hp--; // Giảm máu
        // Gọi sự kiện thay đổi máu
        GameManager.Instance.OnHPChanged.Invoke(playerData.hp);
        if (playerData.hp <= 0)
        {
            GameManager.Instance.ResetLevel();
        }
        else
        {
            // Quay về vị trí ban đầu của hình vuông
            transform.position = initialPosition;
        }
    }
}
