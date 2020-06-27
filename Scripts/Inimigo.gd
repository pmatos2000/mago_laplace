extends Entidade
class_name Inimigo

func _ready() -> void:
	add_to_group("inimigo")
	
func _area2D_body_entered(body: Node) -> void:
	if body.is_in_group("jogador"):
		 _area2D_body_entered_jogador(body)

func _area2D_body_entered_jogador(entidade: Entidade) -> void:
	#Quando atingido corta o pulo
	if entidade.mov.y > 0:
		entidade.mov.y = 0
	entidade.dano()

