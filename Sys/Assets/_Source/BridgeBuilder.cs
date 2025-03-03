using Character;
using System;
using TMPro;
using UnityEngine;

public class BridgeBuilder : MonoBehaviour
{
    [SerializeField] private LayerMask playerLayerMask;
    [SerializeField] private TextMeshProUGUI hint;
    [SerializeField] private GameObject bridge;
    [SerializeField] private Transform bridgeNormalPos;
    [SerializeField] private float bridgeSpeed;

    private int _playerLayer;
    private bool isBrigeMoving;
    private float _time;

    void Start()
    {
        _playerLayer = (int)Math.Log(playerLayerMask.value, 2);
    }

    private void Update()
    {
        if (isBrigeMoving)
        {
            bridge.transform.position = Vector3.Lerp(bridge.transform.position, bridgeNormalPos.position, bridgeSpeed * _time);
            _time += Time.deltaTime;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.layer == _playerLayer)
        {
            if (SoulCounter.isEnoghSouls)
            {
                hint.gameObject.SetActive(true);
                if (Input.GetKeyDown(KeyCode.F))
                    SummonBridge();
            }        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.layer == _playerLayer)
        {
            hint.gameObject.SetActive(false);
        }
    }

    public void SummonBridge()
    {
        bridge.gameObject.SetActive(true);
        isBrigeMoving = true;
    }
}
