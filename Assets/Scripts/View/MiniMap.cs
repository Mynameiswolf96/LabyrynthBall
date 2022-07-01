using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class MiniMap : MonoBehaviour
{
private Transform _player;
    // Start is called before the first frame update
    private void Start()
    {
        _player = Camera.main.transform;
        transform.parent = null;
        transform.rotation = Quaternion.Euler(90.0f, 45, 0);
        transform.position=_player.position+new Vector3(0, -10f, 0);
        var rt = Resources.Load<RenderTexture>("MiniMap/MiniMapTexture");
        GetComponent<Camera>().targetTexture = rt;

    }

    private void LateUpdate()
    {
        var newPosition = _player.position;
        newPosition.y = transform.position.y;
        transform.position = newPosition;
        transform.rotation=Quaternion.Euler(90f,0,0);
    }
}

