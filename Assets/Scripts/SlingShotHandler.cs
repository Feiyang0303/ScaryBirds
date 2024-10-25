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
    [Header("Line Renderers")] 
    [SerializeField] private LineRenderer _leftLineRenderer;
    [SerializeField] private LineRenderer _rightLineRenderer;


    [Header("Transform References")]
    [SerializeField] private Transform _leftStartPosition;
    [SerializeField] private Transform _rightStartPosition;
    [SerializeField] private Transform _centerPosition;
    [SerializeField] private Transform _idlePosition;

    [Header("Slingshot Stats")]
    [SerializeField] private float _maxDistance = 3.5f;
    [SerializeField] private float _shotForce = 5f;
    [SerializeField] private float _timeBetweenBirdRespawns = 2f;

    [Header("Scripts")]
    [SerializeField] private SlingShotArea _slingshotArea;

    [Header("Bird")]
    [SerializeField] private bird1 _angieBirdPrefab;
    [SerializeField] private float _angieBirdPositionOffset = 2f;

    private Vector2 _slingShotLinesPosition;
    private Vector2 _direction;
    private Vector2 _directionNormalized;
    private bool _clickedWithinArea;
    private bool _birdOnSlingshot;
    private bird1 _spawnedAngieBird;
    
    // -------------------------------------------------------
    private void Awake(){
        _leftLineRenderer.enabled = false;
        _rightLineRenderer.enabled = false;

        SpawnAngieBird();
    }
    private void Update(){
        if(Mouse.current.leftButton.wasPressedThisFrame && _slingshotArea.IsWithinSlingShotArea()){
            _clickedWithinArea = true;
        }
        if(Mouse.current.leftButton.isPressed && _clickedWithinArea && _birdOnSlingshot){
            DrawSlingShot();
            PositionAndRotateAngieBird();
        }
        if(Mouse.current.leftButton.wasReleasedThisFrame && _birdOnSlingshot){
            if(GameManager.instance.HasEnoughShots()){
            _clickedWithinArea = false;

            _spawnedAngieBird.LaunchBird(_direction, _shotForce);

            GameManager.instance.UseShot();
            _birdOnSlingshot = false;

            SetLines(_centerPosition.position);
            if(GameManager.instance.HasEnoughShots()){
                StartCoroutine(SpawnAngieBirdAfterTime());
            }
           }
        }
        // Debug.Log(Mouse.current.position.ReadValue());
    }

    #region SlingShot Methods:

    private void DrawSlingShot(){
        Vector3 touchposition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        _slingShotLinesPosition = _centerPosition.position + Vector3.ClampMagnitude(touchposition - _centerPosition.position, _maxDistance);
        SetLines(_slingShotLinesPosition);

        _direction = (Vector2)_centerPosition.position - _slingShotLinesPosition;
        _directionNormalized = _direction.normalized;

    }
    private void SetLines(Vector2 position){
        // Debug.Log(position);
        if(!_leftLineRenderer.enabled && !_rightLineRenderer.enabled){
            _leftLineRenderer.enabled = true;
            _rightLineRenderer.enabled = true;
        }
        _leftLineRenderer.SetPosition(0, position);
        _leftLineRenderer.SetPosition(1, _leftStartPosition.position);

        _rightLineRenderer.SetPosition(0, position);
        _rightLineRenderer.SetPosition(1, _rightStartPosition.position);

    }

    #endregion

    #region Angie Bird Methods:

    private void SpawnAngieBird(){
        SetLines(_idlePosition.position);

        Vector2 dir = (_centerPosition.position - _idlePosition.position).normalized;
        Vector2 spawnPostion = (Vector2)_idlePosition.position * dir * _angieBirdPositionOffset;

        _spawnedAngieBird = Instantiate(_angieBirdPrefab, spawnPostion, UnityEngine.Quaternion.identity); // 0 rotation
        _spawnedAngieBird.transform.right = dir;

        _birdOnSlingshot = true;
    }

    private void PositionAndRotateAngieBird(){
        _spawnedAngieBird.transform.position = _slingShotLinesPosition + _directionNormalized * _angieBirdPositionOffset;
        _spawnedAngieBird.transform.right = _directionNormalized;
    }

    private IEnumerator SpawnAngieBirdAfterTime(){
        yield return new WaitForSeconds(_timeBetweenBirdRespawns);

        // Vector2 dir = (_centerPosition.position - _idlePosition.position).normalized;
        // Vector2 spawnPostion = (Vector2)_idlePosition.position * dir * _angieBirdPositionOffset;
        SpawnAngieBird();
    }
    #endregion
}
