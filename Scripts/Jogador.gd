extends Entidade
class_name Jogador

enum Modo{
	ESTRELA,
	FOGO,
}

signal set_valor_moeda(valor)

var modo: int
var pulando: bool = false

#Estatitiscas do jogo
var moeda: int = 0

#Sempre que esse valor passar de 1 ganha um coração
var delta_moeda: int = 0


func _ready() -> void:
	._ready()
	add_to_group("jogador")
	set_mov(125, 475)
	modo = Modo.ESTRELA

func _sinais() -> void:
	._sinais()
	var pulo: Area2D = $Pulo
	pulo.connect("body_entered", self, "_pulo_body_entered")

func _movimento() -> void:
	#Movimento da gravidade
	mov.y += gravidade
	
	if Input.is_action_pressed("ui_right"):
		mov.x = mov_dir - atrito
	elif Input.is_action_pressed("ui_left"):
		mov.x = - (mov_dir - atrito)
	else:
		if is_on_floor():
			if mov.x > atrito:
				mov.x -= atrito
			elif mov.x < -atrito:
				mov.x += atrito
			else:
				mov.x = 0
		else:
			mov.x = 0
	
	if is_on_floor():
		if Input.is_action_just_pressed("ui_a"):
			pulo()
		else:
			pulando = false


func pulo() -> void:
	.pulo()
	pulando = true


func _animacao() -> void:
	
	var ui_right: bool = Input.is_action_pressed("ui_right")
	var ui_left: bool = Input.is_action_pressed("ui_left")
	
	if pulando:
		anim_prox = get_str_modo() + "_" + "Pulando"
	elif ui_right || ui_left:
		anim_prox = get_str_modo() + "_" + "Andando"
	else:
		anim_prox = get_str_modo() + "_" + "Parado"
	
	if ui_right:
		anim.flip_h = false
	elif ui_left:
		anim.flip_h = true


#Retonra a string do modo
func get_str_modo() -> String:
	if modo == Modo.ESTRELA:
		return "Estrela"
	else:
		return "Fogo"

#Adiciona moeda
func add_moeda(valor: int = 1) -> void:
	moeda += valor
	emit_signal("set_valor_moeda", moeda)
	delta_moeda += valor
	if delta_moeda >= 25:
		recupera_vida()
		delta_moeda = 0


func _pulo_body_entered(body: Node) -> void:
	if body.is_in_group("inimigo"):
		(body as Entidade).dano_pulo(self)
