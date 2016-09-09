using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Arc {

	//Beginning node
	GameObject vertex1 ;

	//Ending node
	GameObject vertex2 ; 

	//Reference to the graph
	public  Graph graph;
	//Line renderer that will be the shown arc
	LineRenderer rend;



	public Arc(GameObject go1 , GameObject go2,Graph grap)
	{
		graph = grap;
		vertex1 = go1;
		vertex2 = go2;
		rend = vertex1.AddComponent<LineRenderer> ();
		rend.material.color = Color.blue;
		rend.SetVertexCount (2);
		createLine ();
	}



	//Displays a line that connects the two vertexs in 3D space
	void createLine()
	{
		//Ask for cost
		graph.enableCostInput();
		rend.SetPosition (0, vertex1.transform.position);
		rend.SetPosition (1, vertex2.transform.position);
	}

	public void setCost(string tex)
	{
		Vector3 first = vertex1.transform.position;
		Vector3 second = vertex2.transform.position;
		Vector3 result = (first + second)/2;
		GameObject texto = new GameObject ();
		texto.transform.position = result;
		texto.transform.SetParent (graph.costCanvas.transform);
		texto.AddComponent<Text> ();
		texto.GetComponent<Text> ().text = "Hola";
	} 

}
		
