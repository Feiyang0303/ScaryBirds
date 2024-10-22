using System.Collections;
using System.Collections.Generic;
using System.Numerics;
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

    private void Update(){
        if(Mouse.current.leftButton.isPressed){
            DrawSlingShot();
        }
        // Debug.Log(Mouse.current.position.ReadValue());
    }
    private void DrawSlingShot(){
        Vector3 touchposition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        SetLines(touchposition);
    }
    private void SetLines(Vector2 position){
        Debug.Log(position);
        _leftLineRenderer.SetPosition(0, position);
        _leftLineRenderer.SetPosition(1, _leftStartPosition.position);

        _rightLineRenderer.SetPosition(0, position);
        _rightLineRenderer.SetPosition(1, _rightStartPosition.position);
    }
}
