using UnityEngine;
using System.Collections;

public class DamagePopUp : MonoBehaviour
{

    private GameObject _target;
    private int _healthChangeValue;
    private GameObject _healthIndicator;
    private TextMesh _textMesh;
    private MeshRenderer _meshRenderer;
    // Use this for initialization
    void Start()
    {
        _target = this.gameObject;
        DamagePopupFunc(5);
    }

    // Update is called once per frame
    
    void DamagePopupFunc(int hpChange)
    {
        _healthChangeValue = hpChange;
        _healthIndicator = new GameObject();
        _textMesh = _healthIndicator.AddComponent<TextMesh>();

        if (_healthChangeValue < 0)
        {
            _textMesh.color = Color.red;
        }
        else
        {
            _textMesh.color = Color.green;
        }

        _textMesh.text = _healthChangeValue.ToString();
        _textMesh.characterSize = 0.2f;

        _healthIndicator.transform.position = _target.transform.position;
    }
    
}
