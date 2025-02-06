public enum WeaponState
{
    Idle = 1,
    Attack = 2
}

public enum PlayerState
{
    Idle = 1,
    Move = 2
}

public enum GameState
{
    Bootstrap, 
    Initialize,
    Menu, 
    LoadGame,
    Game, 
    CutScene,
    Pause, 
    Death
}