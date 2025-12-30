using UnityEngine;

public class SquashPlayer : MonoBehaviour
{
    [Header("Siła Uderzenia")]
    [SerializeField] private float hitPower = 20f; 
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.relativeVelocity.y > hitPower)
        {
            Squash();
        }
    }

    void Squash()
    {
        float direction = Mathf.Sign(transform.localScale.x);
        transform.localScale = new Vector3(1.8f * direction, 0.4f, 1f);
        Invoke(nameof(ResetScale), 0.3f);
    }

    void ResetScale()
    {
        float direction = Mathf.Sign(transform.localScale.x);
        transform.localScale = new Vector3(1f * direction, 1f, 1f);
    }
}