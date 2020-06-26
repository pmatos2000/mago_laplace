extends Placar

var tempo: Label

func _ready():
	tempo = $Tempo

func set_valor(valor: int):
	
	if valor <= 0:
		tempo.text = "0:00"
		return
	
	var m: int = valor/60
	var s: int = valor%60

	
	if s < 10:
		tempo.text = str(m) + ":0" + str(s)
	else:
		tempo.text = str(m) + ":" + str(s)
