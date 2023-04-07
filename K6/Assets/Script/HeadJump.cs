using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadJump : MonoBehaviour
{
    public bool onEnemy;

    private void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.CompareTag("EnemyCollider")) {
            this.onEnemy = true;
        }
    }

    private void OnTriggerExit2D(Collider2D col) {
        if (col.gameObject.CompareTag("EnemyCollider")) {
            this.onEnemy = false;
        }
    }
}
