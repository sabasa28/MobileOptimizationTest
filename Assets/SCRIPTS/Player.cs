using UnityEngine;
using System.Collections;
using System;

public class Player : MonoBehaviour 
{
	public int Dinero = 0;
	public int IdPlayer = 0;
	
	public Bolsa[] Bolasas;
	int CantBolsAct = 0;
	public string TagBolsas = "";
	
	public enum Estados{EnDescarga, EnConduccion, EnCalibracion, EnTutorial}
	public Estados EstAct = Estados.EnConduccion;
	
	public bool EnConduccion = true;
	public bool EnDescarga = false;
	
	public ControladorDeDescarga ContrDesc;
	public ContrCalibracion ContrCalib;
	public ContrTutorial ContrTuto;

	public GameObject conduccionUI;

	Visualizacion MiVisualizacion;
	public Action<int, int, int> UpdateUI;
	
	//------------------------------------------------------------------//

	// Use this for initialization
	void Start () 
	{
		for(int i = 0; i< Bolasas.Length;i++)
			Bolasas[i] = null;
		
		MiVisualizacion = GetComponent<Visualizacion>();
	}

	public bool AgregarBolsa(Bolsa b)
	{
		if(CantBolsAct + 1 <= Bolasas.Length)
		{
			Bolasas[CantBolsAct] = b;
			CantBolsAct++;
			Dinero += (int)b.Monto;
			b.Desaparecer();
			UpdateUI(IdPlayer, Dinero, CantBolsAct);
			return true;
		}
		else
		{
			return false;
		}
	}
	
	public void VaciarInv()
	{
		for(int i = 0; i< Bolasas.Length;i++)
			Bolasas[i] = null;
		
		CantBolsAct = 0;
		UpdateUI(IdPlayer, Dinero, CantBolsAct);
	}
	
	public bool ConBolasas()
	{
		for(int i = 0; i< Bolasas.Length;i++)
		{
			if(Bolasas[i] != null)
			{
				return true;
			}
		}
		return false;
	}
	
	public void SetContrDesc(ControladorDeDescarga contr)
	{
		ContrDesc = contr;
	}
	
	public ControladorDeDescarga GetContr()
	{
		return ContrDesc;
	}
	
	public void CambiarACalibracion()
	{
		MiVisualizacion.CambiarACalibracion();
		EstAct = Player.Estados.EnCalibracion;
	}
	
	public void CambiarATutorial()
	{
		MiVisualizacion.CambiarATutorial();
		EstAct = Player.Estados.EnTutorial;
		ContrTuto.Iniciar();
	}
	
	public void CambiarAConduccion()
	{
		MiVisualizacion.CambiarAConduccion(conduccionUI);
		EstAct = Player.Estados.EnConduccion;
	}
	
	public void CambiarADescarga()
	{
		MiVisualizacion.CambiarADescarga();
		EstAct = Player.Estados.EnDescarga;
	}
	
	public void SacarBolasa()
	{
		for(int i = 0; i < Bolasas.Length; i++)
		{
			if(Bolasas[i] != null)
			{
				Bolasas[i] = null;
				return;
			}				
		}
	}
	
	
}
