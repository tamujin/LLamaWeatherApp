using OllamaSharp;

var uri = new Uri("http://localhost:11434");
var ollama = new OllamaApiClient(uri);

ollama.SelectedModel = "llama3";

await foreach (var stream in ollama.GenerateAsync("generate c# factorial function in c#"))
	Console.Write(stream.Response);

Console.ReadLine();