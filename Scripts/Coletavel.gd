extends KinematicBody2D
class_name Coletavel

#Retorna a animação
func _get_anim() -> AnimatedSprite:
	return ($AnimatedSprite as AnimatedSprite)

#Faz ligação dos sinais
func _sinais() -> void:
	var area2D: Area2D = $Area2D
	if area2D != null:
		area2D.connect("body_entered", self, "_area2D_body_entered")

func _ready() -> void:
	var anim: AnimatedSprite = _get_anim()
	var coll: CollisionShape2D = $CollisionShape2D
	if anim != null:
		anim.playing = true
	if coll != null:
		coll.disabled = true
	add_to_group("Coletavel")
	_sinais()

func _area2D_body_entered(body: Node) -> void:
	if body is Jogador:
		_area2D_body_entered_jogador(body)

func _area2D_body_entered_jogador(var jogador: Jogador) -> void:
	pass
