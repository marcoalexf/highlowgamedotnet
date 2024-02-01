using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace HighLowGame.API.dtos;

public class MakeMoveGameRequestDto
{
    [Required]
    [JsonPropertyName("playerId")]
    public string PlayerId { get; set; }
    
    [JsonPropertyName("numberGuess")]
    public int? NumberGuess { get; set; }
    
    [JsonPropertyName("choseHigh")]
    public bool? ChoseHigh { get; set; }
}