using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bloco : MonoBehaviour
{

    public GameObject diamante;
     

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
                double c =  Random.Range(0.0f, 1.0f);
                if(c<0.1){ 
                    Instantiate(diamante, transform.position, Quaternion.identity);
                }
                Destroy(gameObject);
        }
        
}
