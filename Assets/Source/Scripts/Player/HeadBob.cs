using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadBob : MonoBehaviour
{
    [Header("HeadBob Effect")]
    [SerializeField] bool Enabled = true;
    [Space, Header("Main")]
    [SerializeField, Range(0.001f, 100f)] float Amount = 0.00484f;
    [SerializeField, Range(10f, 30f)] float Frequency = 16.0f;
    [SerializeField, Range(0f, 100f)] float Smooth = 44.7f;
    [Header("RoationMovement")]
    [SerializeField] bool EnabledRoationMovement = true;
    [SerializeField, Range(40f, 4f)] float RoationMovementSmooth = 10.0f;
    [SerializeField, Range(1f, 10f)] float RoationMovementAmount = 3.0f;
    [SerializeField] private float _speedReturn = 0.8f;
    [SerializeField] float ToggleSpeed = 3.0f;
    CharacterController player;

    Vector3 StartPos;
    Vector3 FinalRot;

    private float _timeStartedLerping;
    private bool _stopMoving;
    private bool _isMoving;

    private void Awake()
    {
        StartPos = transform.localPosition;
        player = GetComponentInParent<CharacterController>();
    }

    private void Update()
    {
        if (!Enabled) return;
        CheckMotion();
        ResetPos();
        if (EnabledRoationMovement) transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.Euler(FinalRot), RoationMovementSmooth * Time.deltaTime);
    }

    private void CheckMotion()
    {
        if (!player.isGrounded) return;

        float speed = new Vector3(player.velocity.x, 0, player.velocity.z).magnitude;

        if (speed < ToggleSpeed)
        {
            if (_isMoving)
            {
                _stopMoving = true;
            }

            _isMoving = false;
            return;
        }

        if (_isMoving is false)
        {
            StartCoroutine(HeadBobLerp());
        }

    }

    private void ResetPos()
    {
        float percentageComplete;

        if (transform.localPosition == StartPos || _isMoving)
        {
            percentageComplete = 0f;
            _timeStartedLerping = 0f;
            return;
        }

        if (_stopMoving)
        {
            _timeStartedLerping = Time.time;
            _stopMoving = false;
        }

        float timeSinceStarted = Time.time - _timeStartedLerping;
        percentageComplete = timeSinceStarted / _speedReturn;
        transform.localPosition = Vector3.Lerp(transform.localPosition, StartPos, percentageComplete);
    }

    private IEnumerator HeadBobLerp()
    {
        var progressY = 0f;
        var progressX = 0f;

        Vector3 pos = Vector3.zero;

        _isMoving = true;

        while (_isMoving)
        {
            pos.y = Mathf.Lerp(-1f * Amount, 1f * Amount, Mathf.Sin(progressY * Mathf.PI * 2f) / 2f + 0.5f);
            pos.x = Mathf.Lerp(-1f * Amount, 1f * Amount, Mathf.Cos(Mathf.PI / 2f + progressX * Mathf.PI * 2f) / 2f + 0.5f);
            transform.localPosition = pos;
            progressY += Time.deltaTime * Smooth;
            progressX += Time.deltaTime * Smooth / 2f;
            FinalRot = new Vector3(-pos.x, -pos.y, pos.x) * RoationMovementAmount;

            if (progressY >= 1f)
            {
                progressY = 0f;
            }

            if (progressX >= 1f)
            {
                progressX = 0f;
            }

            yield return null;
        }
        _stopMoving = true;
    }
}
