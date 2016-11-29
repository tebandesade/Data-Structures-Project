using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Nodo : MonoBehaviour {
	GameObject nodo;
	Vector3 izquierda = new Vector3(-4,-2,0);
	Vector3 derecha = new Vector3(4,-2,0);
	List<GameObject> leftChilds = new List<GameObject>();
	List<GameObject> rightChilds = new List<GameObject>();


	int valor; 
	// Use this for initialization

	public GameObject crearNodo(int valorr)
	{
		valor = valorr;
	 	nodo =  GameObject.CreatePrimitive (PrimitiveType.Sphere);
		nodo.AddComponent<Nodo> ();
		nodo.GetComponent<Nodo> ().setValor (valorr);
		return nodo;
	}


	public void crearNodoIzquierdo(int valorr)
	{
		GameObject hijo = GameObject.CreatePrimitive (PrimitiveType.Sphere);
		hijo.transform.Translate (izquierda);
		leftChilds.Add (hijo);
	}

	public GameObject crearNodoDerecho(int valorr)
	{
		return null;
	}

	public void setValor(int valorr)
	{
		this.valor = valorr ;
	}




}
