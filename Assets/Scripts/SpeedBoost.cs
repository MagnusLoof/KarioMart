using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoost : MonoBehaviour
{
    [SerializeField] private float respawnTimer;
    [SerializeField] private MeshRenderer meshRenderer;
    [SerializeField] private SphereCollider sphereCollider;

    private CarController car;
    private float timer;
    private bool activated;

    private void Update()
    {
        if(activated)
        {
            meshRenderer.enabled = false;
            sphereCollider.enabled = false;
            timer += Time.deltaTime;
        }

        if(timer >= respawnTimer)
        {
            Logger.Log("Speedboost respawned");
            meshRenderer.enabled = true;
            sphereCollider.enabled = true;
            activated = false;
            timer = 0;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            Logger.Log("Speedboost activated");
            car = other.gameObject.GetComponent<CarController>();
            car.speedBoost = true;
            car.timer = 0f;
            activated = true;
        }
    }
}
