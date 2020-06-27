extends Node2D

export(String) var caminho_cena: String
export(float) var dist: float = 480

var level: Level
var ref: Node2D
var cena: Resource
var gerado: Node2D = null
var trava: bool = true #Só é gerado se o jogador nao tiver proximo


func _ready() -> void:
	ref = get_tree().get_nodes_in_group("jogador")[0]
	level = get_tree().get_nodes_in_group("Level")[0]
	cena = load(caminho_cena)
	var sprite: Sprite = $Sprite
	if sprite != null:
		sprite.visible = false

func _gera() -> void:
	gerado = cena.instance()
	if gerado is Entidade:
		var entidade: Entidade = gerado
		gerado.set_fisica(level.gravidade, level.atrito)
		gerado.connect("morte", self, "_apaga")
	add_child(gerado)

func _apaga() -> void:
	remove_child(gerado)
	gerado = null
	trava = true

func _process(delta) -> void:
	var d: float
	if gerado == null:
		d = (ref.global_position - global_position).length()
		if d < dist and trava == false:
			_gera()
		elif d > dist:
			trava = false
	else:
		d = (ref.global_position - gerado.global_position).length()
		if d > 1.25*dist:
			_apaga()
