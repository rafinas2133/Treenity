using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chase : MonoBehaviour
{
 
    public GameObject player;
    private float distance;
    public float speed;
    private bool facingRight;
    
    void Update()
    {
        this.distance = Vector2.Distance(this.transform.position, this.player.transform.position);
        if (this.distance <= 5) {
            this.transform.position = Vector2.MoveTowards(this.transform.position, this.player.transform.position, this.speed * Time.deltaTime);
            if (this.player.transform.position.x < this.transform.position.x && !facingRight) {
                Flip();
            }
            if (this.player.transform.position.x > this.transform.position.x && facingRight) {
                Flip();
            }
        }
    }

    void Flip(){
        Vector3 scale = this.transform.localScale;
        scale.x *= -1;
        this.transform.localScale = scale;
        facingRight = !facingRight;
    }

}
