using ToolsAPi.Core.Models;

namespace ToolsAPI.BusinessLayer.Services
{
    public interface IPeopleService
    {
        Task<IEnumerable<PersonViewModel>> GetListOfPeople(string filter);
    }
}