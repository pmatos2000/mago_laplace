extends Placar

var level: Level
var vetor_diamante: Array
const rect_diamante: Rect2 = Rect2(120,0,24,24)
const rect_nao_diamante: Rect2 = Rect2(144,0,24,24)

func _ready() -> void:
	var i: int
	level = get_tree().get_nodes_in_group("Level")[0]
	for i in range(3):
		vetor_diamante.append(get_node("Diamante_" + str(i)))
	

func atualiza() -> void:
	var i: int
	var diamante: Sprite
	for i in range(3):
		diamante = vetor_diamante[i] as Sprite
		if level.get_bool("diamante_" + str(i)):
			diamante.region_rect = rect_diamante
		else:
			diamante.region_rect = rect_nao_diamante
