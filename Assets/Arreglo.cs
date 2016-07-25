using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;

public class Arreglo : MonoBehaviour {


	public GameObject[] objetos ;
	private GameObject primerObjeto; 
	public  Button botonAgregar;
	public Button botonBorrar;
	public InputField campoInput;
	private Color porDefecto; 
	public Button inicio;
	Transform padre;
	public int num333 = 1;

	int n =2;


	// Use this for initialization
	void Start () 
	{
		

		primerObjeto = objetos [0];
		padre = primerObjeto.transform.parent;
		primerObjeto.SetActive (false);


	}
	
	// Update is called once per frame
	void Update () 
	{
		//Debug.Log(campoInput.text + "q" );
		//Debug.Log();
	 //	deleteFromArray();
	}

public	void addToArray()
	{

		if(verificarCampoInput())
		{
			int numero = int.Parse(campoInput.textComponent.text);
			objetos [numero].GetComponent<MeshRenderer> ().material.color = Color.magenta;
		}
	
		else
		{
			for (int i = 0; i < objetos.Length; i++) 
			{
				//Debug.Log ("Entro a bucle");
				bool estaVacia = revisarColor (objetos [i].GetComponent<MeshRenderer> ().material.color);
					
				if (estaVacia) 
				{
					//Debug.Log ("Entro a estaVacia");
					objetos [i].GetComponent<MeshRenderer> ().material.color = Color.magenta;
					//	Debug.Log(objetos [i].GetComponent<MeshRenderer> ().material.mainTexture);
					break;
				}
				if (objetos [objetos.Length-1].GetComponent<MeshRenderer>().material.color ==Color.magenta ) {
					reArrangeArray();
					break;
				}
			}
			//Check 
		}



	}

	public bool revisarColor(Color actual)
	{
		if (actual == porDefecto) 
		{
			return true;
		}
		return false;
	}

	public bool verificarCampoInput()
	{
		//Debug.Log ("Entro a verificar input " + campoInput.textComponent.text);
		if (campoInput.textComponent.text.Length > 0) 
		{
			//Debug.Log ("Entro a validar input");
			return true;
		}
		return false;
	}

	public void activarBotones()
	{
		crearCasillas ();
		botonAgregar.gameObject.SetActive (true);
		botonBorrar.gameObject.SetActive (true);
		campoInput.gameObject.SetActive (true);

		inicio.gameObject.SetActive (false);
	}

	void crearCasillas()
	{
		primerObjeto.SetActive (true);
		float x = primerObjeto.transform.position.x;


		for (int i = 1; i < objetos.Length; i++) 
		{

			objetos [i] = Instantiate (primerObjeto);
			objetos [i].transform.parent = padre.transform;

			x++;
			x = x + 0.5f;
			objetos [i].transform.position = new Vector3 (0.5f,0,x);

		}
		porDefecto = objetos [0].GetComponent<MeshRenderer> ().material.color;
	}

	public void deleteFromArray()
	{
		int longitud = objetos.Length;


		if (verificarCampoInput ()) {
			int numero = int.Parse (campoInput.textComponent.text);
			objetos [numero].GetComponent<MeshRenderer> ().material.color = porDefecto;
		} else {
			for (int i = longitud - 1; i >= 0; i--) {
				bool estaVacia = revisarColor (objetos [i].GetComponent<MeshRenderer> ().material.color);
				if (!estaVacia) {
					objetos [i].GetComponent<MeshRenderer> ().material.color =	porDefecto;
					break;
				}
			}
		}
		
	}

	void reArrangeArray()
	{
		if (objetos [objetos.Length-1].GetComponent<MeshRenderer> ().material.color ==Color.magenta) {
			Debug.Log ("Entro a Re arrange");
			GameObject[] temp = new GameObject[(objetos.Length * 3) / 2];

			int tamAnterior = 0;

			for (int i = 0; i < objetos.Length; i++) {

				temp [i] = objetos [i];
				tamAnterior ++;
			}
			objetos = temp;
			//objetos.Length;

			reCreateCasillas (objetos, tamAnterior-1);

			Debug.Log (objetos.Length+ " parce que");
			/*
		for(int i = 0; i<objetos.Length;i++)
		{
			Debug.Log ("Entro a agregar nuevo arreglo");
			temp[i]= objetos[i];
			}
		}
	*/
		}
	}

	void reCreateCasillas(GameObject[] z, int y)
	{


		primerObjeto = z [y];


		float x = primerObjeto.transform.position.z;



	
		for (int i = y+1; i < z.Length; i++) 
		{
			
			z [i] = Instantiate (primerObjeto);
			Debug.Log (z [i].gameObject.transform.position);
			z [i].transform.parent = primerObjeto.transform.parent;

			Debug.Log ("pos " + z [i].transform);

			x++;
			x = x + 0.5f;
				z [i].transform.position = new Vector3 (0.5f,0,x);
			z [i].GetComponent<MeshRenderer> ().material.color = Color.white;

		}

		Camera cam = Camera.main;
		//Debug.Log(z.Length/2);
		//debugz.Length/2;
		Vector3 tempPos = cam.transform.position;
		tempPos.z = z[z.Length/2].transform.position.z;
		tempPos.x =  z.Length/2 +10f;
		tempPos.y = tempPos.y + 0.35f;
		n++;

		cam.transform.position = tempPos;

		//porDefecto = objetos [0].GetComponent<MeshRenderer> ().material.color;
	}



}
