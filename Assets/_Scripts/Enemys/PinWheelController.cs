using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinWheelController : MonoBehaviour
{
    // Tốc độ xoay của pinwheel
    public float rotationSpeed = 100f;
    public float r = 1f;

    private Quaternion deltaRotation;

    // Update is called once per frame
    void Update()
    {
        deltaRotation = Quaternion.Euler(0, 0, r * rotationSpeed * Time.deltaTime);
        transform.rotation *= deltaRotation;
    }
}
