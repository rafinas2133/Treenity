using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour
{
    public float speed = 2f;
    public int damage = 1;
    public HealthSystem playerHealth;
    public Rigidbody2D rb;

    void Update()
    {
        if (transform.localScale[0] > 0) {
            this.rb.velocity = transform.right * this.speed;    
        } else {
            this.rb.velocity = -transform.right * this.speed;
        }
    }

    private void OnTriggerEnter2D(Collider2D collider) {
        if (collider.gameObject.CompareTag("Player")) {
            Destroy(gameObject);
            this.playerHealth = collider.gameObject.GetComponent<HealthSystem>();
            this.playerHealth.ReduceHealth(this.damage);
        } else if (collider.gameObject.layer == 6) {
            Destroy(gameObject);
        }
    }
}
