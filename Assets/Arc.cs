using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Arc {

	//Beginning node
	GameObject vertex1 ;

	//Ending node
	GameObject vertex2 ; 

	//Reference to the graph
	public Graph graph;

	//Line renderer that will be the shown arc
	LineRenderer rend;

	public Arc(GameObject go1 , GameObject go2, Graph graph)
	{
		graph = graph;
		vertex1 = go1;
		vertex2 = go2;
		rend = vertex1.AddComponent<LineRenderer> ();
		rend.SetVertexCount (2);
		createLine ();
	}

	//Displays a line that connects the two vertexs in 3D space
	void createLine()
	{
		//Ask for cost
		changeInputField ();
		rend.SetPosition (0, vertex1.transform.position);
		rend.SetPosition (1, vertex2.transform.position);
	}

	//The input field now asks for the cost of the arc created
	void changeInputField()
	{
		GameObject it = graph.input.gameObject;
		it.SetActive (true);
		it.GetComponent<InputField> ().placeholder.GetComponent<Text> ().text = "What's the cost?";
	}
}
