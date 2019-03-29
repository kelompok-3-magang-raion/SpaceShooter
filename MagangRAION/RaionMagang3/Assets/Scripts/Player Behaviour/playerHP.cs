using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class playerHP : MonoBehaviour
{
    public bool animated;
    public Animator animator;
    public int hp;
    

    private void Start()
    {
        
    }

    void Update()
    {         
        
    }

    public void takeDamage (int damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            // Instantiate(playerDeathParticle, transform.position, Quaternion.identity); //buat kalo pake partikel ancur
            if (animated)
            {
                animator.SetBool("isDestroyed", true);
            }
            FindObjectOfType<AudioManager>().Play("Destroyed");

            hp = 0;
        }
    }


}
