using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimentoRaquete : MonoBehaviour
{
    [Range(1, 10)]
    public float velocidade;
    
    float bordaEsquerda = -7.9f;
    float bordaDireita = 7.9f;

    GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
    gm = GameManager.GetInstance();

    }

    // Update is called once per frame
    void Update()
    {
        if (gm.gameState != GameManager.GameState.GAME) return;

        float inputX = Input.GetAxis("Horizontal");
        transform.position += new Vector3(inputX, 0, 0) * Time.deltaTime * velocidade;  

        if(transform.position.x < bordaEsquerda){
            transform.position = new Vector4(bordaEsquerda,transform.position.y);
        }
        
        if(transform.position.x > bordaDireita){
            transform.position = new Vector4(bordaDireita,transform.position.y);
        }

        if(Input.GetKeyDown(KeyCode.Escape) && gm.gameState == GameManager.GameState.GAME) {
            gm.ChangeState(GameManager.GameState.PAUSE);
        }
    }
}
