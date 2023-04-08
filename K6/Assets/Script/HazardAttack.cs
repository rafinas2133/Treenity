using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardAttack : MonoBehaviour
{
    public HealthSystem playerHp;
    public int damage = 1;
<<<<<<< HEAD
    private bool isHit;
    private float time;

    void Update() {
      if (this.time == -1f) {
         this.playerHp.ReduceHealth(this.damage);
         this.time = 0f;
      }
      if (this.time < 1f && this.isHit == true) {
         this.time += Time.deltaTime;
      } else if (this.isHit == true && this.time >= 1f) {
         this.playerHp.ReduceHealth(this.damage);
         this.time = 0f;
      }
   }
=======
    public float delay = 1f;
    private bool present;
>>>>>>> 3fdd305462003af823171ff44ecb8ff94c00e5dd

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Player")) {
            this.isHit = true;
            this.time = -1f;
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Player")) {
            this.isHit = false;
            this.time = 0f;
        }
    }
}
