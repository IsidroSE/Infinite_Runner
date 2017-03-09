using UnityEngine;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;

public class EstadoJuego : MonoBehaviour {

	public int PuntuacionMaxima = 0;

	public static EstadoJuego estadoJuego;
	private string rutaArchivo;

	void Awake () {
		rutaArchivo = Application.persistentDataPath + "/datos.dat";
		if (estadoJuego == null) {
			estadoJuego = this;
			DontDestroyOnLoad (gameObject);
		} 
		else if (estadoJuego != this) {
			Destroy(gameObject);
		}
	}

	// Use this for initialization
	void Start () {
		Cargar();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Guardar () {
		BinaryFormatter bf = new BinaryFormatter();
		FileStream file = File.Create(rutaArchivo);

		DatosAGuardar datos = new DatosAGuardar();
		datos.puntuacionMaxima = PuntuacionMaxima;

		bf.Serialize(file, datos);

		file.Close();
	}

	void Cargar () {
		if (File.Exists (rutaArchivo)) {
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream file = File.Open (rutaArchivo, FileMode.Open);

			DatosAGuardar datos = (DatosAGuardar)bf.Deserialize (file);

			PuntuacionMaxima = datos.puntuacionMaxima;

			file.Close ();
		} 
		else {
			PuntuacionMaxima = 0;
		}
	}



}


[Serializable]
class DatosAGuardar {
	public int puntuacionMaxima;

	public DatosAGuardar () {}

	public DatosAGuardar (int puntuacionMaxima) {
		this.puntuacionMaxima = puntuacionMaxima;
	}
}
