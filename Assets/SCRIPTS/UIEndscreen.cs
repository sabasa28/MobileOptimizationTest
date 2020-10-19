using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIEndscreen : MonoBehaviour
{
    public Image winnerImg;
    public Sprite P2WonSprite;
    public Text p1Points;
    public Text p2Points;
    void Start()
    {
        if (DatosPartida.LadoGanadaor == DatosPartida.Lados.Der)
        {
            winnerImg.sprite = P2WonSprite;
            p1Points.text = "$" + DatosPartida.PtsPerdedor.ToString();
            p2Points.text = "$" + DatosPartida.PtsGanador.ToString();
        }
        else
        { 
            p1Points.text = "$" + DatosPartida.PtsGanador.ToString();
            p2Points.text = "$" + DatosPartida.PtsPerdedor.ToString();
        }
    }

}
