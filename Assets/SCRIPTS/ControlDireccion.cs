using UnityEngine;
using System.Collections;

public class ControlDireccion : MonoBehaviour 
{
    public string player = "";

	public Transform ManoDer;
	public Transform ManoIzq;
	
	public float MaxAng = 90;
	public float DesSencibilidad = 90;


	CarController carController;
   

	public bool Habilitado = true;
	//float Diferencia;
		
	//---------------------------------------------------------//
	
	// Use this for initialization
	void Start () 
	{
		carController = GetComponent<CarController>();
	}
	
	// Update is called once per frame
	void Update () 
	{
        float axis = InputManager.Instance.GetAxis(InputManager.Instance.horizontal + player);
		carController.SetGiro(axis);
	}
	
	float Angulo()
	{
		Vector2 diferencia = new Vector2(ManoDer.localPosition.x, ManoDer.localPosition.y)
						   - new Vector2(ManoIzq.localPosition.x, ManoIzq.localPosition.y);
		
		return Vector2.Angle(diferencia,new Vector2(1,0));
	}
	
}
