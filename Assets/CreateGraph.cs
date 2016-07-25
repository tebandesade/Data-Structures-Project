using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CreateGraph : MonoBehaviour {

	//Gets inputField
	public InputField input;

	//Gets button that accepts InputField
	public Button boton;

	//Text of the inputField
	string textoInput;

	//Arc that will join the two nodes
	public createArk ca;

	//Node selected #1
	GameObject seleccion1;

	//Node selected #2
	GameObject seleccion2;

	void Awake()
	{
		seleccion1 = null;
		seleccion2 = null;
	}

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		verificacionSeleccion ();
	}


	//Setup for the nodes in 3D space
	public void enterNodes()
	{
		textoInput = input.GetComponent<InputField> ().text;

		//# of nodes you want
		int cantidad = int.Parse (textoInput);

		createNodes (cantidad);

		input.GetComponent<InputField> ().text = "";

		changeState (input.gameObject);

		changeState (boton.gameObject);

	}

	//Creates the amount of nodes listed in 'cantidad'
	void createNodes(int cantidad)
	{

		for (int i = 0; i < cantidad; i++)
		{
			//Creates a primitive object that will represent the node
			GameObject nuevo = GameObject.CreatePrimitive (PrimitiveType.Sphere);

			//Places the node in the current display
			Vector3 temp = new Vector3 (Random.Range(-10.0f,10.0f), Random.Range(-4.2f,6.10f), 0 );
			nuevo.transform.position = temp;
			nuevo.GetComponent<MeshRenderer> ().material.color = Color.red;
			nuevo.tag = "nodo";
		}
	}

	//Changes the sate of a node
	void changeState(GameObject go)
	{
		if (go.activeSelf == true) {
			go.SetActive (false);
		} else {
			go.SetActive (true);
		}
	}

	//Verifieds 
	void verificacionSeleccion()
	{
		GameObject go = devolverGO ();

		if (go == null) {

		} else {
			
			if (go.tag == "nodo") {
				
					if (seleccion1 != null) {
					seleccion2 = go;
						CreateArc ();


				} else if (seleccion1 == null && seleccion2 == null) {
				
					seleccion1 = go;
					cambiarColorActive (seleccion1.GetComponent<MeshRenderer> ());
				}
			}
		}
	}



	void CreateArc()
	{
	//Checks if both selected nodes are the same, thus discards them as selected
		if (seleccion1 == seleccion2) {
			cambiarColorDisActive (seleccion1.GetComponent<MeshRenderer> ());
			seleccion1 = null;
			seleccion2 = null;

		} else {
			cambiarColorActive (seleccion2.GetComponent<MeshRenderer> ());
			crearArco( seleccion1 ,  seleccion2);
		}
	}

	void crearArco(GameObject go1, GameObject go2)
	{
		createArk ca =	new createArk (go1, go2, this);

	}

	//Returns the current Node
	GameObject devolverGO()
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
	void cambiarColorActive(MeshRenderer mr)
	{
		mr.material.color = Color.green;
	}

	//Changes the color of hte node when it's not active
	void cambiarColorDisActive(MeshRenderer mr)
	{
		mr.material.color = Color.red;
	}

}
