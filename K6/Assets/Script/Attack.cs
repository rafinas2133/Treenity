using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Attack : MonoBehaviour
{

   public HealthSystem playerHp;
   public int damage = 1;
   private bool present;

   private void OnCollisionEnter2D(Collision2D collision)
   {
      //Jika platform menabrak player, hp player dikurangi sejumlah damage
      if (collision.gameObject.tag == "Player") {
         this.present = true;
         this.playerHp.ReduceHealth(this.damage);
      }
   }

   private void OnCollisionExit2D(Collision2D collision) {
      this.present = false;
   }

   IEnumerator DamageCoroutine() {
      while (this.present) {
         this.playerHp.ReduceHealth(this.damage);
         yield return new WaitForSeconds(1);
      }
   }
}
