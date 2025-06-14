namespace Core.Features.Users.Commands;

public sealed record ChangePassword(string UserId, string OldPassword, string NewPassword, string ConfirmNewPassword) : IValidatorRequest, IRequest<Response<string>> { }
