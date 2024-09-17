using UnityEngine;

public class VFXManager : MonoBehaviour
{
    [SerializeField] private GameObject _vfx;

    public void PlayVFX(Vector3 spawnPosition)
    {
        Instantiate(_vfx, spawnPosition, Quaternion.identity);
    }
}