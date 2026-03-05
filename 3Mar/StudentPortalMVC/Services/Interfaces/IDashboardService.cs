using StudentPortalMVC.ViewModels;

namespace StudentPortalMVC.Services.Interfaces;

public interface IDashboardService
{
    Task<DashboardVM> GetDashboardDataAsync();
}