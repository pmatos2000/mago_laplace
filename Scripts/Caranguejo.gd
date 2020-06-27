extends Inimigo


enum direcao{esquerda, direita}
var direcao_atual: int
var vel: int = 50

var mudar_dir: bool = false

# Called when the node enters the scene tree for the first time.
func _ready() -> void:
	._ready()
	var nodes: Array = self.get_tree().get_nodes_in_group("Jogador")
	if nodes != null:
		var jogador: Node2D = nodes[0]
		if global_position.x > jogador.global_position.x:
			direcao_atual = direcao.esquerda
		else:
			direcao_atual = direcao.direita

func _movimento() -> void:
	#Movimento da gravidade
	mov.y += gravidade
	if direcao_atual == direcao.esquerda:
		mov.x = -vel
	else:
		mov.x = vel

func _acao() -> void:
	if is_on_wall():
		mudar_dir = true

func _realiza_acao() -> void:
	if mudar_dir:
		mudar_dir = false
		if direcao_atual == direcao.esquerda:
			direcao_atual = direcao.direita
		else:
			direcao_atual = direcao.esquerda


