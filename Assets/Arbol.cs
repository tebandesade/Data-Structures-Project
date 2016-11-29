using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Arbol : MonoBehaviour 
{
	public Nodo scriptNodo; 
	GameObject nodoRaiz = null;



	public void  newArbol(int valorr)
	{
		crearNodoRaiz(valorr);
	}

	private void crearNodoRaiz(int valorr)
	{
	  nodoRaiz = scriptNodo.crearNodo(valorr);

	}

	public void crearHijos(int valorr)
	{
		crearNodoIzquierdo( valorr);
		crearNodoDerecho( valorr);
	}


	public void crearNodoIzquierdo(int valorr)
	{
		nodoRaiz.GetComponent<Nodo> ().crearNodoIzquierdo (valorr);
	}

	public void crearNodoDerecho(int valorr)
	{

	}
}
