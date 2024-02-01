using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace HighLowGame.API.dtos;

public class RegisterPlayerRequestDto
{
    [JsonPropertyName("username")]
    [Required(ErrorMessage = "Username is required to register a user")]
    public string Username { get; set; }
}