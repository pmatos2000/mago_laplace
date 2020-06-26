extends Sprite

export(int) var frame_inicial: int = 1
export(int) var frame_final: int = 1
export(float) var tempo: float = 0.05

var frame_atual: int = 0
var total_frame: int
var dt: float = 0


func _ready():
	total_frame = frame_final - frame_inicial + 1


func _process(delta):
	dt += delta
	if dt >= tempo:
		dt = 0
		frame_atual = (frame_atual + 1) % total_frame
		frame = frame_atual + frame_inicial
		
