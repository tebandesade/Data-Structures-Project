using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class createArc {

	GameObject vertice1 ;
	GameObject vertice2 ; 

	public CreateGraph cg;

	LineRenderer rend;


	public createArc(GameObject go1 , GameObject go2, CreateGraph c)
	{
		cg = c;
		vertice1 = go1;
		vertice2 = go2;
		rend = vertice1.AddComponent<LineRenderer> ();
		rend.SetVertexCount (2);
		createLine ();
		Debug.Log (cg.input.IsActive() + "  fsadas");
	}

	void createLine()
	{
		//Ask for cost


		changeInputField ();

		rend.SetPosition (0, vertice1.transform.position);
		rend.SetPosition (1, vertice2.transform.position);



	}

	void changeInputField()
	{
		GameObject it = cg.input.gameObject;

	  
		it.SetActive (true);
		it.GetComponent<InputField> ().placeholder.GetComponent<Text> ().text = "What's the cost?";
	}
}
