using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectEdge : MonoBehaviour
{

    public bool onEdge;

    private void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.CompareTag("Enemy")) {
            this.onEdge = true;
        }
    }

    private void OnTriggerExit2D(Collider2D col) {
        this.onEdge = false;
    }
    
}
