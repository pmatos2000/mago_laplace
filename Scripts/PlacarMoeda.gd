extends Placar

var total_moedas: Label

func _ready() -> void:
	total_moedas = $TotalMoedas

func set_valor(valor: int) -> void:
	var aux: String = str(valor)
	var zeros: int = 4 - len(aux)
	print(len(aux))
	var i: int
	for i in range(zeros):
		aux = "0" + aux
	
	total_moedas.text = aux
