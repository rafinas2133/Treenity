using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyAttack : MonoBehaviour
{

    public HealthSystem playerHp;
    public int damage = 1;
    private float time;

    private void OnCollisionStay2D(Collision2D collision)
     {
        //Jika platform menabrak player, hp player dikurangi sejumlah damage
         if (collision.gameObject.tag == "Player") {
            this.time += Time.deltaTime;
            if (this.time >= 0.35) {
               this.playerHp.ReduceHealth(this.damage);
               this.time = 0f;
            }
         }
     }
}
