using System.Collections;
using UnityEngine;

public class Huger : MonoBehaviour
{
    [SerializeField] private float _size = 1.2f;
    [SerializeField] private int frameCount = 7;

    private Transform _transform;

    private void Awake()
    {
        _transform = transform;
    }

    private void OnEnable()
    {
        StartCoroutine(ScaleChanging());
    }

    private IEnumerator ScaleChanging()
    {
        while (true)
        {
            for (int i = 0; i < frameCount; i++)
            {
                yield return null;
            }
            
            _transform.localScale += Vector3.one * _size;

            for (int i = 0; i < frameCount; i++)
            {
                yield return null;
            }
        }
    }
}