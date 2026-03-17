namespace StudentPortalMVC.Services.Helpers;
public interface IPhoneMaskService
{
    string MaskPhone(string? phone);
}
public class PhoneMaskService : IPhoneMaskService
{
    public string MaskPhone(string? phone)
    {
        if (string.IsNullOrEmpty(phone) || phone.Length < 4)
            return phone ?? "";
        var visibleDigits = phone[^2..];
        return new string('*', phone.Length - 2) + visibleDigits;
    }
}