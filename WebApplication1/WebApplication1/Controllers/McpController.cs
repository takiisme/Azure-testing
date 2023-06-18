using Communications.Requests;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Services;

namespace Controllers;

[ApiController]
[Route("[controller]")]

public class McpController: ControllerBase
{
        private readonly IMcpService _mcpService;

        public McpController(IMcpService mcpService)
        {
                _mcpService = mcpService;
        }
        
        [HttpGet("getallMCP")]
        public IActionResult GetAll()
        {
                return Ok("Get all");
        }

        [HttpPost("postallMCP")]
        public async Task<IActionResult> PostAll(McpAddRequest mcpAddRequest)
        {
                var (success, result) = await _mcpService.AddMcp(mcpAddRequest.Id);
                return Ok("Post all: " + mcpAddRequest.Id);
        }

        [HttpGet("getMCP/{MCPid}")]
        public IActionResult GetId([FromRoute] int MCPid)
        {
                return Ok("Get MCP: " + MCPid);
        }

        [HttpPost("postMCP/{MCPid}")]
        public IActionResult PostId(McpAddRequest mcpAddRequest)
        {
                return Ok("Post ID: " + mcpAddRequest.Id);
        }
}