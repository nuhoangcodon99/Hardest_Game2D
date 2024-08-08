using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public PlayerData playerData; // Tham chiếu đến ScriptableObject PlayerData

    public Text timerText;
    public Text scoreText;
    public Text hpText;
    public Text gameOverText;

    private void Start()
    {
        // Khoửi tạo sự kiện
        GameManager.Instance.OnScoreChanged.AddListener(UpdateScoreText);
        GameManager.Instance.OnTimeChanged.AddListener(UpdateTimerText);
        GameManager.Instance.OnHPChanged.AddListener(UpdateHPText);

        this.UpdateUI();
    }

    // Cập nhật UI
    private void UpdateUI()
    {
        this.UpdateScoreText(playerData.score);
        this.UpdateTimerText(playerData.timeElapsed);
        this.UpdateHPText(playerData.hp);
    }

    public void UpdateScoreText(float score)
    {
        scoreText.text = "Score: " + score;
    }

    public void UpdateTimerText(float timeElapsed)
    {
        timerText.text = "Time: " + timeElapsed.ToString() + "s";
    }

    public void UpdateHPText(float hp)
    {
        hpText.text = hp + "/5";
    }
}
