extends Coletavel

var id: int
var level: Level

func _ready() -> void:
	._ready()
	level = get_tree().get_nodes_in_group("Level")[0]
	id = level.get_int("total_diamante")
	level.add_int("total_diamante", id + 1)

func _area2D_body_entered_jogador(var jogador: Jogador) -> void:
	level.add_bool("diamante_" + str(id), true)
	queue_free()
