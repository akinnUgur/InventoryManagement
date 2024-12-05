using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Core.DTOs
{
    public class ApiResponse<T>
{
    public bool IsSuccess { get; set; }
    public string Message { get; set; }
    public T Data { get; set; }
    public int StatusCode { get; set; }

    public ApiResponse(bool isSuccess, string message, T data, int statusCode)
    {
        IsSuccess = isSuccess;
        Message = message;
        Data = data;
        StatusCode = statusCode;
    }

    // Success response
    public static ApiResponse<T> Success(T data, string message = "Operation successful", int statusCode = 200)
    {
        return new ApiResponse<T>(true, message, data, statusCode);
    }

    // Error response
    public static ApiResponse<T> Error(string message, int statusCode = 400)
    {
        return new ApiResponse<T>(false, message, default, statusCode);
    }
}

}
