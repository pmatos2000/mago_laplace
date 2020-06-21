extends Node
class_name Level


export(float) var gravidade: float = 15
export(float) var empuxo: float = 0
export(float) var atrito: float = 10
export(int) var tempo_max: int = 180
export(String) var level_nome: String = "sem_nome"

var tempo: float = 0

#Dicionario contendo variaveis
var _dic_int: Dictionary = {}
var _dic_bool: Dictionary = {}

var placar_level: PlacarLevel
var jogador: Jogador

func _init_jogador() -> void:
	jogador = $Jogador
	jogador.gravidade = gravidade
	jogador.empuxo = empuxo
	jogador.atrito = atrito
	

func _init_placar() -> void:
	placar_level = $PlacarLevel
	jogador.connect("set_valor_moeda", placar_level, "set_valor_moeda")
	jogador.connect("set_valor_vida", placar_level, "set_valor_vida")
	
func _ready() -> void:
	_init_jogador()
	_init_placar()
	_init_level()

func _process(delta) -> void:
	tempo += delta
	placar_level.set_valor_relogio(round(tempo_max - tempo))


func _init_level() -> void:
	var valor: int
	placar_level.set_valor_vida(2)
	placar_level.set_valor_mana(4)
	placar_level.set_valor_relogio(tempo_max)
	placar_level.atualiza_diamante()
	


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

func registra_diamante(nome: String):
	add_bool(nome, true)
	placar_level.atualiza_diamante()
