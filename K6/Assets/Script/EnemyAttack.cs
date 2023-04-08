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

<<<<<<< HEAD
   void Update() {
      if (this.time == -1f) {
         this.playerHp.ReduceHealth(this.damage);
         this.time = 0f;
      }
      if (this.time < 2f && this.isHit == true) {
         this.time += Time.deltaTime;
      } else if (this.isHit == true && this.time >= 1f) {
         this.playerHp.ReduceHealth(this.damage);
         this.time = 0f;
      }
   }

   private void OnCollisionEnter2D(Collision2D collision) {
      if (collision.gameObject.CompareTag("Player")) {
         this.isHit = true;
         this.time = -1f;
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
=======
    private void OnCollisionStay2D(Collision2D collision)
     {
        //Jika platform menabrak player, hp player dikurangi sejumlah damage
         if (collision.gameObject.tag == "Player") {
            this.time += Time.fixedDeltaTime;
            if (this.time >= 0.35) {
               this.playerHp.ReduceHealth(this.damage);
               this.time = 0f;
            }
         }
     }
>>>>>>> 3fdd305462003af823171ff44ecb8ff94c00e5dd
}
