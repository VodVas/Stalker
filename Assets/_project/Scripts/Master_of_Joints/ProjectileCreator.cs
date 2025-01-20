using UnityEngine;

public class ProjectileCreator : MonoBehaviour
{
    [SerializeField] private Transform _projectile;
    [SerializeField] private Transform _position;

    public void Spawn()
    {
        Instantiate(_projectile, _position.position, Quaternion.identity);
    }
}