using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    public GameObject player;
    public DetectEdge[] onEdges;
    public float speed = 0.75f;
    private bool flip;
    private float distance;

    private void Update()
        {
            this.distance = Vector2.Distance(this.transform.position, this.player.transform.position);
            Vector3 scale = this.transform.localScale;
            if (this.distance <= 5 && (this.onEdges[0].onEdge == false && this.onEdges[1].onEdge == false)) {
                if (this.player.transform.position.x > this.transform.position.x) {
                    scale.x = Mathf.Abs(scale.x) * (this.flip ? -1 : 1);
                    this.transform.Translate(this.speed * Time.deltaTime, 0, 0);
                } else {
                    scale.x = Mathf.Abs(scale.x) * -1 * (this.flip ? -1 : 1);
                    this.transform.Translate(this.speed * Time.deltaTime * -1, 0, 0);
                }
                this.transform.localScale = scale;
            }
        }
}
