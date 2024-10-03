using UnityEngine;

public interface IPlayer
{
    public Vector3 Pos { get; }
    public void Teleport(Vector3 newPos);
}
