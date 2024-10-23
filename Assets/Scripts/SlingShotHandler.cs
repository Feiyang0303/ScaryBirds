using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class SlingShotHandler : MonoBehaviour
{
    [SerializeField] private LineRenderer _leftLineRenderer;
    [SerializeField] private LineRenderer _rightLineRenderer;

    [SerializeField] private Transform _leftStartPosition;
    [SerializeField] private Transform _rightStartPosition;
    [SerializeField] private Transform _centerPosition;
    [SerializeField] private Transform _idlePosition;
    [SerializeField] private float _maxDistance = 3.5f;
    [SerializeField] private SlingShotArea _slingshotArea;
    private Vector2 _slingShotLinesPosition;
    private bool _clickedWithinArea;

    private void Update(){
        if(Mouse.current.leftButton.wasPressedThisFrame && _slingshotArea.IsWithinSlingShotArea()){
            _clickedWithinArea = true;
        }
        if(Mouse.current.leftButton.isPressed && _clickedWithinArea){
            DrawSlingShot();
        }
        if(Mouse.current.leftButton.wasReleasedThisFrame){
            _clickedWithinArea = false;
        }
        // Debug.Log(Mouse.current.position.ReadValue());
    }
    private void DrawSlingShot(){
        Vector3 touchposition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        _slingShotLinesPosition = _centerPosition.position + Vector3.ClampMagnitude(touchposition - _centerPosition.position, _maxDistance);
        SetLines(_slingShotLinesPosition);

    }
    private void SetLines(Vector2 position){
        Debug.Log(position);
        _leftLineRenderer.SetPosition(0, position);
        _leftLineRenderer.SetPosition(1, _leftStartPosition.position);

        _rightLineRenderer.SetPosition(0, position);
        _rightLineRenderer.SetPosition(1, _rightStartPosition.position);
    }
}
