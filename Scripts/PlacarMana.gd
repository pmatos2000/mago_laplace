extends Placar

var vetor_mana: Array
export(int) var maximo: int = 5

const rect_mana_meio: Rect2 = Rect2(96,0,24,24)
const rect_mana_cheio: Rect2 = Rect2(72,0,24,24)

func _ready() -> void:
	var i: int
	for i in range(maximo):
		vetor_mana.append(get_node("Mana_" + str(i)))
	set_valor(0)
	
func set_valor(valor: int) -> void:
	var i: int
	var mana: Sprite
	var par: bool
	
	if valor%2 == 0:
		par = true
	else:
		par = false
	
	valor /= 2
	
	for i in range(maximo):
		mana= (vetor_mana[i] as Sprite)
		if i < valor:
			mana.visible = true
			mana.region_rect = rect_mana_cheio
		else:
			mana.visible = false
	
	if !par:
		mana = (vetor_mana[valor+i] as Sprite)
		mana.visible = true
		mana.region_rect = rect_mana_meio
