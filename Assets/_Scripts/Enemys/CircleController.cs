using UnityEngine;

public class CircleController : MonoBehaviour
{
    private int direction = 1;
    public  float moveSpeed = 2;    
    public float a = 1.37f, b = -1.25f;

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(0f, direction, 0f);
        transform.Translate(movement * moveSpeed * Time.deltaTime);

        if (transform.position.y > a || transform.position.y < b)
        {
            direction *= -1;
        }
    }
}

