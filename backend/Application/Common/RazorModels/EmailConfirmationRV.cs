namespace Application.Common.RazorModels
{
    public class EmailConfirmationRV
    {
        public string? Userame { get; set; }
        public required string ConfirmationLink { get; set; }
    }
}
