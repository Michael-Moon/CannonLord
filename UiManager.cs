using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour {

	public static UiManager instance;

	//variaves componetes da Ui
	public Button btnPause, btnContinue, btnReiniciar, btnInicio;   	// Botões que tem na cena de jogo
	public Text txtpontos,txtRecarregando;								// textos de ponto e recarregamento do tiro
	//pontos e se jogo começou
	public bool ComecouJogo;											// bool que verificar se jogo começou
	public int pontos;													// int de pontuação	

	//metodo Awake para pega instancia do obj e não destruir, qnd cena recarregada
	void Awake(){
	
		if (instance == null) {
		
			instance = this;
			DontDestroyOnLoad (this.gameObject);
		}else{
		
			Destroy(gameObject);
		}
		SceneManager.sceneLoaded += UiMenu;
	}

	//metodo que pega dados Ui qnd cena muda
	void UiMenu(Scene cena, LoadSceneMode modo){
		pegaDadosUi ();
	}
	//metodo pega componetes da Ui e cria eventos
	void pegaDadosUi(){

		//botões
		btnPause = GameObject.Find ("btnPause").GetComponent<Button> ();
		btnContinue = GameObject.Find ("btnDesPause").GetComponent<Button> ();
		btnInicio = GameObject.Find ("btnInicio").GetComponent<Button> ();
		btnReiniciar = GameObject.Find ("btnReiniciar").GetComponent<Button> ();

		//text
		txtpontos = GameObject.Find("txtPontos").GetComponent<Text>();
		txtRecarregando = GameObject.Find ("txtRecarregando").GetComponent<Text> ();

		//Eventos
		btnPause.onClick.AddListener(PauseGame);
		btnContinue.onClick.AddListener (DesPause);
		btnInicio.onClick.AddListener (IniciaJogo);
		btnReiniciar.onClick.AddListener (Reiniciar);


	}
	// Use this for initialization
	void Start () {
		//iniciando esses objs invisiveis 
		btnContinue.gameObject.SetActive (false);
		btnPause.gameObject.SetActive (false);
		txtRecarregando.gameObject.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		//atualização txt quando ganhar pontos
		txtpontos.text = pontos.ToString ();
	}
	//Pausando Game
	void PauseGame(){
	
		btnPause.gameObject.SetActive (false);
		btnContinue.gameObject.SetActive (true);
		Time.timeScale = 0;

	}
	//Tirando Pause
	void DesPause(){
	
		btnPause.gameObject.SetActive (true);
		btnContinue.gameObject.SetActive (false);
		Time.timeScale = 1;
	}
	//Iniciando Jogo
	void IniciaJogo(){
	
		ComecouJogo = true;
		btnInicio.gameObject.SetActive (false);
		btnPause.gameObject.SetActive (true);
	}
	//reiniciar jogo
	void Reiniciar(){
	
		if(ComecouJogo) {
		

			ComecouJogo = false;
			pontos = 0;
			Time.timeScale = 1;
			SceneManager.LoadScene ("Cena01");
		}
	}
}
