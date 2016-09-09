using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Graph : MonoBehaviour {

	//Gets inputField
	public  InputField input;

	//Gets button that accepts InputField
	public  Button acceptButton;

	//Gets inputField
	public  InputField inputCost;

	//Gets button that accepts InputField
	public  Button costButton;

	//Erased inputText

	//Arc that will join the two nodes
	public Arc arc;

	//Node selected #1
	public GameObject selectedNode1;

	//Node selected #2
	public GameObject selectedNode2;

	//Current Graph
	public Graph actual;

	public Canvas costCanvas;
	
	void Awake()
	{
		selectedNode1 = null;
		selectedNode2 = null;
		actual = this;
	}

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		verifySelection ();
	}


	//Setup for the nodes in 3D space
	public void nodeSetup()
	{
		string inputText = input.GetComponent<InputField> ().text;
		int amount = int.Parse (inputText); //# of nodes you want
		createNodes (amount);
		input.GetComponent<InputField> ().text = "";
		inputText = "";
		changeState (input.gameObject);
		changeState (acceptButton.gameObject);

	}

	//Creates the amount of nodes listed in 'amount'
	void createNodes(int amount)
	{
		for (int i = 0; i < amount; i++)
		{
			//Creates a primitive object that will represent the node
			GameObject newNode = GameObject.CreatePrimitive (PrimitiveType.Sphere);
			//Places the node in the current display
			Vector3 temp = new Vector3 (Random.Range(-10.0f,10.0f), Random.Range(-4.2f,6.10f), 0 );
			newNode.transform.position = temp;
			newNode.GetComponent<MeshRenderer> ().material.color = Color.red;
			newNode.tag = "nodo";
		}
	}

	//Changes the sate of a node
	void changeState(GameObject go)
	{
		if (go.activeSelf == true) 
		{
			go.SetActive (false);
		} 

		else 
		{
			go.SetActive (true);
		}
	}

	//Verifies if there is one node selected to create an arc 
	void verifySelection()
	{
		GameObject go = getGO ();

		if (go == null) 
		{

		}

		else
		{
			if (go.tag == "nodo") 
			{
				if (selectedNode1 != null) 
				{
					selectedNode2 = go;
					CreateArc ();
				} 
				else if (selectedNode1 == null && selectedNode2 == null) 
				{
					selectedNode1 = go;
					changeSate (selectedNode1.GetComponent<MeshRenderer> ());
				}
			}
		}
	}


	//Setup to create 
	void CreateArc()
	{
	//Checks if both selected nodes are the same, thus discards them as selected
		if (selectedNode1 == selectedNode2) {
			changeSate (selectedNode1.GetComponent<MeshRenderer> ());
			selectedNode1 = null;
			selectedNode2 = null;

		} else {
			changeSate (selectedNode2.GetComponent<MeshRenderer> ());
			createArc( selectedNode1 ,  selectedNode2);
		}
	}

	//Creates an Arc
	void createArc(GameObject go1, GameObject go2)
	{
		arc =new Arc (go1, go2, actual);

	}

	//Returns the current Node
	GameObject getGO()
	{
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hit;

		if (Input.GetMouseButtonDown (0)) {
			if (Physics.Raycast (ray, out hit)) {
				if (hit.collider.tag == "nodo") {
					return hit.collider.gameObject;
				} 
			}
		} 
		return null;
	}

	//Changes the color of the node to when it's active
	void changeSate(MeshRenderer mr)
	{
		if (mr.material.color == Color.red) 
		{
			mr.material.color = Color.green;
		} 

		else if(mr.material.color==Color.green)
		{
		  mr.material.color = Color.red;
		}
	}

	public	void enableCostInput()
	{
		changeState (costButton.gameObject);
		changeState (inputCost.gameObject);
			
	}

	public void verifyCostSet()
	{
		if (string.IsNullOrEmpty (inputCost.text)) {
			Debug.Log ("It's empty");
		} else { 
			Debug.Log ("It's not empty");
			arc.setCost (inputCost.text);
		}
	}
}
