using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager
{
    public enum GameState { MENU, GAME, PAUSE, ENDGAME };
    public GameState gameState { get; private set; }
    public int vidas;
    public int pontos;
    public int hordes;
    public int granades;
    public int reset = 0;
    public int shotgun;
    public int shotgunBullets = 0;
    public int coins = 0;
    public Vector2 spawn;
    public int difCount;
    private static GameManager _instance;
    public delegate void ChangeStateDelegate();
    public static ChangeStateDelegate changeStateDelegate;

    public static GameManager GetInstance()
    {
        if (_instance == null)
        {
            _instance = new GameManager();
        }

        return _instance;
    }
    private GameManager()
    {
        difCount = 0;
        vidas = 4;
        pontos = 0;
        hordes = 0;
        coins = 0;
        shotgunBullets = 0;
        granades = 1;
        shotgun = 0;
        gameState = GameState.MENU;
    }

    public void ChangeState(GameState nextState)
    {
        if (nextState == GameState.GAME && gameState!= GameState.PAUSE)
        {
            Reset();
        }
        gameState = nextState;
        changeStateDelegate();
    }
    public void Reset()
    { 
        reset = 1;
        difCount = 0;
        vidas = 4;
        hordes = 0;
        shotgun = 0;
        coins = 0;
        shotgunBullets = 0;
        pontos = 0;
        granades = 1;
    }
}