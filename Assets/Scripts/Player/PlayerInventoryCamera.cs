using UnityEngine;
using DG.Tweening;

public class PlayerInventoryCamera : MonoBehaviour
{
    [SerializeField] private Camera _mainCamera;
    [Range(0.2f, 2f)][SerializeField] private float _moveTime = 0.5f;
    private Vector3 _startPosition;
    private Quaternion _startRotation;
    private Camera _camera;
    private bool _isCameraInInventoryMode = false;
    private void Awake()
    {
        _camera = GetComponent<Camera>();

        _startPosition = transform.localPosition;
        _startRotation = transform.localRotation;

    }
    // public void CallInventoryCamera()
    // {

    //     if(!_isCameraInInventoryMode)
    //     {
    //         GoToInventoryMode();
    //         _isCameraInInventoryMode = true;
    //     }
    //     else
    //     {
    //         GoToMainPlayerCamera();
    //         _isCameraInInventoryMode = false;
    //     }
    // }
    public void GoToInventoryMode()
    {
        _camera.depth = _mainCamera.depth + 10;

        transform.position = _mainCamera.transform.position;
        transform.rotation = _mainCamera.transform.rotation;

        transform.DOLocalMove(_startPosition, _moveTime);
        transform.DOLocalRotateQuaternion(_startRotation, _moveTime);
    }
    public void GoToMainPlayerCamera()
    {

        transform.DOMove(_mainCamera.transform.position, _moveTime);
        transform.DORotateQuaternion(_mainCamera.transform.rotation, _moveTime).OnComplete( () => _camera.depth = _mainCamera.depth - 10);

    }
}
