using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] private ParticleSystem Effect;
    bool HasPackage = false;

    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        Vector3 Move = new Vector3(x, y, 0f);
        transform.Translate(Move * moveSpeed * Time.deltaTime);

    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("Collision happened" + collision.gameObject.name);
        if (collision.collider.CompareTag("TEST"))
        {
            Debug.Log("Collision TEST" + collision.gameObject.name);
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (HasPackage == false)
        {
            if (collision.CompareTag("Package"))
            {
                HasPackage = true;
                Debug.Log("Package Collected");
                Destroy(collision.gameObject);
                GetComponent<SpriteRenderer>().color = Color.red;
            }
        }
        else
        {
            if (collision.CompareTag("Customer"))
            {
                HasPackage = false;
                Debug.Log("Package Delivered");
                GetComponent<SpriteRenderer>().color = Color.white;
            }
        }
        if (collision.CompareTag("TEST"))
        {
            print(Effect);
            Effect.transform.position = this.transform.position;
            Effect.Play();
        }
    }
}




