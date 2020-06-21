extends KinematicBody2D
class_name Jogador

const mov_dir: int = 125
const mov_pulo: int = 450
const dir_para_cima: Vector2 = Vector2(0,-1)


enum Modo{
	ESTRELA,
	FOGO,
}

signal set_valor_moeda(valor)
signal set_valor_mana(valor)
signal set_valor_vida(valor)

var mov: Vector2 = Vector2(0,0)
var anim: AnimatedSprite
var modo: int
var pulando: bool = false

#Estatitiscas do jogo
var moeda: int = 0
var vida: int = 2
var mana: int = 100
var anim_prox: String = ""


#Sempre que esse valor passar de 1 ganha um coração
var delta_moeda: int = 0


var gravidade: float = 0
var empuxo: float = 0
var atrito: float = 0


func set_fisica(gravidade: float, empuxo: float, atrito: float) -> void:
	self.gravidade = gravidade
	self.empuxo = empuxo
	self.atrito = atrito

func _ready() -> void:
	modo = Modo.ESTRELA
	anim = $AnimatedSprite

func _physics_process(delta: float) -> void:
	_movimento()
	_animacao()

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
			mov.y = -mov_pulo
			pulando = true
		else:
			pulando = false
	
	#Realiza o movimento
	mov = move_and_slide(mov,dir_para_cima)


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
	
	anim.play(anim_prox)

	
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
		add_vida()
		delta_moeda = 0
	

#Adiciona coracao
func add_vida(valor: int = 1) -> void:
	vida += valor
	emit_signal("set_valor_vida", vida)
