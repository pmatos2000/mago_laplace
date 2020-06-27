extends KinematicBody2D
class_name Entidade


const dir_para_cima: Vector2 = Vector2(0,-1)

#Fisica
var gravidade: float = 0
var atrito: float = 0
var mov_dir: float = 0
var mov_pulo: float = 0

#Vida
var vida: int = 1
var mana: int = 1

#Movimento
var mov: Vector2 = Vector2(0,0)
var acao_prox: int

#Animação
var anim_prox: String = ""
var anim: AnimatedSprite

#Sinais
signal set_valor_vida(valor)
signal set_valor_mana(valor)
signal morte()

func _ready() -> void:
	_sinais()
	_referencias()
	add_to_group("entidade")

func _process(delta):
	_acao()
	_realiza_acao()
	_animacao()
	_executa_animacao()

func _physics_process(delta: float) -> void:
	_movimento()
	_realiza_movimento()


#Faz ligação dos sinais
func _sinais() -> void:
	var area2D: Area2D = $Area2D
	if area2D != null:
		area2D.connect("body_entered", self, "_area2D_body_entered")

		

func _referencias() -> void:
	anim = $AnimatedSprite

func _movimento() -> void:
	#Movimento da gravidade
	mov.y += gravidade

func _realiza_movimento() -> void:
	mov = move_and_slide(mov,dir_para_cima)

func _acao() -> void:
	pass

func _realiza_acao() -> void:
	pass

func _animacao() -> void:
	pass
	
func _executa_animacao() -> void:
	anim.play(anim_prox)

#Adiciona coracao
func recupera_vida(valor: int = 1) -> void:
	vida += valor
	emit_signal("set_valor_vida", vida)

#Sofre dano
func dano(valor: int = 1):
	vida -= valor
	emit_signal("set_valor_vida", vida)
	if vida <= 0:
		_morte()

#Sofre um dano causado por um pulo
func dano_pulo(entidade: Node) -> void:
	dano()
	(entidade as Entidade).pulo()

func pulo() -> void:
	mov.y = -mov_pulo

func set_fisica(gravidade: int, atrito: float = 0):
	self.gravidade = gravidade
	self.atrito = atrito

func set_mov(mov_dir: float, mov_pulo: float = 0) -> void:
	self.mov_dir = mov_dir
	self.mov_pulo = mov_pulo
	
func set_vida(vida: int, mana: int) -> void:
	self.vida = vida
	emit_signal("set_valor_vida", vida)
	if vida <= 0:
		_morte()
	self.mana = mana
	emit_signal("set_valor_mana", mana)

func _area2D_body_entered(body: Node) -> void:
	pass

func _morte() -> void:
	emit_signal("morte")
