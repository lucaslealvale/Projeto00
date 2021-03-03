using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlocoSpawner : MonoBehaviour
{
  public GameObject BlocoAzul;
  public GameObject BlocoVerde;
  public GameObject BlocoRoxo;


  GameManager gm;

  void Start()
  {
      gm = GameManager.GetInstance();
      GameManager.changeStateDelegate += Construir;
      Construir();
  }

  void Construir()
  {
     

       if (gm.gameState == GameManager.GameState.MENU)
      {
          foreach (Transform child in transform) {
              GameObject.Destroy(child.gameObject);
          }
          for(int i = 0; i < 7; i++)
          {
              for(int j = 0; j < 4; j++){
                  Vector3 posicao = new Vector3(-7.8f + 2.5f * i, 0.3f - 1.0f * j);
                  
                  double c =  Random.Range(0.0f, 1.0f);

                  if(c<0.333f){ 

                  GameObject tile = Instantiate(BlocoAzul, posicao, Quaternion.identity, transform);
                  
                  }
                  else if(c>0.333f && c<0.666f){ 

                  GameObject tile = Instantiate(BlocoVerde, posicao, Quaternion.identity, transform);
                  
                  }else{

                  GameObject tile = Instantiate(BlocoRoxo, posicao, Quaternion.identity, transform);

                  };
              }
          }
      }
  }

  void Update()
  {
      if (transform.childCount <= 0 && gm.gameState == GameManager.GameState.GAME)
      {
          gm.ChangeState(GameManager.GameState.ENDGAME);
      }
  }

}