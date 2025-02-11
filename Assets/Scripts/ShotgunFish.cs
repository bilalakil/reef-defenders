using UnityEngine;

public class ShotgunFish : Fish
{
    [SerializeField] private Vector3 bubbleAngle;

    public override void Shoot()
    {
        Instantiate(bubblePrefab, transform.position, transform.rotation * Quaternion.Inverse(Quaternion.Euler(bubbleAngle))).GetComponent<Bullet>().Initialise(bubbleLifetime);
        Instantiate(bubblePrefab, transform.position, transform.rotation).GetComponent<Bullet>().Initialise(bubbleLifetime);
        Instantiate(bubblePrefab, transform.position, transform.rotation * Quaternion.Euler(bubbleAngle)).GetComponent<Bullet>().Initialise(bubbleLifetime);
    }
}
