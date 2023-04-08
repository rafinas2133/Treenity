using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyAttack : MonoBehaviour
{

    public HealthSystem playerHp;
    public int damage = 1;
    private float time;
    private bool isHit;

   void FixedUpdate() {
      if (this.isHit == true) {
         if (this.time < 1f) {
         this.time += Time.fixedDeltaTime;
         } else if (this.time >= 1f) {
            DealDamage();
            this.time = 0f;
         }
      }
   }

   private void OnCollisionEnter2D(Collision2D collision) {
      if (collision.gameObject.CompareTag("Player")) {
         this.isHit = true;
         this.time = 0f;
         DealDamage();
      }
   }

   //  private void OnCollisionStay2D(Collision2D collision)
   //   {
   //      //Jika platform menabrak player, hp player dikurangi sejumlah damage
   //       if (collision.gameObject.CompareTag("Player")) {
   //          if (this.time < 3f) {
   //             this.time += Time.fixedDeltaTime;
   //          } else {
   //             this.playerHp.ReduceHealth(this.damage);
   //             this.time = 0f;
   //          }
   //       }
   //   }

   private void OnCollisionExit2D(Collision2D collision) {
      if (collision.gameObject.CompareTag("Player")) {
         this.isHit = false;
         this.time = 0f;
      }
   }

   private void DealDamage() {
      this.playerHp.ReduceHealth(this.damage);
   }
}
