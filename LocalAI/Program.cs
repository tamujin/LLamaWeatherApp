﻿using Microsoft.Extensions.AI;

IChatClient chatClient =
	new OllamaChatClient(new Uri("http://localhost:11434/"), "tinyllama");

List<ChatMessage> chatHistory = new();

while (true)
{
	Console.WriteLine("Your prompt:");
	var userPrompt = Console.ReadLine();
	chatHistory.Add(new ChatMessage(ChatRole.User, userPrompt));

	Console.WriteLine("AI Response:");
	var response = "";
	await foreach (var item in
	               chatClient.CompleteStreamingAsync(chatHistory))
	{
		Console.Write(item.Text);
		response += item.Text;
	}
	chatHistory.Add(new ChatMessage(ChatRole.Assistant, response));
	Console.WriteLine();
}