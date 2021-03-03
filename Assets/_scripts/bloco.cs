using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bloco : MonoBehaviour
{
    public static char cor;
    // Start is called before the first frame update
       void Start()
    {
       
        // Color newColor = new Color(0.0f,0.9f,0.9f, 1.0f);
        // GetComponent<SpriteRenderer>().color = newColor;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
        {

                Destroy(gameObject);
        }
        
}
