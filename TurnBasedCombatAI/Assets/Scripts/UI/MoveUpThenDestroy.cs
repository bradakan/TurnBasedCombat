using UnityEngine;
using System.Collections;

public class MoveUpThenDestroy : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        Invoke("DestroyTextAndMe", 1f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up*Time.deltaTime*2);
    }

    void DestroyTextAndMe()
    {
        Destroy(GetComponent<CanvasObjectFollowGameObject>().text.gameObject);
        Destroy(this.gameObject);
    }
}
