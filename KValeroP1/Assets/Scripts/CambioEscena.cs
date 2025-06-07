using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioEscena : MonoBehaviour
{
    public void CambiarEscenaPorNombre(string nombreEscena)
    {
        SceneManager.LoadScene(nombreEscena);
    }

    public void CerrarAplicaci�n()
    {
        Application.Quit();
        print("Aplicaci�n cerrada");
    }
}
