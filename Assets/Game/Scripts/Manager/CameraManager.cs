using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private Transform runCamera;
    [SerializeField] private Transform paintCamera;

    private CameraFollow _cameraFollow;


    private void Awake()
    {
        _cameraFollow = GetComponent<CameraFollow>();
    }

    public void SetPaintCamera()
    {
        _cameraFollow.enabled = false;
        var transform1 = transform;
        transform1.position = paintCamera.position;
        transform1.rotation = paintCamera.rotation;
    }

    public void SetRunCamera()
    {
        _cameraFollow.enabled = true;
        var transform1 = transform;
        transform1.position = runCamera.position;
        transform1.rotation = runCamera.rotation;
    }
}