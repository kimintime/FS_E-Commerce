namespace Backend.Models;

using System.Text.Json.Serialization;

//The base model will give ID and created and updated dates to all models

public abstract class BaseModel
{
    //Not using UUID because this is a simple home project. 
    public int Id { get; init; }

    [JsonIgnore]
    public DateTime CreatedAt { get; set; }
    
    [JsonIgnore]
    public DateTime UpdatedAt { get; set;}
}
