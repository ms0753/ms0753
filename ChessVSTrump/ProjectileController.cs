using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    public float speed = 0.8f;
    public float damage;
    private Vector3 startXPos;
    private Vector3 endXPos;

    private void Start()
    {
        startXPos = StageManager.instance.startXPos;
        endXPos = StageManager.instance.endXPos;
    }

    private void Update()
    {
        transform.position += new Vector3(speed * Time.fixedDeltaTime, 0, 0);
        if (transform.position.x > endXPos.x + 0.5)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Enemy")
        {
            if (other.TryGetComponent<HealthSystem>(out HealthSystem healthSystem))
            {
                healthSystem.ChangeHealth(-damage);
                SoundManager.instance.PlayEffect("ranged");
                Destroy(gameObject);
            }
        }
        
    }
}
