using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public PlayerData playerData; // Tham chiếu đến ScriptableObject PlayerData

    public UnityEvent<float> OnTimeChanged = new();
    public UnityEvent<float> OnScoreChanged = new();
    public UnityEvent<float> OnHPChanged = new();
    public UnityEvent OnPlayerHit = new();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        // Bắt đầu coroutine đếm thời gian
        StartCoroutine(Timer());
    }

    // Coroutine đếm thời gian
    private IEnumerator Timer()
    {
        while (true)
        {
            yield return new WaitForSeconds(1); // Chờ 1 giây
            playerData.timeElapsed++; // Tăng thời gian
            OnTimeChanged.Invoke(playerData.timeElapsed); // Gọi sự kiện thay đổi thời gian
        }
    }

    // Tăng điểm số
    public void IncreaseScore()
    {
        playerData.score++; // Tăng điểm số
        OnScoreChanged.Invoke(playerData.score); // Gọi sự kiện thay đổi điểm số
    }

    // Xử lý va chạm với kẻ địch
    public void HandleEnemyCollision()
    {
        OnPlayerHit.Invoke(); // Gọi sự kiện va chạm với kẻ địch
    }

    // Xử lý va chạm với hộp
    public void HandleBoxCollision()
    {
        if (playerData.score >= playerData.missionScore)
        {
            LoadNextScene();
        }
    }

    // Quản lý Scene
    public void LoadNextScene()
    {
        // Chuyển sang cảnh tiếp theo
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ResetLevel()
    {
        // Khởi động lại cảnh hiện tại
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
