using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class Block : MonoBehaviour
{
    public int maxFallDistance;
    public virtual void Start()
    {
    }

    public virtual void Update()
    {
        if (this.transform.position.y <= this.maxFallDistance)
        {
            Application.LoadLevel("MainMenu");
        }
        if (this.transform.position.y >= PlayerPrefs.GetInt("Score"))
        {
            PlayerPrefs.SetInt("Score", (int) this.transform.position.y);
        }
    }

    public Block()
    {
        this.maxFallDistance = -1;
    }

}