using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardAttack : MonoBehaviour
{
    public HealthSystem playerHp;
    public int damage = 1;
    public int delay = 1;
    private bool present;

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Player")) {
            present = true;
            StartCoroutine(DamageOverTimeCoroutine());
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        present = false;
    }

    IEnumerator DamageOverTimeCoroutine() {
        while (this.present == true) {
            yield return new WaitForSeconds(this.delay);
            this.playerHp.ReduceHealth(damage);
        }
    }

}
