extends Camera2D


export(NodePath) var caminho_ref: NodePath
var ref: Node2D


# Called when the node enters the scene tree for the first time.
func _ready():
	_ref()
	_limites()


func _ref() -> void:
	var node: Node = get_node(caminho_ref)
	if node is Node2D:
		ref = node
	else:
		print("Node ref não compartivel no script da camera")
		get_tree().quit()

func _limites() -> void:
	
	var lim_esq: int = limit_left
	var lim_dir: int = limit_right
	var lim_top: int = limit_top
	var lim_inf: int = limit_bottom
	
	var vetor_tile_map: Array = get_tree().get_nodes_in_group("TileMap")
	var tile_map: TileMap
	var rect: Rect2
	
	for tile_map in vetor_tile_map:
		rect = tile_map.get_used_rect()
		lim_esq = min(lim_esq, rect.position.x * tile_map.cell_size.x)
		lim_dir = max(lim_dir, rect.end.x * tile_map.cell_size.x)
		lim_top = min(lim_top, rect.position.y * tile_map.cell_size.y)
		lim_inf = max(lim_inf, rect.end.y * tile_map.cell_size.y)
	
	limit_left = lim_esq
	limit_right = lim_dir
	limit_top = lim_top
	limit_bottom = lim_inf
	
	

func _process(delta):
	position = ref.position
