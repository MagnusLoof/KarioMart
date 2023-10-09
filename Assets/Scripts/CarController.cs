using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CarController : MonoBehaviour
{
    [SerializeField] private InputAction acceleration;
    [SerializeField] private InputAction turn;
    [SerializeField] private Rigidbody rb;

    [SerializeField] private float speed;
    [SerializeField] private float rotateSpeed;

    private float speedBoostModifier;
    public bool speedBoost;

    [SerializeField] private float boostDuration;
    public float timer;

    private Vector3 momentum;
    private Vector3 rotation;
    private Quaternion deltaRotation;

    [SerializeField] private float bumpStrength;
    [SerializeField] private float bumpRadius;

    public int currentCheckpoint;

    // Instead of needing a reference to the RaceManager I just use a 3f delay
    private void Start()
    {
        Invoke("EnableCar", 3f);
    }

    private void Update()
    {
        momentum = new Vector3(acceleration.ReadValue<float>(), 0, 0);
        rotation = new Vector3(0, turn.ReadValue<float>(), 0);

        if(speedBoost)
        {
            speedBoostModifier = 1.5f;
            timer += Time.deltaTime;
        }
        else
        {
            speedBoostModifier = 1f;
            timer = 0f;
        }

        if(timer >= boostDuration)
        {
            speedBoost = false;
        }
    }

    // deltaRotation was a bit low so I multiplited with an arbitrary number
    // I decided to pick 57.3f purely because it's the value of a a radian in degrees.
    private void FixedUpdate()
    {
        deltaRotation = Quaternion.Euler(rotation * rotateSpeed * Time.deltaTime * 57.3f);
        rb.MoveRotation(rb.rotation * deltaRotation);
        rb.MovePosition(rb.position + transform.forward * momentum.x * speed * speedBoostModifier * Time.deltaTime);
    }

    private void EnableCar()
    {
        acceleration.Enable();
        turn.Enable();
    }

    // Because of rb.MovePosition the car was able to keep driving into a wall to phase through it
    // To prevent this I disable the acceleration and also added force on the opposite direction
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Wall"))
        {
            Vector3 dir = collision.contacts[0].point - transform.position;
            dir = -dir;
            rb.AddForce(dir * bumpStrength, ForceMode.Force);
            acceleration.Disable();
        }

        if (collision.transform.CompareTag("Player"))
        {
            CarController otherPlayer = collision.transform.GetComponent<CarController>();
            otherPlayer.speedBoost = false;
            otherPlayer.timer = 0f;
            Logger.Log("Impact");
            otherPlayer.rb.AddForce(new Vector3(bumpStrength, 0, bumpStrength), ForceMode.Impulse);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.CompareTag("Wall"))
        {
            acceleration.Enable();
        }
    }
}