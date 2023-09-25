using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
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

    private void Start()
    {
        acceleration.Enable();
        turn.Enable();
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

    private void FixedUpdate()
    {
        deltaRotation = Quaternion.Euler(rotation * rotateSpeed * Time.deltaTime * 57.3f);
        rb.MoveRotation(rb.rotation * deltaRotation);
        rb.MovePosition(rb.position + transform.forward * momentum.x * speed * speedBoostModifier * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Wall")
        {
            acceleration.Disable();
        }

        if (collision.transform.tag == "Player")
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
        if (collision.transform.tag == "Wall")
        {
            acceleration.Enable();
        }
    }
}