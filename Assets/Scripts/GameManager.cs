using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    
    protected GameManager()
    {
        GameState = GameState.Start;
    }
    
    public GameState GameState { get; set; }
    
    public void Die()
    {
        // UIManager.Instance.SetStatus(Constants.StatusDeadTapToStart);
        this.GameState = GameState.Dead;
    }
    
    
}
