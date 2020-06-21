extends ParallaxLayer
class_name ParallaxLayerInt

func _process(delta):
	position = position.round()
