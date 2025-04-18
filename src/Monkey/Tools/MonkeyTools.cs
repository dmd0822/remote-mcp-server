using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Extensions.Mcp;
using System;
using System.ComponentModel;
using System.Text.Json;
using Monkey.Services;
using static Monkey.ToolsInformation;

namespace Monkey
{    
    public static class MonkeyTools
    {
        [Function("GetMonkeys")]
        public static async Task<string> GetMonkeys([McpToolTrigger(GetMonkeysToolName, GetMonkeysToolDescription)] ToolInvocationContext context, MonkeyService monkeyService)
        {
            var monkeys = await monkeyService.GetMonkeys();
            return JsonSerializer.Serialize(monkeys);
        }
        
        [Function("GetMonkey")]
        public static async Task<string> GetMonkey([McpToolTrigger(GetMonkeyToolName, GetMonkeyToolDescription)] ToolInvocationContext context, MonkeyService monkeyService, 
             [McpToolProperty(MonkeyNamePropertyName, PropertyType, MonketNamePropertyDescription )] string name)
        {
            var monkey = await monkeyService.GetMonkey(name);
            return JsonSerializer.Serialize(monkey);
        }                
    }
}