namespace NorthWind.API.Models
{
    public class ConfirmEmailModel
    {
        public string UserId { get; set; }
        public string Code { get; set; }
    }
}