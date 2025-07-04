namespace DoctorApp.Application;

public class BaseResponse
{
    public string Message { get; set; }
    public bool Success { get; set; }

    public BaseResponse(string message,bool success)
    {
        Message = message;
        Success = success;
    }
}