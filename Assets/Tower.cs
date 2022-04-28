using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class Tower : MonoBehaviour
{
    public GameObject original;
    public int Blocks;
    public virtual void Start()
    {
        PlayerPrefs.SetInt("Score", 0);
    }

    public virtual void Update()
    {
        RaycastHit hit = default(RaycastHit);
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            this.Blocks = this.Blocks + 1;
            if (Physics.Raycast(ray, out hit))
            {
                Vector3 dingus = ray.GetPoint(10);
                UnityEngine.Object.Instantiate(this.original, dingus, this.transform.rotation);
            }
        }
        if (PlayerPrefs.GetInt("Best") <= PlayerPrefs.GetInt("Score"))
        {
            PlayerPrefs.SetInt("Best", PlayerPrefs.GetInt("Score"));
        }

        {
            int _1 = //camera
            PlayerPrefs.GetInt("Score");
            Vector3 _2 = this.transform.position;
            _2.y = _1;
            this.transform.position = _2;
        }
    }

    public virtual void OnGUI()
    {
        GUI.skin.box.fontSize = Screen.width / 40;
        //Boxes
        GUI.Box(new Rect(Screen.width - (Screen.width / 4), 0, Screen.width / 4, Screen.height / 16), "Current Score: \n" + PlayerPrefs.GetInt("Score"));
        GUI.Box(new Rect(0, 0, Screen.width / 4, Screen.height / 16), "Blocks Used: \n" + this.Blocks);
        GUI.Box(new Rect(((Screen.width / 8) + 20) + (Screen.width / 8), 0, Screen.width / 6, Screen.height / 16), "Current Time: \n" + Time.timeSinceLevelLoad);
        if (0 >= PlayerPrefs.GetInt("Best"))
        {
            GUI.Box(new Rect((((Screen.width / 8) + (Screen.width / 8)) + (Screen.width / 6)) + 30, 0, Screen.width / 6, Screen.height / 16), "No High Score!!!");
        }
        else
        {
            if (0 <= PlayerPrefs.GetInt("Best"))
            {
                GUI.Box(new Rect((((Screen.width / 8) + (Screen.width / 8)) + (Screen.width / 6)) + 30, 0, Screen.width / 6, Screen.height / 16), "High Score: \n" + PlayerPrefs.GetInt("Best"));
            }
        }
    }

}
