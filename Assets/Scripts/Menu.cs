using UnityEngine;
using System.Collections;

public class Menu : objectBase
{

    public void StartBtn()
    {
        Application.LoadLevel( "00.Play" );
    }

    public void QuitBtn()
    {
        Application.Quit();
    }
}
