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
    FinishigGame
}

public enum SurfaceType
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
    None, 
    Axe,
    Pistol, 
    Shotgun
}

public enum PlayerWeaponsTypes
{
    Axe, 
    Pistol,
    Shotgun
}

public enum HandsState
{
    Hands,
    Weapon
}