using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SandResource : MonoBehaviour
{
    public float dropToYPos;

    private float speed = .01f;

    private void Start()
    {
        Destroy(gameObject, Random.Range(6f, 12f));
    }

    private void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, Mathf.Infinity, 9);

        if(hit.collider && hit.collider.gameObject == gameObject)
        {
            if (Input.GetMouseButtonDown(0))
            {
                SoundManager.instance.PlayEffect("obtain");
                Destroy(gameObject);
            } 
        }
    }
}
