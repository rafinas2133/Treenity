using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartDisplay : MonoBehaviour
{

    public int maxHealth;
    public int health;

    public Sprite fullHeart;
    public Sprite emptyHeart;
    public Image[] hearts;
    public HealthSystem playerHealth;

    void Start()
    {
        this.playerHealth.SetMaxHealth(3);
        this.maxHealth = playerHealth.maxHealth;
    }

    void Update()
    {
        this.health = this.playerHealth.health;
        for (int i = 0; i < this.hearts.Length; i++) {
            //Sprite berupa hati warna merah jika nilai health lebih besar, sebaliknya adalah hati transparan
            if (i < health) {
                this.hearts[i].sprite = this.fullHeart;
            } else {
                this.hearts[i].sprite = this.emptyHeart;
            }
            //Tampilan hati merah sebanyak maxHealth - 1
            if (i < this.maxHealth) {
                this.hearts[i].enabled = true;
            } else {
                this.hearts[i].enabled = false;
            }
        }
    }
}
