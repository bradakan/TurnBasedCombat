using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CanvasObjectFollowGameObject : MonoBehaviour {

    //this is your object that you want to have the UI element hovering over
    public Camera camera;
    public RectTransform canv;
    public RectTransform text;
    public bool follow = true;

    // Use this for initialization
    void Start ()
    {
        camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        canv = GameObject.FindGameObjectWithTag("Canvas").GetComponent<RectTransform>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (text != null && follow)
        {
            text.position = GetScreenPosition(transform, canv, camera);
        }
        
    }

    public static Vector3 GetScreenPosition(Transform transform, RectTransform canvas, Camera cam)
    {
        Vector3 pos;
        float width = canvas.sizeDelta.x;
        float height = canvas.sizeDelta.y;
        float x = Camera.main.WorldToScreenPoint(transform.position).x / Screen.width;
        float y = Camera.main.WorldToScreenPoint(transform.position).y / Screen.height;
        pos = new Vector3(width * x, y * height);
        return pos;
    }

    public void AddText(int num)
    {
        if (text)
        {
            Destroy(text.gameObject);

        }
        GameObject temp = Instantiate(Resources.Load("Text") as GameObject);
        temp.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
        temp.GetComponent<Text>().text = Mathf.Abs(num).ToString();
        //because im working with damage numbers the color will change according to damage 
        if (num < 0)
        {
            temp.GetComponent<Text>().color = Color.red;
        }
        else
        {
            temp.GetComponent<Text>().color = Color.green;
        }
        text = temp.GetComponent<RectTransform>();
    }
    public void ChangeText(int num)
    {
        //using a num for now as the only thing i will use this here id to keep track of hp
        text.GetComponent<Text>().text = num.ToString();
        if (num < 30)
        {
            text.GetComponent<Text>().color = Color.red;
        }
        else if (num < 60)
        {
            text.GetComponent<Text>().color = Color.yellow;
        }
        else
        {
            text.GetComponent<Text>().color = Color.green;
        }
    }

    public void DestroyTextAndSelf()
    {

    }
}
