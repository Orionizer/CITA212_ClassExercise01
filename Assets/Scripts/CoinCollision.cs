using UnityEngine;

public class CoinCollision : MonoBehaviour
{
    [SerializeField] private ParticleSystem hitEffect;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            hitEffect.transform.position = collision.contacts[0].point;
            hitEffect.Play();
            Debug.Log("Coin collected by Player!");
            Destroy(this.gameObject);
            //test
        }
    }
}

