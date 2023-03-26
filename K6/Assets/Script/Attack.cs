using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Attack : MonoBehaviour
{

    public HealthSystem playerHp;
    public int damage = 1;

    private void OnCollisionEnter2D(Collision2D collision)
     {
        //Jika platform menabrak player, hp player dikurangi sejumlah damage
         if (collision.gameObject.tag == "Player") {
            this.playerHp.ReduceHealth(this.damage);
         }
     }
}
