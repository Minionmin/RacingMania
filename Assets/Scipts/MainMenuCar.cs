using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MainMenuCar : MonoBehaviour
{
    [SerializeField] private float RotateSpeed = 5;

    void Update()
    {
        transform.Rotate(0f, -RotateSpeed * Time.deltaTime, 0f);
    }
}
