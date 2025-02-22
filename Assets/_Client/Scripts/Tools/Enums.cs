using UnityEngine.Rendering;

public enum WeaponState
{
    Idle = 1,
    Attack = 2, 
    Reload = 3
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

public enum GroundType
{
    None,
    Gravel, 
    Floor,
    Wood, 
    Tiles
}

public enum AmmoType
{
    None,
    Nothing,
    Bullet,
    Fraction
}

public enum WeaponType
{
    Axe,
    Pistol, 
    Shotgun
}