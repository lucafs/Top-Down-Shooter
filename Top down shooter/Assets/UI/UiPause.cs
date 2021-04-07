using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiPause : MonoBehaviour
{

  GameManager gm;

  private void OnEnable()
  {
      gm = GameManager.GetInstance();
  }
 
  public void Retornar()
  {
      gm.ChangeState(GameManager.GameState.GAME);
  }

  public void Inicio()
  {
      gm.ChangeState(GameManager.GameState.MENU);
  }

}