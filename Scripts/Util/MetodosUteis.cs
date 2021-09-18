using Godot;
using System;

public class MetodosUteis
{
	public static void ErroFaltaNo(Node noPai, string caminho)
	{
		var msg = string.Format(Constantes.Mensagem.ERRO_FALTA_NO, caminho);
		GD.PrintErr(msg);
		noPai.GetTree().Quit();
	}
	public static T ObterNo<T>(Node noPai, string caminho)  where T : Node 
	{
		if (caminho == null) ErroFaltaNo(noPai, "<null>");
		T t = noPai.GetNode<T>(caminho);
		if (t == null)
		{
			ErroFaltaNo(noPai, caminho);
		}
		return t;
	}

	public static CentralAudio ObterCentralAudio(Node noPai)
    {
		return ObterNo<CentralAudio>(noPai, Constantes.Caminhos.CENTRAL_AUDIO);
	}
}
