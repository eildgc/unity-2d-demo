using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject projectile;
    public float fireDelay = 1f;
    private float timeSinceLastFire = 0f;
    public float playerSpeed = 0.1f;
    public string damageableTargetTag = "";
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // -1 <-- 0 --> 1 
        float verticalMovement = Input.GetAxis("Vertical");
        float horizontalMovement = Input.GetAxis("Horizontal");

        if (verticalMovement != 0f || horizontalMovement != 0f) {
            Vector2 newPosition = new Vector2(horizontalMovement * playerSpeed, verticalMovement * playerSpeed);
            transform.Translate(newPosition);
        }
        //Shot
        
        // if (Input.GetKeyDown(KeyCode.Space)){
        //     Debug.Log("Pew");
        //     Instantiate(projectile, transform.position + new Vector3(0f,2f,0f), transform.rotation);
        // }
        
        //Agregar tiempode ultimo frame al tiempo transcurrido
        timeSinceLastFire += Time.deltaTime;
        //Solamente se puede disparar si ya paso el tiempo definido
        if (timeSinceLastFire >= fireDelay){
            //Can shoot
            if (Input.GetButton("Fire1")){
                // Debug.Log("Pew");
                //Crear proyectil
                Instantiate(projectile, transform.position + new Vector3(0f,2f,0f), transform.rotation);
                projectile.GetComponent<Projectile>().damageableTargetTag = "Enemy";
                //Reiniciar contador de tiempo para disparar
                timeSinceLastFire = 0f;
            }
        }
    }
}
