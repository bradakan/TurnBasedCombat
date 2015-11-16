using UnityEngine;
using System.Collections;

public class DamagePopUp : MonoBehaviour
{

    private GameObject _target;
    private int _healthChangeValue;
    private GameObject _healthIndicator;
    private TextMesh _textMesh;
    private MeshRenderer _meshRenderer;

    //outline variables
    public float pixelSize = 1;
    public Color outlineColor = Color.black;
    public bool resolutionDependant = false;
    public int doubleResolution = 1024;

    private TextMesh textMesh;
    private MeshRenderer meshRenderer;
    // Use this for initialization
    void Start()
    {
        _target = this.gameObject;
        DamagePopupFunc(-5);
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
            _healthChangeValue = Mathf.Abs(_healthChangeValue);
        }
        else
        {
            _textMesh.color = Color.green;
        }

        _textMesh.text = _healthChangeValue.ToString();
        _textMesh.characterSize = 1f;

        _healthIndicator.transform.position = _target.transform.position;

        //start of outline code
        textMesh = _healthIndicator.GetComponent<TextMesh>();
        meshRenderer = _healthIndicator.GetComponent<MeshRenderer>();

        for (int i = 0; i < 8; i++)
        {
            GameObject outline = new GameObject("outline", typeof(TextMesh));
            outline.transform.parent = _healthIndicator.transform;
            outline.transform.localScale = new Vector3(1, 1, 1);

            MeshRenderer otherMeshRenderer = outline.GetComponent<MeshRenderer>();
            otherMeshRenderer.material = new Material(meshRenderer.material);
            otherMeshRenderer.castShadows = false;
            otherMeshRenderer.receiveShadows = false;
            otherMeshRenderer.sortingLayerID = meshRenderer.sortingLayerID;
            otherMeshRenderer.sortingLayerName = meshRenderer.sortingLayerName;
        }
        //part of outline code
        Vector3 screenPoint = Camera.main.WorldToScreenPoint(transform.position);

        outlineColor.a = textMesh.color.a * textMesh.color.a;

        // copy attributes
        for (int i = 0; i < _healthIndicator.transform.childCount; i++)
        {
            TextMesh other = _healthIndicator.transform.GetChild(i).GetComponent<TextMesh>();
            other.color = outlineColor;
            other.text = textMesh.text;
            other.alignment = textMesh.alignment;
            other.anchor = textMesh.anchor;
            other.characterSize = textMesh.characterSize;
            other.font = textMesh.font;
            other.fontSize = textMesh.fontSize;
            other.fontStyle = textMesh.fontStyle;
            other.richText = textMesh.richText;
            other.tabSize = textMesh.tabSize;
            other.lineSpacing = textMesh.lineSpacing;
            other.offsetZ = textMesh.offsetZ;

            bool doublePixel = resolutionDependant && (Screen.width > doubleResolution || Screen.height > doubleResolution);
            Vector3 pixelOffset = GetOffset(i) * (doublePixel ? 2.0f * pixelSize : pixelSize);
            Vector3 worldPoint = Camera.main.ScreenToWorldPoint(screenPoint + pixelOffset);
            other.transform.position = worldPoint;

            MeshRenderer otherMeshRenderer = _healthIndicator.transform.GetChild(i).GetComponent<MeshRenderer>();
            otherMeshRenderer.sortingLayerID = meshRenderer.sortingLayerID;
            otherMeshRenderer.sortingLayerName = meshRenderer.sortingLayerName;
        }
    }


    Vector3 GetOffset(int i)
    {
        switch (i % 8)
        {
            case 0: return new Vector3(0, 1, 0);
            case 1: return new Vector3(1, 1, 0);
            case 2: return new Vector3(1, 0, 0);
            case 3: return new Vector3(1, -1, 0);
            case 4: return new Vector3(0, -1, 0);
            case 5: return new Vector3(-1, -1, 0);
            case 6: return new Vector3(-1, 0, 0);
            case 7: return new Vector3(-1, 1, 0);
            default: return Vector3.zero;
        }
    }



}
