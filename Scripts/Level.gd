extends Node
class_name Level


export(float) var gravidade: float = 15
export(float) var empuxo: float = 0
export(float) var atrito: float = 10
export(int) var tempo: int = 300
export(String) var level_nome: String = "sem_nome"

#Dicionario contendo variaveis
var _dic_int: Dictionary = {}
var _dic_bool: Dictionary = {}

func _enter_tree() -> void:
	add_to_group("Level")

func add_int(nome: String, valor: int) -> void:
	_dic_int[nome] = valor

func get_int(nome: String, valor_padrao: int = 0) -> int:
	if nome in _dic_int:
		return _dic_int[nome]
	else:
		return valor_padrao

func add_bool(nome: String, valor: bool) -> void:
	_dic_bool[nome] = valor

func get_bool(nome: String, valor_padrao: bool = false) -> bool:
	if nome in _dic_bool:
		return _dic_bool[nome]
	else:
		return valor_padrao
