using StudentPortalMVC.Services.Helpers;

namespace StudentPortalMVC.Models;

public partial class Student
{
    public string GetMaskedPhone(IPhoneMaskService maskService)
    {
        return maskService.MaskPhone(Phone);
    }
}