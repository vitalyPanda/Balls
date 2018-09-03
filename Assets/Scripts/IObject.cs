using UnityEngine;

public interface IObject
{
    int Index { get; }
    string Name { get; }
    Vector2 pos { get; }
    int num { get; }
}
