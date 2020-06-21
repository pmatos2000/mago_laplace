extends Node

# Não esquecer de mudar o modo de exibição para "viewport" e o aspecto para ignorar
onready var viewport: Viewport = get_viewport()

func _ready() -> void:
	get_tree().connect("screen_resized", self, "_screen_resized")

func _screen_resized() -> void:
	
	var window_size: Vector2  = OS.get_window_size()

	# Calcula o valor maximo que pode escalonar
	var scale_x: int = floor(window_size.x / viewport.size.x)
	var scale_y: int = floor(window_size.y / viewport.size.y)
	var scale: int = max(1, min(scale_x, scale_y)) # O minimo vai ser 1

	# Centraliza a janela
	var diff: Vector2 = (window_size - (viewport.size * scale))
	var diffhalf: Vector2 = (diff * 0.5).floor()

	# Configura a exibição
	viewport.set_attach_to_screen_rect(Rect2(diffhalf, viewport.size * scale))
