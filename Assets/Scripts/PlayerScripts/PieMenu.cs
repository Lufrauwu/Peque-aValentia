using UnityEngine;
using UnityEngine.UI;

public class PieMenu : MonoBehaviour
{
    [SerializeField] private Color _hoverColor = default;
    [SerializeField] private Color _baseColor = default;
    [SerializeField] private Image _background = default;
    void Start()
    {
        _background.color = _baseColor;
    }

    public void Select()
    {
        _background.color = _hoverColor;
    }

    public void Deselect()
    {
        _background.color = _baseColor;
    }

}
