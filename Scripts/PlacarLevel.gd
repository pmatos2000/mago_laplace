extends CanvasLayer
class_name PlacarLevel

var placar_vida: Placar
var placar_mana: Placar
var placar_relogio: Placar
var placar_moeda: Placar
var placa_diamante: Placar

func _enter_tree() -> void:
	add_to_group("PlacarLevel")

func _ready() -> void:
	placar_vida = $PlacarVida as Placar
	placar_mana = $PlacarMana as Placar
	placar_relogio = $PlacarRelogio as Placar
	placar_moeda = $PlacarMoeda as Placar
	placa_diamante = $PlacarDiamante as Placar

func set_valor_moeda(valor: int) -> void:
	placar_moeda.set_valor(valor)

func set_valor_vida(valor: int) -> void:
	placar_vida.set_valor(valor)

func set_valor_mana(valor: int) -> void:
	placar_mana.set_valor(valor)

func set_valor_relogio(valor: int) -> void:
	placar_relogio.set_valor(valor)

func atualiza_diamante() -> void:

	placa_diamante.atualiza()
