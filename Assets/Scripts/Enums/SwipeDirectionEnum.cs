namespace UsefulUnityScripts
{
    [System.Flags]
    public enum SwipeDirection
    {
        None = 0,
        Up = 1,
        Right = 2,
        Down = 4,
        Left = 8,
        UpRight = Up | Right,
        DownRight = Down | Right,
        DownLeft = Down | Left,
        UpLeft = Up | Left,
    } 
}
