using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

///<summary> Spawn renderers and adjust position </summary>
public class SnakeRenderer : MonoBehaviour
{
    [SerializeField] Snake _snake;
    [SerializeField] GameObject _bodyPrefab;
    List<RectTransform> _bodyRenderers;

    void Start()
    {
        _bodyRenderers = new List<RectTransform>();
    }

    void LateUpdate()
    {
        var snakeBody = _snake.GetBody();
        PollRenderers(snakeBody.Count - _bodyRenderers.Count);
        UpdateRenderers(snakeBody);
    }

    void PollRenderers(int count)
    {
        for(int i = 0; i < count; i++)
        {
            var img = Instantiate(_bodyPrefab) as GameObject;
            img.transform.SetParent(transform, false);
            _bodyRenderers.Add(img.GetComponent<RectTransform>());
        }
    }

    void UpdateRenderers(List<Vector2> body)
    {
        for(int i = 0; i < _bodyRenderers.Count; i++)
        {
            _bodyRenderers[i].anchoredPosition = body[i] * GameConstants.GridSize;
        }
    }
}