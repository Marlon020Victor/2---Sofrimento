using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CarregarCutscene : MonoBehaviour
{
    public string CenaLoad;
    
    // Start is called before the first frame update
    void Start()
    {
        SceneManager.LoadScene(CenaLoad);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
