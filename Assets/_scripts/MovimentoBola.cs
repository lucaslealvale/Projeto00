using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoBola : MonoBehaviour
{
    // Start is called before the first frame update
        [Range(1, 15)]
        public float velocidade = 5.0f;
        private Vector3 direcao;
        AudioSource somBolaBrick;
        // AudioSource somBolaRaquete;

        GameManager gm;

        void Start()

      {
                float dirX = Random.Range(-5.0f, 5.0f);
                float dirY = Random.Range(1.0f, 5.0f);

                direcao = new Vector3(dirX, dirY).normalized;
                somBolaBrick = GetComponent<AudioSource> ();
                // somBolaRaquete = GetComponent<AudioSource> ();
                gm = GameManager.GetInstance();
        }

    // Update is called once per frame
   void Update()
   {
       // primeira execução nas rotinas de Update() da Bola e Raquete.
       if (gm.gameState != GameManager.GameState.GAME) return;
       transform.position += direcao * Time.deltaTime * velocidade;

       Vector2 posicaoVP = Camera.main.WorldToViewportPoint(transform.position);

       if(posicaoVP.x < 0 || posicaoVP.x > 1)
       {
           direcao = new Vector3(-direcao.x, direcao.y);
       }
       if(posicaoVP.y > 1)
       {
           direcao = new Vector3(direcao.x, -direcao.y);
       }
       if(posicaoVP.y < 0)
       {
           Reset();
       }
       Debug.Log($"Vidas: {gm.vidas} \t | \t Pontos: {gm.pontos}");
    }

    private void Reset()
   {
       Vector3 playerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
       transform.position = playerPosition + new Vector3(0, 0.5f, 0);

       float dirX = Random.Range(-5.0f, 5.0f);
       float dirY = Random.Range(2.0f, 5.0f);

       direcao = new Vector3(dirX, dirY).normalized;
       gm.vidas--;
       if(gm.vidas <= 0 && gm.gameState == GameManager.GameState.GAME)
        {
        gm.ChangeState(GameManager.GameState.ENDGAME);
        } 
   }

 private void OnTriggerEnter2D(Collider2D col)
{
        if(col.gameObject.CompareTag("Player"))
        {
                // somBolaRaquete.Play ();
                float dirX = Random.Range(-5.0f, 5.0f);
                float dirY = Random.Range(1.0f, 5.0f);

                direcao = new Vector3(dirX, dirY).normalized;
        }
        else if(col.gameObject.CompareTag("Tijolo"))
        {
                somBolaBrick.Play ();
                direcao = new Vector3(direcao.x, -direcao.y);
                gm.pontos++;
        }
        Debug.Log("hit" + col.name);
        if(col.gameObject.CompareTag("hpUp")){
            gm.vidas++;
            Destroy (col.gameObject );
        }
}
}
