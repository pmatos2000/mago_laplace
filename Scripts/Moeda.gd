extends Coletavel

func _area2D_body_entered_jogador(var jogador: Jogador) -> void:
	jogador.add_moeda()
	queue_free()
