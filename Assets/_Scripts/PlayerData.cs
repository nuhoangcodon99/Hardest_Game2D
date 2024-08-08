using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "ScriptableObjects/PlayerData", order = 1)]
public class PlayerData : ScriptableObject
{
    public float moveSpeed = 4f;
    public float hp = 5;
    public float timeElapsed = 0; // Thời gian đã trôi qua
    public float score = 0; // Điểm số
    internal float missionScore;
}
