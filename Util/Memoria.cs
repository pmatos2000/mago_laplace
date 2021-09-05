using Godot;
using System;
using System.Collections.Generic;

public class Memoria: Node{
	
	private Dictionary<string,int> _dicInt = new Dictionary<string,int>();
	private Dictionary<string,bool> _dicBool = new Dictionary<string,bool>();
	private Dictionary<string,string> _dicString = new Dictionary<string,string>();
	private  Dictionary<string,float> _dicFloat = new Dictionary<string,float>();
	
	//Limpa todos os dicionarios
	public void Limpa(){
		_dicInt.Clear();
		_dicBool.Clear();
		_dicString.Clear();
		_dicFloat.Clear();
	}
	
	//Adiciona um númerio inteiro na memoria
	public void Add(string chave, int valor){
		if(_dicInt.ContainsKey(chave)){  //Verifica se tem a chave
			_dicInt[chave] = valor;
		}
		else{
			_dicInt.Add(chave, valor);
		}
	}
	
	//Ler um número inteiro
	public int GetInt(string chave, int valorPadrao = 0){
		if(_dicInt.ContainsKey(chave)){  //Verifica se tem a chave
			return _dicInt[chave];
		}
		else{
			return valorPadrao;
		}
	}
	
	//Adiciona um número booleano na memoria
	public void Add(string chave, bool valor){
		if(_dicBool.ContainsKey(chave)){  //Verifica se tem a chave
			_dicBool[chave] = valor;
		}
		else{
			_dicBool.Add(chave, valor);
		}
	}
	
	//Ler um número booleano
	public bool GetBool(string chave, bool valorPadrao = false){
		if(_dicBool.ContainsKey(chave)){  //Verifica se tem a chave
			return _dicBool[chave];
		}
		else{
			return valorPadrao;
		}
	}
	
	//Adiciona uma string na memoria
	public void Add(string chave, string valor){
		if(_dicString.ContainsKey(chave)){  //Verifica se tem a chave
			_dicString[chave] = valor;
		}
		else{
			_dicString.Add(chave, valor);
		}
	}
	
	//Retorna uma string da memoria
	public string GetString(string chave, string valorPadrao = null){
		if(_dicString.ContainsKey(chave)){  //Verifica se tem a chave
			return _dicString[chave];
		}
		else{
			return valorPadrao;
		}
	}
	
	//Adiciona um float na memoria
	public void Add(string chave, float valor){
		_dicFloat.Add(chave,valor);
	}
	
	//Retorna um float da memoria
	public float GetFloat(string chave, float valorPadrao = 0){
		if(_dicFloat.ContainsKey(chave)){  //Verifica se tem a chave
			return _dicFloat[chave];
		}
		else{
			return valorPadrao;
		}
	}
	
}
