using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed = 3.0f;
    [SerializeField] private float lifetime = 3.0f;

    public void Initialise(float lifetime = 0f)
    {
        Destroy(this.gameObject, lifetime > 0 ? lifetime : this.lifetime);
        AudioManager.I.Play(AudioManager.I.Refs.BubblePush, transform.position);
    }

    public void Update()
    {
        transform.Translate(transform.right * speed * Time.deltaTime, Space.World);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.gameObject.SetActive(false);
            AudioManager.I.Play(AudioManager.I.Refs.BubblePop, transform.position);
            Destroy(this.gameObject); // TODO: Add bubbles pool
        }
    }

    private void OnDestroy()
    {
        AudioManager.I.Play(AudioManager.I.Refs.BubblePop, transform.position);
    }
}
