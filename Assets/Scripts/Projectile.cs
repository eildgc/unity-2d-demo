using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

        // Start is called before the first frame update
    public float projectileSpeed = 0.5f;
    public int maxYPosition = 100;

    public int minYPosition = -100;

    public string damageableTargetTag = "";
    void Start()
    {
        
    }

    // Update is called once per frame
   
    void Update()
    {
        transform.Translate(new Vector2(0f, projectileSpeed));
        if (transform.position.y > maxYPosition || transform.position.y < minYPosition){
            Destroy(gameObject);
        }
            
        }
    private void OnCollisionEnter2D(Collision2D other) {
        
        if (other.gameObject.tag == damageableTargetTag) {
            Stats enemyStats = other.gameObject.GetComponent<Stats>();
            enemyStats.OnHit();
            Debug.Log(other.gameObject);

        }
            
    }
}
