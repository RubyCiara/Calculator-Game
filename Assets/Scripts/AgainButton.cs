using UnityEngine;
using UnityEngine.SceneManagement;

public class AgainButton : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Pressed()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
