using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Car : MonoBehaviour
{
    [SerializeField] float Speed = 10f;
    [SerializeField] float SpeedGainPerSec = 0.2f;
    [SerializeField] float TurnSpeed = 200f;

    private int SteerValue;

    void Update()
    {
        transform.Translate(Vector3.forward * Speed * Time.deltaTime);
        transform.Rotate(0f, SteerValue * TurnSpeed * Time.deltaTime, 0f);
        Speed += SpeedGainPerSec * Time.deltaTime;
    }

    public void Steer(int value)
    {
        SteerValue = value;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Obstacle"))
        {
            SceneManager.LoadScene(0);
        }
    }
}
