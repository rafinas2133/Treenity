using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardAttack : MonoBehaviour
{
    public HealthSystem playerHp;
    private Collider2D playerCollide;
    public int damage = 1;
    public float delay = 0.5f;
    private bool present;

    void Start(){
        playerCollide = GameObject.Find("Player").GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision == playerCollide) {
            present = true;
            StartCoroutine(DamageOverTimeCoroutine());
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        present = false;
    }

    IEnumerator DamageOverTimeCoroutine() {
        while (this.present == true) {
            this.playerHp.ReduceHealth(damage);
            yield return new WaitForSeconds(this.delay);
        }
    }

}
