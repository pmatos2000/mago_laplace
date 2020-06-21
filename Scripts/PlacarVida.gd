extends Placar

var vetor_coracao: Array
export(int) var maximo: int = 5



func _ready() -> void:
	var i: int
	for i in range(maximo):
		vetor_coracao.append(get_node("Coracao_" + str(i)))
	set_valor(0)
	
func set_valor(valor: int) -> void:
	var i: int
	var coracao: Sprite
	for i in range(maximo):
		coracao = (vetor_coracao[i] as Sprite)
		if i < valor:
			coracao.visible = true
		else:
			coracao.visible = false
